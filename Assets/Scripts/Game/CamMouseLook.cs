using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour {

    Vector2 MouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    GameObject character;

    //cam
    public float speed = 10.0f;
    void Start () {
        //character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        //Cam
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);


        //Player
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        MouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
        //character.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, character.transform.up);

    }
}
