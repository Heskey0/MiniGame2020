using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickAni : MonoBehaviour
{

    Animator ani;
    public bool IsEnter;
    public bool IsDropFinish =false;


    SpriteRenderer sp;

    void Start()
    {
        ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    public void setAni(string name, bool IsAni) {
        ani.SetBool(name,IsAni);
    }
    public void setAni(string name)
    {
        ani.SetTrigger(name);
    }
    public void setSpSortingLayer(int id)
    {
        sp = GameObject.FindWithTag("ChickView").GetComponent<SpriteRenderer>();
        sp.sortingOrder = id;
    }

    public void CheckIsDropFromHead() {

        IsDropFinish = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InputMgr.GetInstance().StartOrStop(true);
            IsEnter = true;
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
    //public void SetFlip(float f)
    //{
    //    sp.flipX = f > 0;
    //}
}
