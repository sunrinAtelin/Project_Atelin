using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class DetectingEntity : EntityBase
{
    private FieldOfView fov;
    private GameObject player;

    NavMeshAgent agent;
    LineRenderer line;

    public Vector3 firePoint;
    public Vector3 targetPoint;
    public float lineWidth;

    public bool isReturned = false;
    public Vector3 destination;
    public Vector3 returnPos;

    public float playerDistence;
    public Vector3 playerPosition;

    public float view;
    public bool isDetecting;

    [Range(0,100)] public float rate;
    public float multiple;

    public bool isCommon;
    public bool isSerching;
    public bool isFinding;
    public bool isFighting;
    private void Start()
    {
        fov = GameObject.Find("enemy").GetComponent<FieldOfView>();
        agent=GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();

        player = PlayerManager.Main.gameObject;
    }
    private void FixedUpdate()
    {
        playerDistence = PlayerDist(player.transform.position);
        playerPosition = fov.playerPos;
        view = fov.viewRadius;
        isDetecting = fov.isDetect;

        rate = Mathf.Clamp(rate, 0f, 100f);

        EnemyStatus(rate);
        AlarmRate();
    }
    private void EnemyStatus(float rate)
    {
        isFighting = (rate == 100f);
        isSerching = (rate >= 60f && rate < 100f);
        isCommon = (rate < 60f);
    }
    private float PlayerDist(Vector3 pos)
    {
        float distence;
        distence = (this.transform.position - pos).magnitude;
        return distence;
    }
    private void AlarmRate()
    {
        if (isFighting)
        {
            AttackPlayer();
        }
        else if (!isDetecting)
        {
            if (isCommon)
            {
                rate -= Mathf.Clamp(PlayerDist(player.transform.position), 0f, view) / (rate*1.5f);
            }
            else if(isSerching)
            {
                if (!isFinding)
                {
                    destination = playerPosition;
                }
                SearchingPlayer();
                //rate -= Mathf.Clamp(PlayerDist(player.transform.position), 0f, view) / (rate * 1.5f);
            }
        }
        else if (rate <= 100f)
        {
            rate += (view-playerDistence) / multiple;
        }
    }
    private void SearchingPlayer()
    {
        isFinding = true;
        if(returnPos.magnitude == 0f)
        {
            returnPos = this.transform.position;
        }
        if (playerDistence <= 2f)
        {
            destination = returnPos;
            isReturned= true;
        }
        agent.SetDestination(destination);
        if(this.transform.position == returnPos && isReturned)
        {
            returnPos = new Vector3(0,0,0);
            isFinding= false;
            rate = 59.9f;
            isReturned= false;
        }
    }
    private void AttackPlayer()
    {
        fov.viewAngle = 360f;
        view = 15f;
        agent.isStopped= true;
        isFinding= false;
        if (isDetecting)
        {
            StartCoroutine(Bullet());
        }
        else
        {
            StopCoroutine(Bullet());
            lineWidth = 0.02f;
            line.startWidth = line.endWidth = 0;
            agent.SetDestination(player.transform.position);
        }
    }
    IEnumerator Bullet()
    {
        transform.LookAt(player.transform.position);
        line.positionCount = 2;
        line.startWidth = line.endWidth = lineWidth;
        line.SetPosition(0, this.transform.position);//firePoint
        line.SetPosition(1, player.transform.position);//targetPoint
        if (lineWidth <= 0.05f)
        {
            lineWidth += 0.00005f;
            line.startWidth = line.endWidth = lineWidth;
            Debug.Log(lineWidth);
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(1f);
            PlayerManager.Main.Hurt(AttackDamage);
            Debug.Log("shot");
            line.startWidth = line.endWidth = 0f;
            lineWidth = 0.02f;
        }
        yield break;
    }

    public override void EntityUpdate()
    {
    }
}
