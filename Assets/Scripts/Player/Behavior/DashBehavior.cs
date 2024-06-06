using System.Drawing;
using UnityEngine;

public class DashBehavior : PlayerBehavior
{
    public override string Id => "dash";
    public override int weight => w;
    int w = 0;

    public float dashSpeed;
    public float dashTime;
    JumpBehavior jumpbeh;

    void Start() {
        jumpbeh = manager.Beh("jump") as JumpBehavior;
    }

    public override void BehUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            if (jumpbeh.isJumping) {
                Dash();
            } else {
                Dash();
                manager.animator.ResetTrigger("roll");
                manager.animator.SetTrigger("roll");
            }
        }
    }

    void Dash() {
        w = 11;

        MoveBehavior mb = manager.Beh("move") as MoveBehavior;

        mb.ForceRot();

        manager.plVelocity += transform.forward * (input ? dashSpeed : -dashSpeed);

        Invoke("EndDash", dashTime);
    }

    void EndDash() {
        w = 0;
        manager.plVelocity = new Vector3(0, manager.plVelocity.y);
    }
}