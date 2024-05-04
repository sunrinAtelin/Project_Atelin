using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------
//이거 쓰지 마세요!!!! 오브젝트 테스트용 플레이어 입니다 
//----------------------------------------------------------

public class TestPlayerScript : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    float horizontal, vertical;
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed; 
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        //10미터퍼세컨드로 이동(프레임단위 아니라)
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // z축 이동?
        transform.Translate(0, 0, translation);

        // y축이동
        transform.Rotate(0, rotation, 0);
    }
}
