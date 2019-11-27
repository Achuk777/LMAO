using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camWall : MonoBehaviour
{
    // Start is called before the first frame update
	void OnTriggerEnter2D(Collider2D col){
        if(col.name=="CamBox"){
            //Debug.Log("Entro");
            CameraMove.bigCam=true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.name=="CamBox"){
            //Debug.Log("Salio");
            CameraMove.bigCam=true;  
        }
    }
}
