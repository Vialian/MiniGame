using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

    public Transform player;
    public int DetectRange = 5;
    public int Distance = 10;
    public int DetectAngle = 30;
    public float speed = 0.1f;
    static Animator anim;
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.position, this.transform.position) < Distance && angle < DetectAngle)
        {
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), speed * Time.deltaTime);

            anim.SetBool("IsIdle", false);
            if (direction.magnitude > DetectRange)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttacking", false);
            }
            else
            {
                anim.SetBool("IsAttacking", true);
                anim.SetBool("IsWalking", false);
            }

        }
        else
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", false);
        }
    }
}
