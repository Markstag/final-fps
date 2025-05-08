using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBullet : MonoBehaviour
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
        player = GameObject.Find("Enemy").transform;
        currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
