using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : EntityBase
{
    //기본 플레이어 (싱글톤)
    static public Player Local = null;
    private void Start() {
        Local = this;
    }

    void FixedUpdate()
    {
        //입력
        var v = GetAxisRaw(KeyCode.S, KeyCode.W);
        var h = GetAxisRaw(KeyCode.A, KeyCode.D);

        //이동 실행
        var vecFront = Vector3.zero;
        var vecRight = Vector3.zero;

        if (v > 0)
            vecFront = transform.forward;
        else if (v < 0)
            vecFront = -transform.forward;

        if (h > 0)
            vecRight = transform.right;
        else if (h < 0)
            vecRight = -transform.right;

        Move(vecFront + vecRight);
    }

    public override void EntityUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigid.velocity = Vector3.up * 10;
        }
    }

    float GetAxisRaw(KeyCode key1, KeyCode key2) {
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

    public override void OnDeath(int damage)
    {
        Debug.Log("죽었다-");
    }

    public override bool OnHurt(ref int damage, EntityBase attacker)
    {
        Debug.Log("아프다 - " + damage.ToString());

        return true;
    }
}
