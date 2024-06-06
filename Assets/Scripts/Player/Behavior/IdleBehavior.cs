using UnityEngine;

public class IdleBehavior : PlayerBehavior
{
    public override string Id => "idle";

    private int w = 0;
    public override int weight => w;

    public override void BehUpdate()
    {
    }

    public void SetIdle(int order, bool val) {
        if (val) {
            w = order;
        } else {
            w = 0;
        }
    }
    public void SetIdleTime(int order, float time) {
        w = order;

        Invoke("EndIdle", time);
    }

    void EndIdle(){
        w = 0;
    }
}