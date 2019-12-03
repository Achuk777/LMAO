using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonControl : MonoBehaviour
{

    public float speed;
    public AreaEffector2D effector;
    public BossController bossController;

    private Transform player;
    private float stanbyDist= 0.3f;
    private Rigidbody2D  body;
    private BoxCollider2D collider;
    private Animator skeletonAnim;
    // Start is called before the first frame update
    void Start()
    {
        collider=GetComponent<BoxCollider2D>();
        skeletonAnim=GetComponent<Animator>();
        body=GetComponent<Rigidbody2D>();
        player=GameObject.Find("Dweller").transform;
        speed= Random.Range(0.5f,1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player){
       		if(player.position.x + stanbyDist < transform.position.x){
       			transform.rotation= new Quaternion(0,0,0,0);
       			effector.forceAngle=180;
       			skeletonAnim.SetBool("moving",true);
       			if(skeletonAnim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonAnim"))
       			body.velocity = new Vector3(-speed,0,0);		
       		}
       		else if(player.position.x - stanbyDist > transform.position.x){
       			transform.rotation= new Quaternion(0,180,0,0);
       			effector.forceAngle=0;
       			skeletonAnim.SetBool("moving",true);
       			if(skeletonAnim.GetCurrentAnimatorStateInfo(0).IsName("SkeletonAnim"))
       			body.velocity = new Vector3(speed,0,0);
       		} else{
       			skeletonAnim.SetBool("moving",false);
       			body.velocity = new Vector3(0,0,0);
       		}
        }else{
        	skeletonAnim.Play("SkeletonAnim");
        }
    }

}
