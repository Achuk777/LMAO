using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float damping = 1.5f;
    public Transform _target;
    public Vector2 offset = new Vector2(2f, 1f);
    public AnimationClip zoomIn,zoomOut;
    public Animation animCam;
    public static bool bigCam;

    private bool faceLeft,zoomed;
    private int lastX;
    private float dynamicSpeed;
    private Camera _cam;

    void Start()
    {
        bigCam=false;
        zoomed=true;
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer();
        _cam = gameObject.GetComponent<Camera>();
    
    }

    public void FindPlayer()
    {
        lastX = Mathf.RoundToInt(_target.position.x);
        transform.position = new Vector3(_target.position.x + offset.x, _target.position.y + offset.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if (_target)
        {
            if(bigCam && zoomed){
            //_cam.orthographicSize=4;
            offset= new Vector2(1,3);
            animCam.clip=zoomOut;
            animCam.Play();
            zoomed=false;
            bigCam=false;
            }
            else if(bigCam && !zoomed){
            //_cam.orthographicSize=1;
            offset= new Vector2(1,0);
            animCam.clip=zoomIn;
            animCam.Play();
            zoomed=true;
            bigCam=false;
            }
            
            //offset= new Vector2(1,4);
            
            int currentX = Mathf.RoundToInt(_target.position.x);
            if (currentX > lastX) 
            faceLeft = false; 
            else if (currentX < lastX) 
            faceLeft = true;
            lastX = Mathf.RoundToInt(_target.position.x);

            Vector3 target;
            if (faceLeft)
            {
                target = new Vector3(_target.position.x - offset.x, _target.position.y + offset.y+dynamicSpeed, transform.position.z);
            }
            else
            {
                target = new Vector3(_target.position.x + offset.x, _target.position.y + offset.y+dynamicSpeed, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }  
}
