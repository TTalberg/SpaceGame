using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    public float speed = 5f;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public GameObject Explosion;

    public Text txtAmmo;
    private int ammocount;
    public Text txtHullInteg;
    private int hullcount;

    public int initAmmo = 50;

    private Rigidbody2D rb;


    public AudioSource missleLaunch;
    //public AudioSource bgMusic;

    // Use this for initialization
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        ammocount = initAmmo;
        txtAmmo.text = "Ammo: " + 50;



        hullcount = 3;
        txtHullInteg.text = "Lives: " + 3;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        //Debug.Log("Horizontal: " + moveH);
        // Debug.Log("Vertical: " + moveV);

        Vector2 motion = new Vector2(moveH, moveV);

        Move(motion);
            
           // rb.AddForce(motion * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
            //Debug.Log("Fire");
        }



    }


    void Move(Vector2 motion)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.255f;

        max.y = max.y - 0.225f;
        min.y = min.y + 0.225f;

        Vector2 pos = transform.position;
        pos += motion * speed * Time.deltaTime;

        // keep player in screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

    }
    

    void Fire()
    {
        if (ammocount > 0)
        {

            missleLaunch.Play();

            ammocount--;
            txtAmmo.text = "Ammo: " + ammocount;
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            // Vector2 bulletMotion = new Vector2(10f, 0f);
            //bullet.GetComponent<Rigidbody2D>().AddForce(bulletMotion * 30);
            // bullet.GetComponent<Rigidbody2D>().AddForce(bulletMotion * 30);
            Destroy(bullet, 6f);



        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bullet Hit a : " + other.tag);
        if (other.tag.Equals("boundary"))
        {
            Destroy(gameObject);
        }
        if (other.tag.Equals("enemy"))
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            hullcount--;
            txtHullInteg.text = "Lives: " + hullcount;
            Destroy(other.gameObject);
            Destroy(gameObject);

            respawn();

            if (other.gameObject.tag != "Player")
               


            GameObject.Destroy(gameObject);



            /*  */
        }
    }
    void respawn()
    {
        transform.position = Vector3.zero;

    }


}
