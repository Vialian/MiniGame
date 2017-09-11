using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour {

    public float min;
    public float max;
    public float speed;
    void Start () {
        //min = transform.position.z;
        //max = transform.position.z * -1;
    }
	
	// Update is called once per frame
	void Update () {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, max - min) + min);
    }
}
