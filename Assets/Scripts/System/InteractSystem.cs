using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct Interaction {
    public string msg;
    public Action action;
}

public class InteractSystem : MonoBehaviour
{
    public static InteractSystem Instance {get; private set;}
    public GameObject tip;
    public Text tipText;

    private Interaction? state = null;
    

    void Awake() {
        Instance = this;
    }

    void Update() {
        if (state != null) {
            tip.gameObject.SetActive(true);
            tip.gameObject.SetActive(true);

            tipText.text = state.Value.msg;

            if (Input.GetKeyDown(KeyCode.F)) {
                ApplyInteract();
            }
        } else {
            tip.gameObject.SetActive(false);
        }
    }

    public void ApplyInteract() {
        state.Value.action();

        state = null;
    }
    
    public void Interact(string msg, Action act) {
        Interaction inter = new Interaction(){
            msg = msg,
            action = act,
        };

        state = inter;
    }
}
