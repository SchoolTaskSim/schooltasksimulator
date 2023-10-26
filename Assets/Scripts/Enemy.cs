using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent ai;
    [SerializeField] float PosTime;
    [SerializeField] Transform[] posPoints;
    int posInt;
    Vector3 dest;

    private void Start()
    {

        ai = GetComponent<NavMeshAgent>();
        posInt = Random.Range(0, posPoints.Length);
        StartCoroutine(GosPosPoint());


    }

    private void Update()
    {
        dest = posPoints[posInt].position;
        ai.SetDestination(dest);
    }

    IEnumerator GosPosPoint()
    {
        yield return new WaitForSeconds(PosTime);
        posInt = Random.Range(0, posPoints.Length);
        StartCoroutine(GosPosPoint());
    }
}
