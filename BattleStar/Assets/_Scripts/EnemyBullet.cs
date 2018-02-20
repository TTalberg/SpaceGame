using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //int speed = -50;
  //  private Rigidbody2D body;

   // public AudioSource lazer;
    ShipController controller;

    private void Awake()
    {
       // lazer.Play();
    }


    // Use this for initialization
    void Start()
    {
    //    body = gameObject.GetComponent<Rigidbody2D>();

      

    }

    // Update is called once per frame
    void Update()
    {
        ///body.AddForce(transform.right * speed * Time.deltaTime);
        //txtKills.text = "killCount: " + killcount;
       // Debug.Log("IS THIS IN THE LOG");


        gameObject.GetComponent<Transform>().Rotate(
         new Vector3(0f, 0f, 3f));
      //  Destroy(bullet, 4f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Shot missle Hit: " + other.tag);
        if (other.tag.Equals("boundary"))
        {
            Destroy(gameObject);
        }
        if (other.tag.Equals("spaceship"))
        {

            

            Destroy(other.gameObject);
            Destroy(gameObject);

            transform.position = Vector3.zero;



            /*  */
        }
    }

}
