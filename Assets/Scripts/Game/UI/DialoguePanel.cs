using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : UiBase
{
    [Header("属性")]
    public float charPerSecond = 0.05f;  //打字间隔

    public Image image;
    public Text text_Talk;
    public Text text_Name;
    [TextArea(1, 3)]
    public string[] dialogueLines;
    [SerializeField]
    private int currentLine;
    [HideInInspector]
    public bool isActive_Text;
    string words;
    int currentPos;

    void Start()
    {
      

        image =  GetUICon<Image>("Img_Head");
        text_Talk = GetUICon<Text>("Tex_Talk");
        text_Name = GetUICon<Text>("Tex_Name");
        CheckName();

        isActive_Text = true;
        currentPos = 0;
        text_Talk.text = "";
        StartCoroutine(WordsWrite());


    }

    // Update is called once per frame
    void Update()
    {
            
        if (Input.GetKeyDown(KeyCode.Space))
            {
            if (!isActive_Text)
            {
                currentLine++;
                if (currentLine < dialogueLines.Length)
                {
                    CheckName();
                    //text_Talk.text = dialogueLines[currentLine];
                    StartCoroutine(WordsWrite());
                }
                else
                {
                    UIManager.GetInstance().HidePanel("DialoguePanel");
                    FindObjectOfType<PlayerControl>().canMove = true;
                }
            }
                
            }
       
    }
    public void ShowContent(string[] dialogue)
    {
        dialogueLines = dialogue;
        currentLine = 0;

    }

    //查找是否含有名字
    private void CheckName() {

        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            text_Name.text = dialogueLines[currentLine].Replace("n-","");
            currentLine++;
        }
    }


    private IEnumerator WordsWrite()
    {
        isActive_Text = true;
        words = dialogueLines[currentLine];
        while (isActive_Text)
        {
            currentPos++;
            text_Talk.text = words.Substring(0, currentPos);
            yield return new WaitForSeconds(charPerSecond);
            if (currentPos >= words.Length)
            {
                isActive_Text = false;
                currentPos = 0;
                text_Talk.text = words;
            }

        }

        yield return null; //解析暂停到什么时候

    }

    //结束清算数据
}
