using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBase : HealthSystem
{
    //이동 속도
    public float moveSpeed;
    [SerializeField]

    public bool onGround;
    public bool isDeath, isMoving;

    private Vector3 boxSize;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private LayerMask groundLayer;
    //물리
    protected Rigidbody rigid;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update() {
        onGround = IsGrounded();

        EntityUpdate();
    }

    //최대 체력은 수정할 상황이 많지 않으므로 getter setter 구문 사용
    public void SetMaxHealth(int val) {
        maxHealth = val;
    }

    public int GetMaxHealth() {
        return maxHealth;
    }

    //땅 위에 있는지 여부
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position + new Vector3(0, 1) - transform.up * maxDistance, boxSize);
    }

    public bool IsGrounded()
    {
        return Physics.BoxCast(transform.position + new Vector3(0, 1), boxSize, -transform.up, transform.rotation, maxDistance, groundLayer);
    }

    //낑김 방지 처리된 이동 함수
    public void Move(Vector3 direction) {
        var moveVec = direction * moveSpeed * Time.deltaTime;
        moveVec.y += rigid.velocity.y;

        rigid.velocity = moveVec;
    }

    virtual public int CalcAtkDamage(int damage){ //피해량 관련 연산시
        return damage;
    }

    //update 함수를 이미 사용중이므로 여기에 구현
    abstract public void EntityUpdate();
}
