using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehavior : MonoBehaviour
{
    protected PlayerManager manager;
    [HideInInspector]
    public static int topWeight;
    public abstract string Id { get;}
    public abstract int weight { get;}
    public bool onlyTop;
    protected float v, h;
    public bool input;
    public float inputTime;

    void Awake() {
        manager = GetComponent<PlayerManager>();
        manager.behaviors.Add(this);

        if (weight > topWeight)
            topWeight = weight;
    }

    void Update() {
        v = Utilities.GetAxisRaw(KeyCode.S, KeyCode.W);
        h = Utilities.GetAxisRaw(KeyCode.A, KeyCode.D);

        if (input) {
            if (v == 0 && h == 0) {
                InputEnd();
                input = false;
            }

            inputTime += Time.deltaTime;
        } else {
            if (v != 0 || h != 0) {
                InputStart();
                input = true;
            }

            inputTime = 0;
        }
    }

    public abstract void BehUpdate();
    public virtual void BehForceUpdate(){}
    public virtual void InputEnd(){}
    public virtual void InputStart(){}
    public virtual void OnCancel(){}
}
