using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Talkable : MonoBehaviour
{
    [SerializeField]
    private bool IsEnter;
    public bool canTalk= false ;
    [TextArea(1, 3)]
    public string[] talklines;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsEnter = false;
        }
    }
    private void Update()
    {
        if (IsEnter && Input.GetKeyDown(KeyCode.Space)&&!UIManager.GetInstance().panelDic.ContainsKey("DialoguePanel")&&!canTalk)
        {
            FindObjectOfType<PlayerControl>().canMove = false;
            UIManager.GetInstance().ShowPanel<DialoguePanel>("DialoguePanel", PanelLayer.Mid, ReadDialogue);
            
        }
        if (IsEnter && canTalk && !UIManager.GetInstance().panelDic.ContainsKey("DialoguePanel"))
        {
            FindObjectOfType<PlayerControl>().canMove = false;
            UIManager.GetInstance().ShowPanel<DialoguePanel>("DialoguePanel", PanelLayer.Mid, ReadDialogue);
            canTalk = false;
            this.enabled = false;
        }
    }

    private void ReadDialogue(DialoguePanel dp) {
        dp.ShowContent(talklines);
    }

    public void CanTalk(bool cantalk)
    {
        canTalk = cantalk;
    }
}
