using System.Drawing;
using UnityEngine;

public class GravityBehavior : PlayerBehavior
{
    public override string Id => "gravity";
    public override int weight => 1;
    public float gravityScale;

    public override void BehUpdate()
    {
        if (!manager.IsGrounded())
            manager.plVelocity.y -= gravityScale * Time.deltaTime;
    }
}