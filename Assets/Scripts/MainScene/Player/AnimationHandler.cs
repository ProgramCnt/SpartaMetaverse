using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int IsJump = Animator.StringToHash("IsJump");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        if (obj != null)
        {
            bool isMove = obj.magnitude > 0.5f;
            Vector2 lastDirection = obj.normalized;

            if (lastDirection != Vector2.zero) 
            {
                animator.SetFloat("PosX", lastDirection.x);
                animator.SetFloat("PosY", lastDirection.y);
            }
            animator.SetBool(IsMoving, isMove);
        }
        else
        {
            animator.SetBool(IsMoving, false);
        }
    }

    public void Jump()
    {
        animator.SetTrigger(IsJump);        //���� Ʈ���� �ߵ�
    }
}

public enum State
{
    IdleFront,
    IdleBack,
    IdleLeft,
    IdleRight,
    MoveFront,
    MoveBack,
    MoveLeft,
    MoveRight
}