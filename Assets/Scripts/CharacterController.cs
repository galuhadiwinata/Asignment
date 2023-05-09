using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Cache")]
    [SerializeField] private Animator anim;
    [SerializeField] private CharacterAnimation ca;
    [SerializeField] private SpriteRenderer sr;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 1f;

    [Header("Status")]
    [SerializeField] private AnimationState curAnimState;
    [SerializeField] private Vector2 desiredMoveDirection;
    [SerializeField]private bool isMoving;

    private enum AnimationState
    {
        Idle,
        Move
    }

    private void Start()
    {
        curAnimState = AnimationState.Idle;
    }

    private void Update()
    {
        GetInput();
        Move();
        Animate();
    }

    private void GetInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        desiredMoveDirection = new Vector2(
            horizontal,
            vertical
        );

        isMoving = (desiredMoveDirection != Vector2.zero);
        sr.flipX = desiredMoveDirection.x > 0 ? false : desiredMoveDirection.x < 0 ? true : sr.flipX;
    }

    private void Move()
    {
        transform.position += new Vector3(desiredMoveDirection.x, desiredMoveDirection.y, 0) * Time.deltaTime * movementSpeed;
    }

    private void Animate()
    {
        if (!isMoving && curAnimState != AnimationState.Idle)
        {
            anim.CrossFade(CharacterAnimation.strAnimIdle, 0);
            curAnimState = AnimationState.Idle;
        }
        else if (isMoving && curAnimState != AnimationState.Move)
        {
            anim.CrossFade(CharacterAnimation.strAnimMove, 0);
            curAnimState = AnimationState.Move;
        }
    }
}
