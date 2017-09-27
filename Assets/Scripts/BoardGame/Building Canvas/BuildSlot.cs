using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class BuildSlot : MonoBehaviour
{
    //public Image icon;
    ////public Button removeButton;
    Transform Cost;
    Transform childImage;
    public ChooseBuilding item;
    private GameObject SelectedItem;
    private GameObject BuildingDummy;
    private bool PlacementStarted = false;
    bool buildingDummyBool = true;


    void Start()
    {
        //Sets the image/sprite in UI foreach "Build(item)" for the child
        item.buildSlot = this;
        childImage = this.gameObject.transform.GetChild(0);
        Image pic = childImage.GetComponentInChildren<Image>();
        pic.sprite = item.icon;
        //If "Build" don't have a image, it will show nothing
        if (item.name == "Empty" || item.IsEnaled == false)
        {
            pic.enabled = false;
        }
    }
    public void PointerEnter()
    {
        Cost = this.gameObject.transform.GetChild(1);
        Text costTxt = Cost.GetComponentInChildren<Text>();
        costTxt.text = item.Cost.ToString() + " " + item.name;
        if(item.name == "Empty"|| item.IsEnaled == false)
            costTxt.enabled = false;
        else
            costTxt.enabled = true;

    }
    public void PointerExit()
    {
        Cost = this.gameObject.transform.GetChild(1);
        Text costTxt = Cost.GetComponentInChildren<Text>();
        costTxt.enabled = false;
    }
    public void ItemSelection(GameObject Building, GameObject BuildingDummySend)
    {
        //receives the GameObjects items from "Build", and starts Placement of building(Update), and instantiates the dummy
        if (item.name == "Empty" || item.IsEnaled == false)
        {
            return;
        }
        PlacementStarted = true;
        BuildingDummy = Instantiate(BuildingDummySend, new Vector3(0, 0.5f, 0), Quaternion.identity);
        SelectedItem = Building;
    }
    
    void Update()
    {

        if (PlacementStarted)
        {
            //Moves the BuildingDummy with the mouse
            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));

                Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
                {

                BuildingDummy.transform.position = Vector3.MoveTowards(new Vector3(hit.point.x, 0.5f, hit.point.z), new Vector3(newPos.x, 0.5f, newPos.z), 100 * Time.deltaTime);

                }
            buildingDummyBool = false;

            if (Input.GetMouseButtonDown(0))
            {
                NavMeshHit hitNavmesh;

                if (NavMesh.SamplePosition(BuildingDummy.transform.position, out hitNavmesh, 20f, NavMesh.AllAreas) /*!= NavMesh.SamplePosition(BuildingDummy.transform.position, out hitNavmesh, 20f, NavMesh.GetAreaFromName("Not Walkable"))*/)
                {
                    if (hitNavmesh.mask == 9)
                    {
                        Debug.Log("Navmesh");
                    }

                }
                //Sets SelectedItem(Building from the item "Build"), at BuildingDummy position, and destroy BuildingDummy
                    Debug.Log(item.Building + " " + hit.point);
                    Instantiate(SelectedItem, BuildingDummy.transform.position, Quaternion.identity);
                    Destroy(BuildingDummy);

                PlacementStarted = false;
                buildingDummyBool = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Stops the buildingplacement, and destroys the temporary GameObject "BuildingDummy"
            Debug.Log("Placement ended");
            PlacementStarted = false;
            buildingDummyBool = true;
            if (BuildingDummy != null)
            {
                Destroy(BuildingDummy);
            }
        }
    }
    public void UseItem()
    {
        //When the UI buttons are clicked, it will go to ChooseBuilding(item), and execute Use
        if (name != null && item.IsEnaled)
        {

            item.Use();

        }
        else
        {
            Debug.Log("Nothing");
            return;
        }
    }
}