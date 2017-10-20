using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCollider : MonoBehaviour {
    public bool colliding;

    public void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Building")
        {
            colliding = true;
    }
}
    
    public void OnTriggerExit(Collider c)
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
