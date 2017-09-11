using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : MonoBehaviour {
    float speed = 10;
    Vector3 targetPos;
    private void Start()
    {
        targetPos = transform.position;
    }
    void Update () {
        if (Input.GetMouseButtonDown(2))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                targetPos = hit.point;
                transform.position = targetPos;
            }

            //Destroy(GetComponent<AttackAI>());
            targetPos = Camera.main.WorldToScreenPoint(transform.position);
            //var offset = transform.position - Camera.main.ScreenToWorldPoint(Vector3(Input.mousePosition.x, Input.mousePosition.y, targetPos.z));
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(targetPos), speed * Time.deltaTime);
        }
    }
}
