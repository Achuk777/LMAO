using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj= null;
    public InteractionObject currentInterObjScript=null;
    public Inventory inventory;
    public Animator animateInteract;


    void Update()
    {
    	if(Input.GetButtonDown("Interact") && currentInterObj){
    		
            if(currentInterObjScript.inventory){
                inventory.AddItem(currentInterObj);
            } else if(currentInterObjScript.inventory == false){
                if(animateInteract.GetBool("BoolSwitch")){
                    animateInteract.SetBool("BoolSwitch",false);
                } else{
                    animateInteract.SetBool("BoolSwitch",true);
                }
                
            }

            
    	}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    	if(col.tag=="InterObject"){
    		//Debug.Log(col.name);
    		currentInterObj=col.gameObject;
            currentInterObjScript=currentInterObj.GetComponent<InteractionObject>();
    	}
        if(col.tag=="MapInteract"){
            //Debug.Log(col.name);
            currentInterObj=col.gameObject;
            animateInteract=animateInteract.GetComponent<Animator>();
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
    	if(col.tag=="InterObject"){
    		if(col.gameObject == currentInterObj){
    			currentInterObj = null;
    		}
    	}
        if(col.tag=="MapInteract"){
            if(col.gameObject == currentInterObj){
                currentInterObj = null;
            }
        }
    }
}
