using System.Drawing;
using UnityEngine;

public class JumpBehavior : PlayerBehavior
{
    public override string Id => "jump";
    public override int weight => 5;
    public float jumpPower;
    bool twice;
    public bool isJumping;
    float jumpTime;

    public override void BehUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (manager.IsGrounded() || !twice) {
                Jump();
            }
        }

        if (isJumping) {
            jumpTime += Time.deltaTime;

            if (manager.IsGrounded() && jumpTime >= 0.3f) {
                isJumping = false;
            }
        }
    }

    void Jump() {
        manager.animator.ResetTrigger("jump");
        manager.animator.SetTrigger("jump");

        manager.plVelocity.y = jumpPower;

        jumpTime = 0;
        isJumping = true;
    }
}