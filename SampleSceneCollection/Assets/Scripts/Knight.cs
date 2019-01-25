using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Vector3 origin;
    Vector3 spawn;
    bool rotating;
    bool following;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position + new Vector3(0, 3, 0);
        spawn = transform.position;
        rotating = true;
        following = false;

        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(rotating)
            Rotate();

        if (following)
            Follow();

        detectPlayer();

    }

    void detectPlayer()
    {
        //Raycast 
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(origin, transform.TransformDirection(Vector3.forward), out hit, 25f))
        {
            Debug.DrawRay(origin, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");

            if (hit.collider.gameObject.tag == "Player")
            {
                rotating = false;
                following = true;
            }
        }
        else
        {
            Debug.DrawRay(origin, transform.TransformDirection(Vector3.forward) * 25f, Color.white);
            //Debug.Log("Did not Hit");
        }
    }

    void Rotate()
    {
        this.gameObject.transform.Rotate(Vector3.up * 100 * Time.deltaTime);

    }

    void Follow()
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * 30 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<SimpleCharacterControl>().Spawn();
            following = false;
            transform.position = spawn;
            rotating = true;
        }

        if (other.gameObject.tag == "fireball")
        {

        }
    }
}
