using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : HealthSystem
{
    public static PlayerManager Main { get; private set; }
    private CharacterController ch;
    public CharacterController chController => ch;
    [HideInInspector]
    public List<PlayerBehavior> behaviors = new();
    [SerializeField]
    private List<string> behaviorOrder;
    [SerializeField]
    private Vector3 boxSize;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask groundLayer;

    public Vector3 plVelocity;
    public GameObject pointV;
    public GameObject pointH;
    public int attackDamage;

    protected bool sprint, skill;
    public bool ground;
    public Animator animator;

    void Awake() {
        ch = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

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

        
        ground = IsGrounded();

        if (plVelocity.y < 0 && IsGrounded()) {
            plVelocity.y = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position + new Vector3(0, 1) - transform.up * maxDistance, boxSize);
    }

    public bool IsGrounded()
    {
        return Physics.BoxCast(transform.position + new Vector3(0, 1), boxSize, -transform.up, transform.rotation, maxDistance, groundLayer);
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

    public void SetMaxHealth(int val)
    {
        throw new NotImplementedException();
    }

    public int GetMaxHealth()
    {
        throw new NotImplementedException();
    }

    public void SetAtkDamage(int val)
    {
        throw new NotImplementedException();
    }

    public int GetAtkDamage()
    {
        throw new NotImplementedException();
    }
}
