using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnContact : MonoBehaviour
{

    public GameObject Explosion;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            GameObject.Instantiate(Explosion, transform.position, Quaternion.identity);
            Debug.Log("Was DESTROYED BY PLAYER");
            GameObject.Destroy(gameObject);
        }
        if (other.gameObject.tag == "spaceship")
        {
            GameObject.Instantiate(Explosion, transform.position, Quaternion.identity);
            Debug.Log("Was DESTROYED BY PLAYER");
            GameObject.Destroy(gameObject);



        }

    }
}