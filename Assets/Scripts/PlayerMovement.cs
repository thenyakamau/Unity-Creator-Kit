using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rdBody;
    private Animator animator;
    private SpriteRenderer sprite;

    private float directionX = 0f;
    private float directionY = 0f;

    private enum MovementState { idle, moveHorizontal, moveUp, moveDown }

    [SerializeField] private float movementSpeed = 7f;

    // Start is called before the first frame update
    private void Start()
    {
        rdBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionY = Input.GetAxisRaw("Vertical");

        float newPositionX = directionX * movementSpeed;
        float newPositionY = directionY * movementSpeed;

        rdBody.velocity = new Vector2(newPositionX, newPositionY);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState currentState = MovementState.idle;

        if (directionX > 0f)
        {
            currentState = MovementState.moveHorizontal;
            sprite.flipX = true;
        }
        else if (directionX < 0f)
        {
            currentState = MovementState.moveHorizontal;
            sprite.flipX = false;
        }

        if (directionY > 0f)
            currentState = MovementState.moveUp;
        else if (directionY < 0f)
            currentState = MovementState.moveDown;
        

        int stateValue = (int)currentState;
        animator.SetInteger("state", stateValue);
    }
}
