using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Build : MonoBehaviour
{

    private Transform currentBuilding;
    private bool InitiatedPlacement = true;
    private GameObject InitiateBuilding;
    ChooseBuilding chooseBuilding;

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Click");
        //    Vector3 m = Input.mousePosition;
        //    m = new Vector3(m.x, m.y, transform.position.y);
        //    Vector3 p = Camera.main.ScreenToWorldPoint(m);

        //    currentBuilding.position = new Vector3(p.x, 0.5f, p.z);

        //    Instantiate(chooseBuilding.Building, currentBuilding.position, Quaternion.identity);
        //}
        //Debug.Log(InitiatedPlacement);
        //if (InitiatedPlacement)
        //{
        //    Debug.Log("bool");
        //}
        //RaycastHit hit;
        //if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100) && InitiateBuilding != null)
        //{
        //    InitiateBuilding.transform.position = hit.point;

        //    Debug.Log("Instantiate " + InitiateBuilding.name);
        //}
    }
    
    //public void Placement(bool placementStarted, GameObject Building)
    //{
    //    InitiatedPlacement = placementStarted;
    //    InitiateBuilding = Building;
    //    Debug.Log(placementStarted);

        #region Placement for Buildings
        //var mousePos = Input.mousePosition;
        //mousePos.z = 2.0f;       // we want 2m away from the camera position
        //var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        //Instantiate(Building, objectPos, Quaternion.identity);

        //Vector3 m = Input.mousePosition;
        //m = new Vector3(m.x, m.y, transform.position.y);
        //Vector3 p = Camera.main.ScreenToWorldPoint(m);

        //currentBuilding.position = new Vector3(p.x, 0.5f, p.z);

        //Instantiate(Building, currentBuilding.position, Quaternion.identity);
        //RaycastHit hit;
        //Vector3 pos = new Vector3(0, 0, 0);
        //Debug.Log(hit.point);
        //Instantiate(Building, pos, Quaternion.identity);
        //Instantiate(Building, pos, Quaternion.identity).transform.position = Input.mousePosition;


        //RaycastHit hit;
        //if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100) && InitiateBuilding != null)
        //{
        //    InitiateBuilding.transform.position = hit.point;

        //    Debug.Log("Instantiate " + InitiateBuilding.name);
        //}


        //Building.transform.position = Vector3.Lerp(Building.transform.position, Input.mousePosition, 5 * Time.deltaTime);





        //if (placementStarted)
        //{

        //    if (Input.GetMouseButtonDown(0))
        //    {


                //Instantiate(Building, currentBuilding.position, Quaternion.identity);
                //Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
                //Instantiate(Building, hit.point, Quaternion.identity);

                //placementStarted = false;

                //Debug.Log("Instantiate " + Building.name);


        //    }
        //}
            




        #endregion





        //buildingMask = "Ground";
        //Instantiate(Resources.Load(NameOfBuilding), objectPos, Quaternion.identity);


        //Vector3 m = Input.mousePosition;
        //m = new Vector3(m.x, m.y, transform.position.y);
        //Vector3 p = Camera.main.ScreenToWorldPoint(m);

        //RaycastHit hit = new RaycastHit();
        //Ray ray = new Ray(new Vector3(p.x, 8, p.z), Vector3.down);
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity)) ;
        //while (placementStarted)
        //{
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Fire");
        //}
        //}

    }
    //#region Singleton only one instance of class/object
    //public static Build instance; //Singleton, makes a static variable that share all instances of a class

    //void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Debug.LogWarning("More than one instance of Inventory found!");
    //        return;
    //    }
    //    instance = this; //then we set the instance to this particular component, so allways access this component, but you can only use 1 instance

    //}
    //#endregion

    //public int space = 20;
    //public delegate void OnItemChanged();

    //public OnItemChanged onItemChangedCallback;

    //public List<ChooseBuilding> items = new List<ChooseBuilding>();
    //public bool Add(ChooseBuilding item)
    //{
    //    if (!item.isDefaultItem)
    //    {
    //        if (items.Count >= space)
    //        {
    //            Debug.Log("Not Enough room");
    //            return false;
    //        }
    //        items.Add(item);

    //        if (onItemChangedCallback != null)
    //            onItemChangedCallback.Invoke();
    //    }
    //    return true;
    //}

    //public void Remove(ChooseBuilding item)
    //{
    //    items.Remove(item);

    //    if (onItemChangedCallback != null)
    //        onItemChangedCallback.Invoke();
    //}
//}