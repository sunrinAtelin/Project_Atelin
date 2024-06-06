using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Auto_stair : MonoBehaviour
{
    public GameObject stair1;
    public GameObject stair2;
    public GameObject stair3;
    public GameObject stair4;
    public GameObject stair5;
    public GameObject stair6;
    public GameObject stair7;

    private bool flag; 
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            if (stair1.transform.position.y <= 0.25f)
            {
                stair1.transform.Translate(0,0.003f,0);
               
            }
            if (stair2.transform.position.y <= 0.5f)
            {
                stair2.transform.Translate(0,0.003f,0);
            }
            if (stair3.transform.position.y <= 0.75f)
            {
                stair3.transform.Translate(0,0.003f,0);
               
            }
            if (stair4.transform.position.y <= 1f)
            {
                stair4.transform.Translate(0,0.003f,0);
            }
            if (stair5.transform.position.y <= 1.25f)
            {
                stair5.transform.Translate(0,0.003f,0);
            }
            if (stair6.transform.position.y <= 1.5f)
            {
                stair6.transform.Translate(0,0.003f,0);
               
            }
            if (stair7.transform.position.y <= 1.7f)
            {
                stair7.transform.Translate(0,0.003f,0);
            }
        }
        else
        {
            if (stair1.transform.position.y >= -0.3f)
            {
                stair1.transform.Translate(0,-0.001f,0);
               
            }
            if (stair2.transform.position.y >= -0.55f)
            {
                stair2.transform.Translate(0,-0.002f,0);
            }
            if (stair3.transform.position.y >= -0.8f)
            {
                stair3.transform.Translate(0,-0.003f,0);
               
            }
            if (stair4.transform.position.y >= -1.05f)
            {
                stair4.transform.Translate(0,-0.004f,0);
            }
            if (stair5.transform.position.y >= -1.3f)
            {
                stair5.transform.Translate(0,-0.005f,0);
            }
            if (stair6.transform.position.y >= -1.55f)
            {
                stair6.transform.Translate(0,-0.006f,0);
               
            }
            if (stair7.transform.position.y >= -1.8f)
            {
                stair7.transform.Translate(0,-0.007f,0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        flag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        flag = false;
    }
}
