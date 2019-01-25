using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject spawnPoint;
    private bool m_canShoot = false;
    private bool hasShot;
    public GameObject fireball;
    public const float SHOOT_SPEED = 300;
    private const float COOLDOWN_SECONDS = 2;
    private float timestamp = Time.time + COOLDOWN_SECONDS;

    Transform cameraTransform;

    void Start()
    {
        //cameraTransform = this.gameObject.transform;
        timestamp = Time.time;
    }

    void shootBullet()
    {
        if (timestamp <= Time.time) //shoot
        {
            timestamp = Time.time + COOLDOWN_SECONDS;
            GameObject tempObj = Instantiate(fireball);
            //Instantiate/Create Bullet

            //et position  of the bullet in front of the player
            tempObj.transform.position = transform.position + (Vector3.forward * 3) ;

            /*Get the Rigidbody that is attached to that instantiated bullet
            Rigidbody projectile = tempObj.GetComponent<Rigidbody>();

            //Shoot the Bullet 
            projectile.velocity = transform.position * SHOOT_SPEED;*/
        }
        else
        {
        }

    }

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            Spawn();
        }
        if (m_canShoot & Input.GetKey((KeyCode.F)))
        {
          shootBullet();
        }
        
    }
    
    public void Spawn()
    {
        transform.position = spawnPoint.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powrup"))
        {
            other.gameObject.SetActive(false);
            m_canShoot = true;
        }
    }

    
}
