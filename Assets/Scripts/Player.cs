using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    
    Rigidbody2D _rigidBody;
    Animator _animator;
    Collider2D _collider2D;
    
    float gravityScaleAtStart;

	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider2D = GetComponent<Collider2D>();
        gravityScaleAtStart = _rigidBody.gravityScale;
	}

	// Update is called once per frame
	void Update () {
        Run();
        ClimbLadder();
        Jump();
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
    
    private void ClimbLadder()
    {
	    if (!_collider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
	    {
		    _animator.SetBool("Climbing", false);
		    _rigidBody.gravityScale = gravityScaleAtStart;
		    return;
	    }

	    float controlThrow = Input.GetAxis("Vertical");
	    Vector2 climbVelocity = new Vector2(_rigidBody.velocity.x, controlThrow * climbSpeed);
	    _rigidBody.gravityScale = 0;
	    _rigidBody.velocity = climbVelocity;

	    bool playerHasVerticalSpeed = Mathf.Abs(_rigidBody.velocity.y) > Mathf.Epsilon;
	    _animator.SetBool("Climbing", playerHasVerticalSpeed);

    }
    
    private void Jump()
    {
	    if (!_collider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
	    {
		    return;
	    } 
	    if (Input.GetButtonDown("Jump"))
	    {
		    Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
		    _rigidBody.velocity += jumpVelocityToAdd;
	    }
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
