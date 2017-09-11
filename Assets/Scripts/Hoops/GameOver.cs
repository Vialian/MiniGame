using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public bool dead = false;
    void OnTriggerEnter(Collider c)
    {    
        if (c.gameObject.tag == "floor")
        {
            dead = true;
            transform.DetachChildren();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePosition;
            //Destroy(this.gameObject);
        }
    }
    private GUIStyle guiStyle = new GUIStyle();
    private void OnGUI()
    {
        if (dead == true)
        {
            guiStyle.fontSize = 20; //change the font size
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 10, 100, 50), "GameOver", guiStyle);
        }

    }

}
