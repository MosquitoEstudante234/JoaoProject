using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public enum MonsterAI
{
    Break, Patrol, Chase
}
[RequireComponent(typeof(NavMeshAgent))]

public class BlindCreature : MonoBehaviour
{
    public static BlindCreature Instance;
    public Transform[] patrolPoint;
    public UnityEvent OnPatrolling, OnChasing, OnBreak;
    public Collider detectArea;
    public NavMeshAgent agent;
    public bool isAngel;
    public bool seekPlayer;
    [Header("Identifier")]
    public Transform playerPos, vision;
    RaycastHit hit;

    [Header("StateMachine")]
    MonsterAI monsterAI;
    int pointsToPatrol;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        OnPatrolling.Invoke();
        agent.speed = 0;
    }



       

    private void Update()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            agent.speed = 0;
            MonsterRun.CanRun = false;
        }

        if (Input.GetButtonUp("Jump"))
        {
            agent.speed = 0;
            MonsterRun.CanRun = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(TimeToAttack());
        }

        print(monsterAI);
        if (isAngel)
        {
            if (seekPlayer)
            {
                agent.SetDestination(playerPos.position);
                return;
            }
        }
        if (Physics.Linecast(vision.position, playerPos.position, out hit))
        {
            if (hit.distance >= 10)
            {
                return;
            }
            if (hit.collider.CompareTag("Player"))
            {
                print(hit.collider.name);
                if (!monsterAI.Equals(MonsterAI.Chase))
                {
                    SetMonsterAI(MonsterAI.Chase);
                }
                agent.SetDestination(playerPos.position);
            }
        }
        if (monsterAI.Equals(MonsterAI.Chase))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                monsterAI = MonsterAI.Patrol;
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
        if(isAngel)
        {
            return;
        }
        agent.SetDestination(patrolPoint[pointsToPatrol].position);
        pointsToPatrol++;
        if (pointsToPatrol >= patrolPoint.Length)
        {
            pointsToPatrol = 0;
        }
    }
    public void SetMonsterAI(MonsterAI state)
    {
        monsterAI = state;
        switch (monsterAI)
        {
            case MonsterAI.Break:

                OnBreak.Invoke();
                break;
            case MonsterAI.Patrol:
                NextPointFixedPoint();
                OnPatrolling.Invoke();
                break;
            case MonsterAI.Chase:
                OnChasing.Invoke();
                break;
        }
    }
    public IEnumerator TimeToAttack()
    {
        yield return new WaitForSeconds(0.1f);
        agent.speed = 15;
        MonsterRun.CanRun = true;
    }
}