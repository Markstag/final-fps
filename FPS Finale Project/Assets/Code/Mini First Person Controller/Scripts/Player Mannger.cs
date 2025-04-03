using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMannger : MonoBehaviour
{
    public int  maxHealth;
    public int currentHealth;

    public float AttackDelay ;
	public float AttackTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth=maxHealth;
        AttackTimer = AttackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        Health();

        AttackTimer -= Time.deltaTime;
		
		
			
 
		
    }

    void Health()
    {

        if (currentHealth <= 0)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            if (AttackTimer <=0)
            {
                currentHealth--;
                AttackTimer = AttackDelay;

            }
            

        }
        
    }

}
