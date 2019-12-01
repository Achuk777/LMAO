using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUse : MonoBehaviour
{
    public Camera cam;
    public GameObject arm;
    public GameObject interactType;
    public GameObject ownLight;
    public Inventory inventory;
    public Slider slider;
    //public Text text;
    
    private static float coolDownSet= 15f;
    private float coolDown01;
    private float coolDown;
    private float coolDownTimer;
    private bool coolingDown;
    private float rot;
    private bool rotFlip;
    private bool spriteFlip;
    private string interactTag;

    void Update()
    {
        
        coolDown01=Mathf.Clamp01(coolDownTimer / 15f);
        slider.value= coolDown01;

        if(!coolingDown){
            
            coolDownTimer -= Time.deltaTime*2;
        
        } else{
            
            coolDownTimer -= Time.deltaTime;

        }
        
        
        //Debug.Log(coolDownTimer);
        if(coolDownTimer < 0){
            coolDownTimer =0;
            coolingDown=false;
            //Debug.Log("CooledDown");
        }
        if(coolDownTimer >= coolDownSet){
            coolingDown=true;
        }


        if(Input.GetButtonDown("Fire1"))
        {
        	if(interactType){
                if(interactTag== "Gun" || interactTag== "SecGun" || interactTag== "SpecGun" ){
                    if(!coolingDown){
                        interactType.SendMessage("Shoot",interactTag);
                        coolDownTimer += coolDown + 0.5f;
                    } else{
                        //Debug.Log("Waiting for Cooldown...");
                    }
                    
                } else if(interactTag=="Flashlight"){
                    interactType.SendMessage("Toggle");
                }

            }
            
        }
        if(Input.GetButtonDown("Switch"))
        {
            if(interactType){
                interactType.transform.parent=null;
                interactType.SendMessage("Hide");
            }
            GameObject aux=inventory.SwitchItem();
            if(aux){
                
                interactType=aux;
                interactType.transform.parent=arm.transform;
                
                if(!spriteFlip){
                    arm.transform.rotation= new Quaternion(0,0,0,0);
                } else {
                    arm.transform.rotation= new Quaternion(0,0,0,0);
                } 
                
                if(spriteFlip){
                    interactType.transform.SetPositionAndRotation( transform.localPosition +   new Vector3(-0.13f, -0.015f, 0), new Quaternion(0,180f,0,0) );
                } else if(!spriteFlip){
                    interactType.transform.SetPositionAndRotation( transform.localPosition +   new Vector3(0.13f, -0.015f, 0), new Quaternion(0,0,0,0) );
                }

                interactType.SetActive(true);

                if(interactTag== "Gun" || interactTag== "SecGun" || interactTag== "SpecGun" ){
                    ownLight.SetActive(true);
                } else if(interactTag=="Flashlight"){
                    ownLight.SetActive(false);
                }
            } else{

                Debug.Log("No hay");
            }
        }
    }
    
    void FixedUpdate()
    {
        
        if(transform.localRotation.eulerAngles.y>170f){
            spriteFlip=true;
        } else if(transform.localRotation.eulerAngles.y<10f){
            spriteFlip=false;
        }

        if(interactType){
            
            Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            dir.Normalize();
           
            if (cam.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x + 1f){
            rotFlip = false;
            
            }
            if (cam.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x - 1f){
            rotFlip = true;
            }
            
            //Debug.Log("x="+dir.x+"y="+dir.y);

            if(!spriteFlip){
                if(dir.x<0){
                    dir.x=0;
                }
                rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                arm.transform.localRotation = Quaternion.AngleAxis(rot, Vector3.forward);
            } else if(spriteFlip){
                if(dir.x>0){
                    dir.x=0;
                }
                rot = Mathf.Atan2(-dir.y,-dir.x) * Mathf.Rad2Deg;
                arm.transform.localRotation = Quaternion.AngleAxis(rot,new Vector3(0,0,-1));
                
            }
        }
    }
    public void Identifier(int id){
        //Debug.Log("MEGALMAO");
        switch(id){
            case 0:
            interactTag="Flashlight";
            coolDown= 0;
            break;
            
            case 1:
            interactTag="Gun";
            coolDown=   3;
            break;

            case 2:
            interactTag="SecGun";
            coolDown=   1;
            break;

            case 3:
            interactTag="SpecGun";
            coolDown=   15;
            break;

            case 4:
            interactTag="MapInteract";
            coolDown=   0;
            break;

        }
    }	
}
