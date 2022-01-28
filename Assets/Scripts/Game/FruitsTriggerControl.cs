using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsTriggerControl : MonoBehaviour
{
    public Transform fruitPos;
    Animator ani;
    bool IsEnter;


    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InputMgr.GetInstance().StartOrStop(true);
            IsEnter = true;
        }
    }

    public void Update()
    {
        if (IsEnter)
        {
            EventCenter.GetInstance().AddEventListener<KeyCode>("某键按下", (key) => {
                if (key == KeyCode.E)
                {
                    if (fruitPos.childCount < 1)
                    {
                        this.gameObject.transform.SetParent(fruitPos);
                        this.gameObject.transform.position = fruitPos.position;
                        if (ani!=null)
                        {
                            ani.SetTrigger("IsPickUp");
                        }
                        InputMgr.GetInstance().StartOrStop(false);
                        return;
                    }
                    else
                    {
                        GetComponent<Item_Talkable>().enabled = true;
                        GetComponent<Item_Talkable>().CanTalk(true);

                    }
                }
            });
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InputMgr.GetInstance().StartOrStop(false);
            IsEnter = false;
        }
    }
}
