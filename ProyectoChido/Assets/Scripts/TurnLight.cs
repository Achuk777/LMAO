using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLight : MonoBehaviour
{
    //public AudioSource sound;
    public GameObject ownLight;

    private bool OnOff=true;
    // Start is called before the first frame update
    // void Start()
    // {
    //     sound= GetComponent<AudioSource>();
    // }

    // Update is called once per frame
    public void Toggle()
    {
        //sound.Play();
        FindObjectOfType<AudioManager>().Play("Flashlight");
        if(OnOff){
        	ownLight.SetActive(false);
        	OnOff=false;
        } else{
        	ownLight.SetActive(true);
        	OnOff=true;
        }
        
    }
}
