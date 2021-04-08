using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;

    Rigidbody2D _rigidBody;

    Animator _animator;

	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
        Run();
        FlipSprite();
	}

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // value is betweeen -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, _rigidBody.velocity.y);
        _rigidBody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void FlipSprite()
    {
	    bool playerHasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;
	    if (playerHasHorizontalSpeed)
	    {
		    transform.localScale = new Vector2(Mathf.Sign(_rigidBody.velocity.x), 1);
	    }
    }
}
