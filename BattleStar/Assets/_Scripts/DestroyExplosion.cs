using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour {
    public AudioSource BOOM;
 

    private void Awake()
    {
         BOOM.Play();
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
        
	
}
