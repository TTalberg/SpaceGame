using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundManager : MonoBehaviour {

    public Transform Background1;

    public Transform Background2;

    public float Speed = 1000;

    private Vector3 orgPos;


    // Use this for initialization
    void Start () {

        orgPos = new Vector3(Background2.position.x, Background2.position.y, Background2.position.z);


      
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Background1.position.x < -orgPos.x || Background2.position.x < -orgPos.x)
        {
            if (Background1.position.x < -orgPos.x)
            {
                Background1.position = new Vector3( orgPos.x, orgPos.y, orgPos.z);
            }
            if (Background2.position.x < -orgPos.x)
            {
                Background2.position = new Vector3(orgPos.x, orgPos.y, orgPos.z);
            }

        }
        else
        {
            Background1.position = new Vector3(Background1.position.x - Speed * Time.deltaTime, Background1.position.y, Background1.position.z);
            Background2.position = new Vector3(Background2.position.x - Speed * Time.deltaTime, Background2.position.y, Background2.position.z);
        }
	}
}
