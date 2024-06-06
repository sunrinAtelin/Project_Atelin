using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Main { get; private set; }
    private CharacterController ch;
    public CharacterController chController => ch;
    [HideInInspector]
    public List<PlayerBehavior> behaviors = new();
    [SerializeField]
    private List<string> behaviorOrder;

    public Vector3 plVelocity;
    public GameObject pointV;
    public GameObject pointH;

    protected bool sprint, skill;

    void Awake() {
        ch = GetComponent<CharacterController>();

        Main = this;
        pointH.transform.rotation = transform.rotation;
    }

    public PlayerBehavior Beh(string id) {
        foreach (PlayerBehavior bh in behaviors) {
            if (bh.Id == id) {
                return bh;
            }
        }

        return null;
    }

    void Update() {
        CallBehUpdate();
        ShowOrder();

        chController.Move(plVelocity * Time.deltaTime);

        if (plVelocity.y < 0 && chController.isGrounded) {
            plVelocity.y = 0;
        }
    }

    public void IdleTime(float time) {
        var idle = Beh("idle") as IdleBehavior;

        idle.SetIdleTime(PlayerBehavior.topWeight + 1, time);
    }

    public void Idle(bool val) {
        var idle = Beh("idle") as IdleBehavior;

        idle.SetIdle(PlayerBehavior.topWeight + 1, val);
    }

    void ShowOrder() {
        behaviorOrder.Clear();

        foreach (PlayerBehavior bh in behaviors) {
            behaviorOrder.Add(bh.Id + ", weight: " + bh.weight.ToString() + (bh.onlyTop ? " onlyTop" : ""));
        }
    }

    void CallBehUpdate(){
        behaviors.Sort((a, b)=> b.weight-a.weight);

        bool top = true;
        foreach (PlayerBehavior bh in behaviors) {
            bh.BehForceUpdate();
            if (bh.onlyTop) {
                if (top) {
                    top = false;

                } else continue;
            }

            bh.BehUpdate();
        }
    }

    public bool IsMoving() {
        return true;
    }
}
