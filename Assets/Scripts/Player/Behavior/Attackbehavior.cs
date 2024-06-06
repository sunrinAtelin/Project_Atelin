using System.Drawing;
using UnityEngine;

public class AttackBehavior : PlayerBehavior
{
    public override string Id => "attack";
    public override int weight => 5;

    public override void BehUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            Attack();
        }
    }

    void Attack() {
        manager.animator.ResetTrigger("attack");
        manager.animator.SetTrigger("attack");
    }
}