using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    public GameObject[] inventory= new GameObject[5];
    private int gunTag;
    // -FL = 0
    // -GunItem = 1
    // -SecItem = 2
    // -SpecItem = 3
    // -Item = 4
    private int sw=0;
    private int itemMax=-1;
    
    
    public void AddItem(GameObject item)
    {
    	bool itemAdded = false;
    	for(int i=0; i < inventory.Length; i++){
    		if(inventory[i] == null){
    			inventory[i]=item;
    			itemMax++;
    			Debug.Log(item.name + "was added");
    			itemAdded=true;
    			item.SendMessage("Hide");
    			break;
    		}
    	}

    	if(!itemAdded){
    		Debug.Log("Inventory Full");
    	}
    }

    public GameObject SwitchItem()
    {
    	GameObject aux;
    	if(itemMax == -1 || itemMax == 0 || sw == itemMax){
    		
    		sw=0;
    	}
    	else{

    		sw++;
    	}
    	//Debug.Log(sw);
    	if(inventory[sw] != null){
    		
    		aux=inventory[sw];
    	} 
    	else{
    		
    		Debug.Log("No items");
    		return null;
    		
    	}
    	return aux;
    }
}
