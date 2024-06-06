using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chapter : MonoBehaviour
{
    public abstract Chapter Instance {get;}
    public int stage;
}
