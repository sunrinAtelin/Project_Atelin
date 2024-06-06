using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static float GetAxisRaw(KeyCode key1, KeyCode key2) {
        float dir = 0f;

        if (Time.timeScale == 0f) return dir;
        if (Input.GetKey(key1))
        {
            dir = -1f;
        }

        if (Input.GetKey(key2))
        {
            dir = 1f;
        }

        return dir;
    }
}
