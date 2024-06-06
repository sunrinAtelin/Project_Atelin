// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;
// public class Auto_door : MonoBehaviour
// {
//     public GameObject right;
//     public GameObject menupanel;
//     public GameObject left;
//     private bool flag = false;
    
//     // Start is called before the first frame update
//     void Start()
//     {   
//         menupanel.SetActive(true);
//         left.transform.position = new Vector3(0, 1.5f, 0);
//         right.transform.position = new Vector3(2f, 1.5f, 0);

//     }

//     // Update is called once per frame
//     void Update()
//     {
   
//         print(flag);
//         if (flag == true)
//         {
//             if (left.transform.position.x >= -1.5f)
//             {
//                 left.transform.Translate(-0.001f,0,0);
//             }

//             if (right.transform.position.x <= 3.5f)
//             {
//                 right.transform.Translate(0.001f,0,0);
//             }
          
//         }
//         else if (flag == false)
//         {
//             if (left.transform.position.x <= 0f)
//             {
//                 left.transform.Translate(0.001f,0,0);
//             }

//             if (right.transform.position.x >= 2f)
//             {
//                 right.transform.Translate(-0.001f,0,0);
//             }
//         }
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         flag = true;
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         flag = false;
//     }
// }
