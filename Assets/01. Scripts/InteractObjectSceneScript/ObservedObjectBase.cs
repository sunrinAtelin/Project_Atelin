using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObservedObjectBase : MonoBehaviour
{

    protected float ProgressSpeed = 10.0f, ProgressMinusSpeed = -3.0f;

   protected float progress = 0.0f;//점령 정도
    protected BoxCollider boxcolider;
    protected bool done = false;
    public bool areadone { get => done; }

    [SerializeField] protected OccupyObserveScript observe;

    // Start is called before the first frame update
    void Start()
    {
        boxcolider = GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        progress = 0.0f;
        done = false;
    }
}
