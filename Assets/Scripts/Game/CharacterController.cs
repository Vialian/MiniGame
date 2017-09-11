using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Fireball_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Fireball;
    public float Fireball_Forward_Force;


    static Animator anim;
    public float speed = 10.0f;
    public float Running = 15.0f;
    float temp;
    void Start () {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            anim.SetBool("IsSpecial", true);
            if (anim.GetBool("IsSpecial") == true)
            {
                GameObject Temporary_Fireball_Handler;
                Temporary_Fireball_Handler = Instantiate(Fireball, Fireball_Emitter.transform.position, Fireball_Emitter.transform.rotation) as GameObject;
                Temporary_Fireball_Handler.transform.Rotate(Vector3.left * 90);

                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Fireball_Handler.GetComponent<Rigidbody>();

                //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                Temporary_RigidBody.AddForce(transform.forward * Fireball_Forward_Force);

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Fireball_Handler, 20.0f);
            }
           
        }
        else
        {
            anim.SetBool("IsSpecial", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("IsAttacking", true);
        }
        //else if (Input.GetMouseButtonDown(1))
        //{

        //}
        else
        {
            anim.SetBool("IsAttacking", false);
            //anim.SetInteger("Attack", 0);
        }

        if (translation != 0)
        {
            //anim.SetInteger("Walk", 1);
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsIdle", false);
            if (Input.GetMouseButtonDown(1))
            {
                anim.SetBool("IsWalking", false);
                temp = speed;
                speed = Running;
                anim.SetBool("IsRunning", true);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                anim.SetBool("IsWalking", true);
                speed = temp;
                anim.SetBool("IsRunning", false);
            }

        }

        else
        {
            //anim.SetInteger("Walk", 0);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsIdle", true);
        }


        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}