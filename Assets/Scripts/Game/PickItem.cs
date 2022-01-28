using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    public string pickName;
    bool IsEnter;
   
    GameObject item;
    PlayerControl playerCtrol;
    private void Start()
    {
        playerCtrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        item = this.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCtrol = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

            IsEnter = true;
        }
    }
    public void Update()
    {
        if (IsEnter)
        {
            //EventCenter.GetInstance().AddEventListener<KeyCode>("某键按下", (key) => {
                if (Input.GetKeyDown(KeyCode.E)&& playerCtrol.PickName == "")
                {
                    playerCtrol.PickName = pickName;
                    Destroy(item);
                }
            //});
        }

    }
    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsEnter = false;
        }
    }
}
