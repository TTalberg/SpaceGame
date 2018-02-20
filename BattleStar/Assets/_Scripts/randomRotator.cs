using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRotator : MonoBehaviour {
    public float tumble;

	// Use this for initialization
	void Start () {
       // transform.position = Random.insideUnitCircle * tumble;


    }

    private void Awake()
    {
        tumble = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update () {

        gameObject.GetComponent<Transform>().Rotate(
        new Vector3(0f, 0f, tumble));



    }
}
