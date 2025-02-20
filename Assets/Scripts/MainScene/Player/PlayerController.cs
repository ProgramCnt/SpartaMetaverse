using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : BaseController
{

    SpriteRenderer playerSprite;

    private void Start()
    {
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movemnetDirection = new Vector2(horizontal, vertical).normalized;

        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            jumpStartY = playerSprite.transform.localPosition.y;
            isJump = true;
            jumpTime = 0f;
        }

        if (isJump)
        {
            jumpTime += Time.deltaTime * jumpSpeed;
            float spriteY = Mathf.PingPong(jumpTime, jumpForce);
            playerSprite.transform.localPosition = new Vector3(playerSprite.transform.localPosition.x, spriteY, 0);

            if (jumpTime >= jumpForce * 2)                                      //�����ѽð� ���� jump�� ������ 2�踸ŭ �Ǹ� ���̴� 0���� �Ǿ� �ٽ� �������� ��
            {
                isJump = false;
                playerSprite.transform.localPosition = new Vector3(0,0,0);
            }
        }
    }

}
