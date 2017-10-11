using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCollider : MonoBehaviour {
    public bool colliding;

    public void OnCollisionEnter(Collision c)
    {
        if (c.transform.tag == "Building")
        {
            Debug.Log("Collide");
            colliding = true;
        }
    }
    
    public void OnCollisionExit(Collision c)
    {
        if (c.transform.tag == "Building")
        {
            colliding = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
