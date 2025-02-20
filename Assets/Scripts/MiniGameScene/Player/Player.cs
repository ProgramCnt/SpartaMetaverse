using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody;

    public float flapForce = 5f;
    public float speed = 3f;
    public bool isDie = false;
    float deathCoolDown = 0f;

    bool isFlap = false;

    GameManager gameManager;
    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        uiManager = UIManager.Instance;

        Time.timeScale = 0f;

        animator = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            if(deathCoolDown <= 0)
            {
                
            }
            else
            {
                deathCoolDown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (!gameManager.isGameStart)
                {
                    gameManager.isGameStart = true;
                    uiManager.HideResultCanvas();               //인게임 기능 활성화
                    Time.timeScale = 1;
                    return;
                }
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDie)
        {
            return;
        }

        Vector3 velocity = rigidbody.velocity;
        velocity.x = speed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((rigidbody.velocity.y * 7), -90, 90);         //최소 -90에서 최대 90까지 캐릭터의 속도 * 7 만큼 각도를 설정하기
        transform.rotation = Quaternion.Euler(0,0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDie)
        {
            return;
        }

        isDie = true;
        deathCoolDown = 1f;

        animator.SetBool("IsDie", true);
        gameManager.GameOver();
    }
}
