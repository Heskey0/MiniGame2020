using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ChangeLevelPanel : UiBase
{
    private string sceneName;
    private string posName;
    private string bgm;
    Animator ani;
    GameObject Player;
    Vector3 pPos;
    CinemachineVirtualCamera cinemechineVC;
   
    private void Awake()
    {
        ani = GetComponent<Animator>();
        
    }

    public void ChangeLevel(string sName, string pName , string BGM) {
        sceneName = sName;
        posName = pName;
        bgm = BGM;
        StartCoroutine(CrossAni());
    }
    IEnumerator CrossAni() {
        AudioMgr.GetInstance().StopBGM();
        ani.SetTrigger("Start");
        ScenesMgr.GetInstance().LoadScene(sceneName, EndLoad);
        yield return new WaitForSeconds(0.95f);
        UIManager.GetInstance().HidePanel("ChangeLevelPanel");
    }

    void EndLoad() {
        AudioMgr.GetInstance().PlayBGM(bgm);
        Debug.Log("成功转场");
        pPos  = GameObject.Find(posName).transform.position;
        cinemechineVC = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.Find("Player");
        cinemechineVC.Follow = Player.transform;
        Player.transform.position = pPos;

    }
}
