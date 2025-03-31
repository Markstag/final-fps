using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool canTeleport;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Teleport") && canTeleport)
        {
            player.position = transform.position;
        }

        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    
    }
}
