using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacObject : MonoBehaviour
{
    private int damaged=1000;
    BoxCollider collider;
    public int attacprogress
    {
      get=>damaged;
    }

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }

    // Start is called before the first frame update
    private void Attacked()
    {
            
    }
}
