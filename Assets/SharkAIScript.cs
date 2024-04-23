using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SharkAIScript : MonoBehaviour
{
    private static SharkAIScript instance = null;
    private string currentState = "IdleState";
    private NavMeshAgent meshAgent;
    public Transform target;

    public float idleRange = 150;
    public float chaseRange = 70;
    public float attackRange = 10;

    public float sharkChangeTime;
    public float sharkChoice;

    //public GameObject attackCollider;

    public float distance;

    // Pathfinding
    public Transform pointOne;
    public bool SetOne;
    public Transform pointTwo;
    public bool SetTwo;
    public Transform pointThree;
    public bool SetThree;
    public Transform pointFour;
    public bool SetFour;
    public Transform pointFive;
    public bool SetFive;


    //

    void Start()
    {
        currentState = "IdleState";
        meshAgent = GetComponent<NavMeshAgent>();

        SetOne = true;
        SetTwo = false;
        SetThree = false;
        SetFour = false;
        SetFive = false;

        sharkChangeTime = Random.Range(10, 15);
        sharkChoice = Random.Range(1, 6);
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        
        sharkChangeTime -= Time.deltaTime;

        if (distance > idleRange)
        {
            // If AI is in Idle State
            currentState = "IdleState";
            meshAgent.speed = 3f;

            if (sharkChoice == 1)
            {
                SetOne = true;
                SetTwo = false;
                SetThree = false;
                SetFour = false;
                SetFive = false;
            }
            if (sharkChoice == 2)
            {
                SetOne = false;
                SetTwo = true;
                SetThree = false;
                SetFour = false;
                SetFive = false;
            }
            if(sharkChoice == 3)
            {
                SetOne = false;
                SetTwo = false;
                SetThree = true;
                SetFour = false;
                SetFive = false;
            }
            if (sharkChoice == 4)
            {
                SetOne = false;
                SetTwo = false;
                SetThree = false;
                SetFour = true;
                SetFive = false;
            }
            if (sharkChoice == 5)
            {
                SetOne = false;
                SetTwo = false;
                SetThree = false;
                SetFour = false;
                SetFive = true;
            }
            
   
            if (SetOne == true)
            {
                meshAgent.SetDestination(pointOne.position);
                
            }
            if (SetTwo == true)
            {
                meshAgent.SetDestination(pointTwo.position);
           
            }
            if (SetThree == true)
            {
                meshAgent.SetDestination(pointThree.position);
         
            }
            if (SetFour == true)
            {
                meshAgent.SetDestination(pointFour.position);
         
            }
            if (SetFive == true)
            {
                meshAgent.SetDestination(pointFive.position);
         
            }

            if (sharkChangeTime <= 0)
            {
                sharkChoice = Random.Range(1, 6);
                sharkChangeTime = Random.Range(10, 15);
            }

            //attackCollider.SetActive(false);
        }
        if (distance <= idleRange && distance > chaseRange)
        {
            // If AI is in Chasing State
            currentState = "ChaseState";
            meshAgent.SetDestination(target.position);
            meshAgent.speed = 5f;
            //attackCollider.SetActive(false);

        }
        if (distance <= chaseRange)
        {
            // If AI is in Attackibg State
            currentState = "AttackState";
            meshAgent.speed = 0f;
            //attackCollider.SetActive(true);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PointOne"))
        {
            SetOne = false;
            SetTwo = true;
            SetThree = false;
            SetFour = false;
            SetFive = false;
        }
        if (other.CompareTag("PointTwo"))
        {
            SetOne = false;
            SetTwo = false;
            SetThree = true;
            SetFour = false;
            SetFive = false;
        }
        if (other.CompareTag("PointThree"))
        {
            SetOne = false;
            SetTwo = false;
            SetThree = false;
            SetFour = true;
            SetFive = false;
        }
        if (other.CompareTag("PointFour"))
        {
            SetOne = false;
            SetTwo = false;
            SetThree = false;
            SetFour = false;
            SetFive = true;

        }
        if (other.CompareTag("PointFive"))
        {
            SetOne = true;
            SetTwo = false;
            SetThree = false;
            SetFour = false;
            SetFive = false;
        }
    }

    void Awake()
    {
        instance = this;
    }

    public static SharkAIScript Instance
    {
        get
        {
            return instance;
        }
    }
}
