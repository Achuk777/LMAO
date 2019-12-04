using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    //public AudioSource sound;
    public Transform firepoint;
    public GameObject bulletPreFab;

    // void Awake()
    // {
    //    sound= GetComponent<AudioSource>(); 
    //    //Debug.Log("LMAO");
    // }

 
    public void Shoot(string id)
    {
    	//Debug.Log("Shoot");
    	Instantiate(bulletPreFab, firepoint.position, firepoint.rotation);
    	FindObjectOfType<AudioManager>().Play(id,0);
    	//sound.Play();
    }
}
