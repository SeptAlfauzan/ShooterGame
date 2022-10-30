using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class musuh : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    
    public GameObject target;
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 5);
        AttackPlayer();    
    }
     private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bomb");
    }
    void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile,transform.position, Quaternion.identity).GetComponent<Rigidbody>();
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


}
