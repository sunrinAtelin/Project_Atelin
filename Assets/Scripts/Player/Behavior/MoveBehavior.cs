using System.Drawing;
using UnityEngine;

public class MoveBehavior : PlayerBehavior
{
    public override string Id => "move";
    public override int weight => 10;
    public float moveSpeed;
    public float faceSpeed;
    Vector3 moveDir;
    Vector3 rotTo;
    bool crunch;

    public override void BehUpdate()
    {
        moveDir = new Vector3(h, 0, v);
        var vecFront = Vector3.zero;
        var vecRight = Vector3.zero;

        if (Input.GetKey(KeyCode.C)) {
            crunch = true;
        } else {
            crunch = false;
        }

        manager.animator.SetBool("crunch", crunch);

        if (v > 0)
            vecFront = manager.pointH.transform.forward * Time.deltaTime;
        else if (v < 0)
            vecFront = -manager.pointH.transform.forward * Time.deltaTime;

        if (h > 0)
            vecRight = manager.pointH.transform.right * Time.deltaTime;
        else if (h < 0)
            vecRight = -manager.pointH.transform.right * Time.deltaTime;

        if (moveDir != Vector3.zero && inputTime > 0.06f)
        {
            rotTo = manager.pointH.transform.forward * v + manager.pointH.transform.right * h;
        }

        manager.animator.SetBool("moving", input);

        float speed = moveSpeed;

        if (crunch) {
            speed /= 2;
        }

        manager.chController.Move((vecFront + vecRight) * speed);

        FaceRotating();
    }

    public void ForceRot() {
        if (transform.forward != rotTo && rotTo != Vector3.zero) {
            Quaternion rotHBefore = manager.pointH.transform.rotation;
            Quaternion rotVBefore = manager.pointV.transform.rotation;
            transform.forward = rotTo;

            manager.pointH.transform.rotation = rotHBefore;
            manager.pointV.transform.rotation = rotVBefore;
        }
    }

    void FaceRotating() {
        if (transform.forward != rotTo && rotTo != Vector3.zero) {
            Quaternion rotHBefore = manager.pointH.transform.rotation;
            Quaternion rotVBefore = manager.pointV.transform.rotation;
            transform.forward = Vector3.Lerp(transform.forward, rotTo, faceSpeed * Time.deltaTime);

            manager.pointH.transform.rotation = rotHBefore;
            manager.pointV.transform.rotation = rotVBefore;
        }
    }
}