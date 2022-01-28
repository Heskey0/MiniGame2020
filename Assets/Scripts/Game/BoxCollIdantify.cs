using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollIdantify : MonoBehaviour
{
    public bool IsPlayerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerControl>().isSave = true;
            IsPlayerEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerControl>().isSave = false;
            IsPlayerEnter = false;
        }
    }

}
