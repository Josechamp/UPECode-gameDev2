using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    float startX;
    string mode;

    // Start is called before the first frame update
    void Start()
    {
        startX = this.transform.position.x;
        mode = "left";
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void move()
    {
        if (mode == "right")
        {
            //Debug.Log("Right");
            transform.Translate(Vector3.left * 15 * Time.deltaTime);

            if (transform.position.x < startX - 15)
                mode = "left";
        }
        else if (mode == "left")
        {
           // Debug.Log("Left");
            transform.Translate(Vector3.right * 15 * Time.deltaTime);

            if (transform.position.x > startX + 15)
                mode = "right";
        }
    }

    public void kill()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<SimpleCharacterControl>().Spawn();
        }

        if(other.gameObject.tag == "fireball")
        {

        }
    }
}
