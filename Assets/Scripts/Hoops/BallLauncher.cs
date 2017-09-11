using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {
    public Rigidbody ball;
    public Transform target;
    private Ray ray;
    public float h;  //height
    public float gravitity = -9.81f; //gravity
    public bool debugpath;
    public bool SetRange = true;
    public bool flying;
    public int distance;
    private void Start()
    {
        debugpath = false;
        ball.useGravity = false;
    }
    private void OnGUI()
    {
        Vector3 position = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
        distance = (int)position.sqrMagnitude / 29;
        int height = (int)h;
        if (distance > 0)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "height: " + height + "\ndistance: " + distance);
        }
        else
        {
            distance = -distance;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "height: " + height + "\ndistance: " + distance);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            ball.transform.Rotate(0, 0, -Time.deltaTime * 100);
        }
        if (Input.GetKey("s"))
        {
            ball.transform.Rotate(0, 0, Time.deltaTime * 100);
        }
        if (Input.GetKey("a"))
        {
            ball.transform.Rotate(Vector3.down * Time.deltaTime * 100, Space.World);
        }
        if (Input.GetKey("d"))
        {
            ball.transform.Rotate(Vector3.up * Time.deltaTime * 100, Space.World);
        }
    }
    private void Update()
    {
        if (!SetRange)
        {
            h += Input.GetAxis("Mouse ScrollWheel") * 10;
            if (h < 1)
            {
                h = 1;
            }
            if (h > 40)
            {
                h = 40;
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && debugpath == false)
        {
            debugpath = true;
        }
        else if (Input.GetKeyDown(KeyCode.G) && debugpath == true)
        {
            debugpath = false;
        }
        Vector3 distance = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
        if (Input.GetMouseButtonDown(2) && SetRange == false)
        {
            SetRange = true;
        }
        else if (Input.GetMouseButtonDown(2) && SetRange == true)
        {
            SetRange = false;
        }

            if (SetRange)
            {
                if (distance.x > 0)
                {
                    h = distance.x/4;
                }
                else
                {
                    h = -distance.x/4;
                }
            }
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            target.position = hit.point + new Vector3(0,1,0);
            //    hit.collider.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Launch();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        }
        if (debugpath)
        {
            DrawPath();
        }
    }
    void Launch()
    {
        //debugpath = false;
        Physics.gravity = Vector3.up * gravitity;
        ball.useGravity = true;
        ball.velocity = CalculateLaunchData().initialVelocity;
    }
    LaunchData CalculateLaunchData()
    {
        float displacementY = target.position.y - ball.position.y;
        Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);

        float time = (Mathf.Sqrt(-2 * h / gravitity) + Mathf.Sqrt(2 * (displacementY - h) / gravitity));
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravitity * h);
        Vector3 velocityXZ = displacementXZ / time;
        //return velocityXZ + velocityY;

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravitity), time);

    }

    void DrawPath()
    {
        LaunchData launchData = CalculateLaunchData();
        int resolution = 30;
        Vector3 previousDrawPoint = ball.position;
        for (int i = 1; i < resolution; i++)
        {
            float simulationTime = i / (float)resolution * launchData.timeToTarget;
            Vector3 displacement = launchData.initialVelocity * simulationTime + Vector3.up * gravitity * simulationTime * simulationTime / 2f;
            Vector3 drawPoint = ball.position + displacement;
            Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
            previousDrawPoint = drawPoint;
        }
    }
    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;
        public LaunchData (Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }
    }
}