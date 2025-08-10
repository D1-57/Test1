using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class enemiesControl : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Transform target;
    public Animator anime;
    bool isattack;
    public int health;
    
    bool isdead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isdead = false;
        health = 100;
        agent = gameObject.GetComponent<NavMeshAgent>();
        isattack = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (isdead)
            return;
            
        agent.SetDestination(target.position);
        anime.SetFloat("speed",agent.velocity.magnitude);
        if (Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance)
        {
            if (isattack ) 
            { 
                anime.SetTrigger("attack");
                
                
                isattack = false;
                StartCoroutine(cooldown());
            }

        }

        
    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(1.5f);
        
        isattack = true;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.5f);
        
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            health = health - 10;
            
            if (health <= 0)
            {
                isdead = true;
                anime.SetTrigger("die");
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
                agent.enabled = false;
                
                StartCoroutine(Death()); 
            }
            
        }
    }
    
}
