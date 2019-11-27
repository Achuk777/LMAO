using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj= null;
    public InteractionObject currentInterObjScript=null;
    public Inventory inventory;

    void Update()
    {
    	if(Input.GetButtonDown("Interact") && currentInterObj){
    		
            if(currentInterObjScript.inventory){
                inventory.AddItem(currentInterObj);
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
    }

    void OnTriggerExit2D(Collider2D col)
    {
    	if(col.tag=="InterObject"){
    		if(col.gameObject == currentInterObj){
    			currentInterObj = null;
    		}
    	}
    }
}
