using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItem : MonoBehaviour
{
    Animator ani;
    public BoxCollIdantify box;
    PlayerControl playerCtrol;



    private void Start()
    {
        ani = GetComponent<Animator>();
        box = transform.GetChild(0).gameObject.GetComponent<BoxCollIdantify>();
        playerCtrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }
    private void Update()
    {
        ani.SetBool("IsOpen", box.IsPlayerEnter);
        if (box.IsPlayerEnter&&playerCtrol.PickName!=""&&Input.GetKeyDown(KeyCode.E)&&playerCtrol.Item.tag== "Food")
        {
            playerCtrol.SaveFood();
            SaveFood();
        }
    }
    void SaveFood() {
        GameObject.FindGameObjectWithTag("UI_Value").GetComponent<UIPanel>().AddFood();
    }
}
