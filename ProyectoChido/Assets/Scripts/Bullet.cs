using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity= transform.right *speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	
    	//Debug.Log(col.name);
    	if(col.tag=="Wall"){
    		Destroy(gameObject);
    	}
    	
    }   
}
