using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)] public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public float playerDist;
    public Vector3 playerPos;
    public bool isDetect=false;

    [HideInInspector] public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            float dstToTarget = Vector3.Distance(transform.position, target.position);

            // 시야 내에 있는 대상과의 각도 계산
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                // 장애물 확인
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    // 대상이 장애물에 가려져 있지 않은 경우
                    visibleTargets.Add(target);
                    playerPos = target.transform.position;
                    isDetect = true;
                }
                else
                {
                    // 대상이 장애물에 가려져 있는 경우
                    isDetect = false;
                }
            }
            else
            {
                // 대상이 시야 각도 내에 없는 경우
                isDetect = false;
            }
        }

        // 시야 내에 대상이 없는 경우 isDetect를 false로 설정
        if (visibleTargets.Count == 0)
        {
            isDetect = false;
        }
    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}