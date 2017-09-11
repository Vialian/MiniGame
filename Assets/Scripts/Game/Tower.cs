using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject Fireball_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Fireball;
    public float Fireball_Forward_Force;
    public int Distance = 10;
    public Transform player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject Temporary_Fireball_Handler;
        Temporary_Fireball_Handler = Instantiate(Fireball, Fireball_Emitter.transform.position, Fireball_Emitter.transform.rotation) as GameObject;
        Temporary_Fireball_Handler.transform.Rotate(Vector3.left * 90);

        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Fireball_Handler.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody.AddForce(transform.forward * Fireball_Forward_Force);

        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        Destroy(Temporary_Fireball_Handler, 10.0f);




    }
}
