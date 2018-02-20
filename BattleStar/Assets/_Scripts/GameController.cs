//trevers game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public bool Gamewon = false;
    
    //public void ChangeScene()


   public static GameController instance;

    public GameObject enemyCraftPrefab_1;
    public GameObject enemyCraftPrefab_2;

    public GameObject PlayerShip;

    public float lives = 3;

    public GameObject asteroidPrefab;
    public AudioSource missleLaunch;

    private float timeElapsed;
    private float speed;

    public bool gameOver = false;

    public Text txtScore;
    public int Score = 0;

    public Text txtHullInteg;
    private int hullcount;

    //  public Transform bulletSpawn;
    //  public GameObject bulletPrefab;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        
        speed = Random.Range(80f, 120f) * -1;
        // speed = 100;
        //timeElapsed = 0;

        StartCoroutine(Example());

    }
        IEnumerator Example()
    
        {   print(Time.time);
            yield return new WaitForSeconds(10);
            print(Time.time);
         }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(lives == 0)
        {
            gameOver = true;
          

        }
        txtScore.text = "Kills: " + Score;

        if (Time.time % 2 < 0.0001)
        {
            float Rando = Random.Range(0, 4);

            if (Rando == 1)
            {
                speed = Random.Range(80f, 120f) * -1;


                Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 6f), 0f);//offset of ship spawn


                var enemy = (GameObject)Instantiate(enemyCraftPrefab_1, transform.position + spawnOffset, transform.rotation);
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));

                Debug.Log(speed);

                Destroy(enemy, 12f);

            }
            if (Rando == 2)
            {


                speed = Random.Range(80f, 120f) * -1;


                Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 6f), 0f);//offset of ship spawn


                var enemy = (GameObject)Instantiate(enemyCraftPrefab_2, transform.position + spawnOffset, transform.rotation);
                enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));

                Debug.Log(speed);

                Destroy(enemy, 12f);


            }

            if (Rando == 3)
            {



                speed = Random.Range(80f, 120f) * -1;


                Vector3 spawnOffset = new Vector3(0f, Random.Range(-5f, 6f), 0f);//offset of asteroid spawn


                var asteroid = (GameObject)Instantiate(asteroidPrefab, transform.position + spawnOffset, transform.rotation);
                asteroid.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0f));

                Debug.Log(speed);

                Destroy(asteroid, 12f);

            }
           
            if (gameOver && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }
 

    public void PlayerDead()
    {
        gameOver = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
 
        Debug.Log("bullet Hit: " + other.tag);
        if (other.tag.Equals("boundary"))
        {
            Destroy(gameObject);
            
        }
        if (other.tag.Equals("enemy"))
        {
            Score = Score + 1;
            txtScore.text = "Count: " + Score.ToString();

            Debug.Log(" KILLED THEM");
            Destroy(other.gameObject);
            Destroy(gameObject); 
      
        }

        if (other.gameObject.tag == "Player")
        {
            lives = lives -1;
            GameObject.Destroy(gameObject);
         
        }
          


    }




}
