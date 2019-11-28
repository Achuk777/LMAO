using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [Tooltip("0:Flashlight \n 1:Gun \n 2:SecGun \n 3:SpecGun \n 4:MapInteract \n")]
    [Range(0,4)]
    public int interactTag;
    public bool inventory; 
    //inventory=true
    //MapInteract=false
    
    void OnEnable()
    {
    	//Debug.Log("MICROLMAO");
    	//Debug.Log(transform.parent.parent);
    	if(transform.parent!=null){
    		//Debug.Log("MINILMAO");
    		transform.parent.parent.SendMessageUpwards("Identifier",interactTag);
    	}
    }

    public void Hide()
    {
    	gameObject.SetActive(false);
    }
   	


}
