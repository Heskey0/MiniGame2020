using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public bool canMove = true;
    public bool isSave = false ;
    public string PickName = "";
    public GameObject Item = null;


    Vector2 moveAxis;
    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sp;

    AudioSource walkAudio = null;
    void Start()
    {
        //获取组件
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        moveAxis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (!canMove)
            moveAxis = Vector2.zero;

        Move();
        AniSwitch();
        if (!isSave)
        {
            Drop();
        }
        PickItem();

    }
    //移动
    void Move()
    {

        rb.velocity = moveAxis * moveSpeed;
        if (rb.velocity != Vector2.zero && walkAudio == null)
        {
            walkAudio =  AudioMgr.GetInstance().PlaySoundEfect("草地行走",true);
        }
        else if (rb.velocity == Vector2.zero)
        {
            AudioMgr.GetInstance().StopSound(walkAudio);
        }

    }

    //动画控制
    void AniSwitch()
    {
        //检测是否左右移动
        ani.SetBool("IsSideWalk_R", moveAxis.x > 0);
        ani.SetBool("IsSideWalk_L", moveAxis.x < 0);
        ani.SetBool("IsBackWalk", moveAxis.y > 0);
        ani.SetBool("IsFrontWalk", moveAxis.y < 0);
    }

    void PickItem()
    {
        if (PickName != ""&&Item == null)
        {
            Item =  ResMgr.GetInstance().Load<GameObject>("PickItem/" + PickName);
            Item.transform.parent = transform.GetChild(1);
            Item.transform.localPosition = Vector3.zero;
        }

    }
    public void Drop() {
        if (PickName != "" && Input.GetKeyDown(KeyCode.E)&& Item != null)
        {
            if (Item.tag == "Chick")
            {
                Item.GetComponent<ChickAIControl>().canMove = true;
            }
            Item.transform.parent = null;
            Item = null;
            PickName = "";
        }
    }
    public void SaveFood() {
            Destroy(Item);
            Item = null;
            PickName = "";
    }

    
}
