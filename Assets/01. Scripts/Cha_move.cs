using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cha_move : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody characterRigidbody;
    private float xRotate, yRotate, xRotateMove, yRotateMove; 
    public float rotateSpeed = 500.0f;
    void Start(){
        characterRigidbody = GetComponent<Rigidbody>();
    }
 
    void Update(){

        yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

        yRotate = transform.eulerAngles.y + yRotateMove;
        //xRotate = transform.eulerAngles.x + xRotateMove; 
        
        xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정
            
        transform.eulerAngles = new Vector3(0, yRotate, 0);
 
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
       
    }
}
