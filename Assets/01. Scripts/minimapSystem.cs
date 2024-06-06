using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject small_minimap;
    public GameObject big_minimap;
   

    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        small_minimap.SetActive(true);
        big_minimap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (count % 2 != 0)
            {
                small_minimap.SetActive(false);
                big_minimap.SetActive(true);
                count++;
            }
            else
            {
                
                                                     small_minimap.SetActive(true);
                big_minimap.SetActive(false);
                count++;
            }
        }
    }

  

}
