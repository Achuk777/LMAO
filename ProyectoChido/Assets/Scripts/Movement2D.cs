using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public Control2D controller; 
    
    float horizontalMove = 4f;
    bool jump = false;
    bool crouch = false;
    public float runspeed = 40f;


    
    // Update is called once per frame
    void Update()
    {
    	horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
    	if(Input.GetButtonDown("Jump")){
    		jump=true;
    	}
    	if(Input.GetButtonDown("Crouch")){
    		crouch=true;
    	}
        
    }
    void FixedUpdate(){

    	controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    	jump=false;
    	crouch=false;
    }

    
}
