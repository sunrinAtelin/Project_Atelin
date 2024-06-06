using System.Drawing;
using UnityEngine;

public class DashBehavior : PlayerBehavior
{
    public override string Id => "dash";
    public override int weight => w;
    int w = 0;

    public float dashSpeed;
    public float dashTime;

    public override void BehUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            w = 11;

            MoveBehavior mb = manager.Beh("move") as MoveBehavior;

            mb.ForceRot();

            manager.plVelocity += transform.forward * (input ? dashSpeed : -dashSpeed);

            Invoke("EndDash", dashTime);
        }
    }

    void EndDash() {
        w = 0;
        manager.plVelocity = new Vector3(0, manager.plVelocity.y);
    }
}