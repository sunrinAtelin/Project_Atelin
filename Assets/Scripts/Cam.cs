using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public static Cam Instance {get; private set;}
    [SerializeField]
    private float distance;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float zoomSpeed;
    private float dist;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 rotOffset;
    [SerializeField]
    private float speed;
    Vector2 mouse;
    [SerializeField]
    private float angleSpeed;
    public PlayerManager target;
    public bool HideCursor;
    public float rotX;
    public bool stopTrace;

    void Start()
    {
        Instance = this;
        dist = distance;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = !HideCursor;
        Cursor.lockState = HideCursor ? CursorLockMode.Locked : CursorLockMode.None;

        if (!stopTrace) {
            var pos = target.transform.position + offset + target.pointV.transform.forward * -dist;

            RaycastHit hit;
            if (Physics.Raycast(target.pointV.transform.position, -transform.forward, out hit, dist)) {
                pos = hit.point;
            }

            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(target.pointV.transform.rotation.eulerAngles + rotOffset);

            MouseControl();
            Zoom();
        }
    }

    void Zoom() {
        var scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        dist -= scroll;

        if (dist < 1f)
            dist = 1f;
        else if (dist > maxDistance)
            dist = maxDistance;
    }

    public void MouseControl() {
        mouse.x = Input.GetAxis("Mouse X");
        mouse.y = Input.GetAxis("Mouse Y");

        if (mouse.magnitude != 0) {
            var rotV = target.pointV.transform.rotation;
            var rotH = target.pointH.transform.rotation;
            rotX = rotV.eulerAngles.x + -mouse.y * angleSpeed;

            if (rotX < 90 && rotX > 80)
                rotX = 80;
            if (rotX < 310 && rotX > 200)
                rotX = 310;

            target.pointH.transform.rotation = Quaternion.Euler(0, rotH.eulerAngles.y + mouse.x * angleSpeed, rotH.z);
            target.pointV.transform.rotation = Quaternion.Euler(rotX, rotH.eulerAngles.y + mouse.x * angleSpeed, rotH.z);
        }
    }
}
