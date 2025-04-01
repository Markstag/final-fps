using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public bool canTeleport;
    public bool canBreak;
    public bool canPierce;
    public bool canRicochet;
    public bool canTime;
    public Transform player;

    public int  maxHealth;
    public int currentHealth;



    public float frames;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, frames);
        player = GameObject.Find("Player").transform;
        currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && canPierce)
        {
          Destroy(other.gameObject);

          currentHealth--;

         if (currentHealth <= 0)
         {
             Destroy(this.gameObject);
         }    
        }

        if (canTime)
        {
   
        }

        if (!other.gameObject.CompareTag("Enemy") && canRicochet)
        {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }  
        }

        if (other.gameObject.CompareTag("Teleport") && canTeleport)
        {
            player.position = transform.position;
        }


        if (other.gameObject.CompareTag("Break") && canBreak)
        {
            Destroy(other.gameObject);
        }

        if (!other.gameObject.CompareTag("Player") && !canPierce)
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy") )
        {
            Destroy(other.gameObject);
        }
    
    }
}
