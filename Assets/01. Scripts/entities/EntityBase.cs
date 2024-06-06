using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
    //이동 속도
    public float moveSpeed;
    //체력
    public int health;

    [SerializeField]
    //최대 체력
    protected int maxHealth;
    [SerializeField]

    public bool onGround;
    public bool isDeath, isMoving;

    [SerializeField]
    protected Vector3 feetOffset, ChestOffset, HeadOffset; //발, 몸통, 머리 감지용 오프셋
    [SerializeField]
    //콜라이더
    protected MeshCollider col;
    //물리
    protected Rigidbody rigid;

    private void Awake() {
        col = GetComponent<MeshCollider>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update() {
        onGround = OnGround();

        EntityUpdate();
    }

    //최대 체력은 수정할 상황이 많지 않으므로 getter setter 구문 사용
    public void SetMaxHealth(int val) {
        maxHealth = val;
    }

    public int GetMaxHealth() {
        return maxHealth;
    }

    //피해 입히는 함수 / 반환 값으로 피해 성공 여부 확인
    public bool Hurt(int damage, EntityBase attacker = null) {
        if (OnHurt(ref damage, attacker)) {
            health -= damage;

            if (health <= 0) {
                OnDeath(damage);
            }

            return true;
        }

        return false;
    }

    //땅 위에 있는지 여부
    protected bool OnGround() {
        var casts = Physics.RaycastAll(transform.position + feetOffset, Vector3.down, 0.2f);

        for (int i = 0; i < casts.Length; i++) {
            RaycastHit cast = casts[i];

            if ((LayerMask.GetMask("ground") & (1 << cast.transform.gameObject.layer)) != 0) {
                return true;
            }
        }

        return false;
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
    //피해를 입는 순간을 감지할때
    abstract public bool OnHurt(ref int damage, EntityBase attacker);
    //죽었을때
    abstract public void OnDeath(int damage);

    //update 함수를 이미 사용중이므로 여기에 구현
    abstract public void EntityUpdate();

    //오프셋 시각화
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;

        //바닥 판정 기준점
        Gizmos.DrawWireCube(transform.position + feetOffset, new Vector3(transform.localScale.x, -0.2f, transform.localScale.x));

        Gizmos.color = Color.red;

        //몸통 판정 기준점
        Gizmos.DrawWireCube(transform.position + ChestOffset, new Vector3(transform.localScale.x, -0.2f, transform.localScale.x));

        Gizmos.color = Color.green;

        //머리 판정 기준점
        Gizmos.DrawWireCube(transform.position + HeadOffset, new Vector3(transform.localScale.x, -0.2f, transform.localScale.x));

        Gizmos.color = Color.yellow;

        var ray = new Ray(transform.position + HeadOffset, transform.forward);

        //보고 있는 방향
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 2);

        Gizmos.color = Color.magenta;
    }
}
