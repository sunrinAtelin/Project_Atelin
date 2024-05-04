using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------
//�̰� ���� ������!!!! ������Ʈ �׽�Ʈ�� �÷��̾� �Դϴ� 
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

        //10�����ۼ������ �̵�(�����Ӵ��� �ƴ϶�)
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // z�� �̵�?
        transform.Translate(0, 0, translation);

        // y���̵�
        transform.Rotate(0, rotation, 0);
    }
}
