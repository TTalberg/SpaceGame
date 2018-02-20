

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Marauder1 : MonoBehaviour


{

    public GameObject My_explosion;
    // [SerializeField] private uint scoreValue = 20;


    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float speedB;
    private float firetime;
    private GameObject playerlocation;

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
        int firetime = Random.Range(0, 12);
        if (firetime == 1)
        {
            EnemyFire();
            Debug.Log("Fire");

        }

    }

    void EnemyFire()
    {

        {
            //  if (ammocount > 0)
            // {

            // missleLaunch.Play();
            speedB = (150f) * -1;
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(speedB, 0f));


            Destroy(bullet, 8f);



            // }

        }



    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("somethingCollided");
        if (other.gameObject.tag == "bullet")
        {
            Explode();
            Debug.Log("Was DESTROYED BY PLAYER");
            GameObject.Destroy(gameObject);
        }
        if (other.gameObject.tag == "spaceship")
        {
            Explode();
            Debug.Log("Was DESTROYED BY PLAYER");
            GameObject.Destroy(gameObject);

        }
    }


        void Explode()
        {
            GameObject explosion = (GameObject)Instantiate(My_explosion);
            explosion.transform.position = transform.position;


        }



}