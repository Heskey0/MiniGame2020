using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public LayerMask items;
    public float CircleRadius;

    [Header("判断")]
    public bool onItems;

    void Update()
    {
        onItems = Physics2D.OverlapCircle((Vector2)transform.position, CircleRadius, items);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, CircleRadius);
    }


}
