using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class follow : MonoBehaviour
{
    Animator Zombianim;

    NavMeshAgent agent;



    public Transform player;



    public float health;
    public AudioSource sound;
    public AudioClip Follow;
    public AudioClip �evre;

    bool isplay = true;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Transform target;

    public float distance;


    public GameObject characterdestination;
    


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
        Zombianim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();

       
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.Translate(0, 0, Time.deltaTime * 2);
        distance = Vector3.Distance(transform.position, target.position);

        

        if (distance <= 25)
        {
            agent.destination = target.position;
            agent.enabled = true;
            Zombianim.SetTrigger("run");
            if (isplay)
            {
                
               sound.Stop();
               sound.clip = Follow;
               sound.Play();
                isplay = false;
            }
            
            
            
        }
        else
        {
            agent.SetDestination(characterdestination.transform.position);

            if (isplay == false)
            {
                sound.Stop();
                sound.clip = �evre;
                sound.Play();
                Zombianim.SetTrigger("faraway");
                isplay = true;
            }
            agent.enabled = false;
        }
    }


    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        Zombianim.SetFloat("punch", 1.2f);



        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Zombianim.SetFloat("punch", 0);

        Destroy(gameObject);
    }
}
