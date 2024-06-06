using System.Drawing;
using UnityEngine;

public class JumpBehavior : PlayerBehavior
{
    public override string Id => "jump";
    public override int weight => 5;
    public float jumpPower;

    public override void BehUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            manager.plVelocity.y += jumpPower;
        }
    }
}