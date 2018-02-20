using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShip : MonoBehaviour
{

    public GameObject My_explosion ;
    // [SerializeField] private uint scoreValue = 20;


    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float speedB;
    private float firetime;
    private GameObject playerlocation;

    //public AudioSource missleLaunch;



    // public Transform EnemybulletSpawn;
    // public AudioSource missleLaunch;
    private float timeElapsed;
    private float speed;
    void Start()
    {
        // killcount = 0;

    }

    private void Awake()
    {
       // playerlocation = GameObject.FindGameObjectsWithTag("Player");
    }

    private void FixedUpdate()
    {
        //int firetime = Random.Range(0, 60);
        if (Time.time % 3 < 0.00001)
        {
            EnemyFire();
            Debug.Log("Fire");

        }

    }        

    void EnemyFire() {

        {
            //  if (ammocount > 0)
            // {

            // missleLaunch.Play();
            speedB = (175f) * -1;
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(speedB, 0f));
           // bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(speedB, 0f));

            Destroy(bullet, 6f);



            // }

        }



    }

    void OnCollisionEnter2D(Collision2D other)
    {
   Debug.Log("somethingCollided");
       

        if (other.gameObject.tag == "bullet")
        {
            Explode();
            //GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
             Debug.Log("Was DESTROYED BY PLAYER");
            GameObject.Destroy(gameObject);
        }
        if (other.gameObject.tag == "spaceship"){
            Explode();
            //GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
            Debug.Log("Was DESTROYED BY PLAYER");
            GameObject.Destroy(gameObject);

        }
     

    }

   void Explode()
    {
       GameObject explosion =  (GameObject)Instantiate (My_explosion);
        explosion.transform.position = transform.position;


    }


    
        
    }