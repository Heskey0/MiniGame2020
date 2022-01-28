using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickAIControl : MonoBehaviour
{
    public Transform chickPos;
    public bool canMove = true;
    bool isMove = false;

    Rigidbody2D rb;
    ChickAni ani;
    Vector2 moveAxis;
    int MoveSpeed = 2;
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        ani = transform.GetChild(0).gameObject.GetComponent<ChickAni>();
        chickPos = GameObject.FindGameObjectWithTag("Player").transform.GetChild(2);
        StartCoroutine(RandomMove());
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) {
            StopCoroutine(RandomMove());
            moveAxis = Vector2.zero;
            transform.localPosition = Vector3.zero;
            Debug.Log("已清零");
        }
        else
        {
            ani.setSpSortingLayer(0);
        }
        ani.setAni("canMove", canMove);
        Move();
        SwitchChickAni();
        IsPicked();

    }

    void Move() {
        rb.velocity = moveAxis* MoveSpeed;

    }
    IEnumerator  RandomMove() {

        if (!isMove)
        {
            moveAxis.x = ((float)Random.Range(-10, 11)) / 10;
            moveAxis.y = ((float)Random.Range(-10, 11)) / 10;
            //Debug.Log(moveAxis);
        }
        else
        {
            moveAxis = Vector2.zero;
        }
        //for (int i = Mathf.Abs((int)(moveAxis.x * 10)); i > 0; i--)
        //{
        //    moveAxis.x -= Mathf.Abs(i)/(i*10);
        //    Debug.Log(moveAxis);
        //}
        //for (int i = (int)(moveAxis.y * 10); i > 0; i--)
        //{
        //    moveAxis.y -= Mathf.Abs(i) / (i * 10);
        //    Debug.Log(moveAxis);
        //}
        yield return new WaitForSeconds(3);
        isMove = !isMove;
        StartCoroutine(RandomMove());

    }

    void SwitchChickAni() {
        ani.setAni("IsWalk_R", moveAxis.x > 0);
        ani.setAni("IsWalk_L", moveAxis.x < 0);
    }

    void IsPicked() {
        if (ani.IsEnter)
        {
            EventCenter.GetInstance().AddEventListener<KeyCode>("某键按下", (key) =>
            {
                if (key == KeyCode.E)
                {
                    chickPos = GameObject.FindGameObjectWithTag("Player").transform.GetChild(2);
                    if (chickPos.childCount ==0)
                    {
                        canMove = false;
                        GameObject.Find("Chick").transform.SetParent(chickPos);
                        GameObject.Find("Chick").transform.position = chickPos.position;
                        ani.setSpSortingLayer(2);
                        if (ani != null)
                        {
                            ani.setAni("IsDrop");
                        }
                        InputMgr.GetInstance().StartOrStop(false);
                        return;
                    }
                }
            });
        }
    }
}
