using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movemnetDirection = Vector2.zero;

    public Vector2 MovementDirection { get { return movemnetDirection; } }

    protected Vector2 lookDirection = Vector2.zero;

    protected AnimationHandler animationHandler;

    private bool isJump = false;

    private float speed = 5f;

    private float jumpForce = 3f;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 velocity = rigidbody.velocity;
            velocity.y += jumpForce;
            rigidbody.velocity = velocity;
        }
    }

    protected virtual void FixedUpdate()
    {
        Movement(movemnetDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        direction *= speed;
        rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }
}
