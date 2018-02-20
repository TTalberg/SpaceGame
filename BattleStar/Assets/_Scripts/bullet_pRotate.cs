using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bullet_pRotate : MonoBehaviour
{
    int speed = 400;
    private Rigidbody2D body;
    // private int killcount;
    // public Text txtKills;

    ShipController controller;
    GameController gControl;
    public GameObject Explosion;

    // Use this for initialization
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        gControl = GameObject.Find("TheGame").GetComponent<GameController>();
    

    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(transform.right * speed * Time.deltaTime);
        //txtKills.text = "killCount: " + killcount;



        //gameObject.GetComponent<Transform>().Rotate(
        //  new Vector2(30f, 0f));
        // Destroy(bullet, 1f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Shot missle Hit: " + other.tag);
        if (other.tag.Equals("boundary"))
        {
            Destroy(gameObject);
        }
        if (other.tag.Equals("enemy"))
        {   gControl.Score++; 
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);
        }
        if (other.tag.Equals("asteroid"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);
        }
           // Instantiate(Explosion, transform.position, transform.rotation);
            Debug.Log("should be score here");
          






            /*  */
        
    }

}
