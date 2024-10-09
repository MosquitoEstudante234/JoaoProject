using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public enum MonsterAIs
{
    Break, Patrol, Chase
}
[RequireComponent(typeof(NavMeshAgent))]

public class Creature : MonoBehaviour
{
    public Transform[] patrolPoint;
    public UnityEvent OnPatrolling, OnChasing, OnBreak;

    NavMeshAgent agent;
    [Header("Radius")]
    [SerializeField] float SetRadius;

    [Header("Identifier")]
    public Transform playerPos, vision;
    RaycastHit hit;

    [Header("StateMachine")]
    MonsterAIs monsterAIs;

    public bool CanPatrol;
    int lastPoint;
    int pointsToPatrol;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        OnPatrolling.Invoke();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            agent.speed = 1f;
        }
        if (Input.GetButtonUp("Jump"))
        {
            agent.speed = 10f;
            OnPatrolling.Invoke();
        } 

        print(monsterAIs);

        if (Physics.Linecast(vision.position, playerPos.position, out hit))
        {
            if (hit.distance >= 10)
            {
                return;
            }
            if (hit.collider.CompareTag("Player"))
            {
                print(hit.collider.name);
                if (!monsterAIs.Equals(MonsterAIs.Chase))
                {
                    SetMonsterAI(MonsterAIs.Chase);
                    FindObjectOfType<AudioManager>().Play("ChaseScream");
                }
                agent.SetDestination(playerPos.position);
            }
        }

        if (monsterAIs.Equals(MonsterAIs.Chase))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                monsterAIs = MonsterAIs.Patrol;
                NextPointFixedPoint();
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PatrolPoint"))
        {
            NextPointFixedPoint();
            print(pointsToPatrol);
        }
    }
    public void NextPointFixedPoint()
    {
        agent.SetDestination(patrolPoint[pointsToPatrol].position);
        pointsToPatrol++;
        if (pointsToPatrol >= patrolPoint.Length)
        {
            pointsToPatrol = 0;
        }
    }

    IEnumerator BreakTime()
    {
        yield return new WaitForSeconds(2);
        monsterAIs = MonsterAIs.Patrol;
        StopAllCoroutines();

    }

    public void SetMonsterAI(MonsterAIs state)
    {
        monsterAIs = state;
        switch (monsterAIs)
        {
            case MonsterAIs.Break:

                OnBreak.Invoke();
                break;
            case MonsterAIs.Patrol:
                NextPointFixedPoint();
                OnPatrolling.Invoke();
                break;
            case MonsterAIs.Chase:
                OnChasing.Invoke();
                break;
        }
    }
}

