using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFoodDown : MonoBehaviour
{
    private List<Transform> Fruits;
    void Start()
    {
        Fruits = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Fruits.Add(transform.GetChild(i));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            InputMgr.GetInstance().StartOrStop(true);
            EventCenter.GetInstance().AddEventListener<KeyCode>("某键按下",(key)=> {
                Debug.Log(Fruits[0]);
                if (key == KeyCode.E&&Fruits.Count>0)
                {
                    Fruits[0].gameObject.GetComponent<Animator>().enabled= true;
                    Fruits[1].gameObject.GetComponent<Animator>().enabled = true;
                }
            });
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        InputMgr.GetInstance().StartOrStop(false);
    }
}
