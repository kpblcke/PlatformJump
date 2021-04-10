using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if (IsFacingRight())
        {
            _rigidbody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(_rigidbody2D.velocity.x)), 1f);
    }
}
