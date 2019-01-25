using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 spawn;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, 3, -6);
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * 30 * Time.deltaTime;

        if (Vector3.Distance(spawn, transform.position) >= 50)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("FireCol");
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
