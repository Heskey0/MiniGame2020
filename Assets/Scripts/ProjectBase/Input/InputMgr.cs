using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputMgr : BaseManage<InputMgr>
{
    private bool IsStart = false;

    public InputMgr() {
        MonoManager.GetInstance().AddUpdateListener(MyUpdate);
    }

    public void StartOrStop(bool IsOpen)
    {
        IsStart = IsOpen;
    }

    private void MyUpdate()
    {
        Debug.Log("MyUpdate成功");
        if (!IsStart)
            return;

        Debug.Log("开启检测");

        CheckKey(KeyCode.W);
        CheckKey(KeyCode.A);
        CheckKey(KeyCode.D);
        CheckKey(KeyCode.S);
        CheckKey(KeyCode.E);
        CheckKey(KeyCode.Escape);
       
    }

    private void CheckKey(KeyCode key) {
        if (Input.GetKeyDown(key))
        {
            EventCenter.GetInstance().EventTrigger<KeyCode>("某键按下",key);
        }
        if (Input.GetKeyUp(key))
        {
            EventCenter.GetInstance().EventTrigger<KeyCode>("某键抬起", key);
        }
    }
}
