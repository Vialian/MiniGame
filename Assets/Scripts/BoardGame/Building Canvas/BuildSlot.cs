using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSlot : MonoBehaviour
{
    //public Image icon;
    ////public Button removeButton;
    Transform childImage;
    public ChooseBuilding item;
    private GameObject SelectedItem;
    private GameObject BuildingPlacementObject;
    private bool PlacementStarted = false;
    bool DummyBuilding = true;
    void Start()
    {
        item.test = this;
        childImage = this.gameObject.transform.GetChild(0);
        Image pic = childImage.GetComponentInChildren<Image>();
        pic.sprite = item.icon;
        if (item.name == "Empty" || item.IsEnaled == false)
        {
            pic.enabled = false;
        }
    }
    public void ItemSelection(GameObject Building, GameObject BuildingPlacementObjectSended)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        //Instantiate(Building, pos, Quaternion.identity);
        PlacementStarted = true;
        SelectedItem = Building;
        BuildingPlacementObject = BuildingPlacementObjectSended;
    }
    
    void Update()
    {
        if (PlacementStarted)
        {

            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
            newPos.z = transform.position.z;


            //transform.position = newPos;
            if (DummyBuilding)
            {
                Vector3 mouse = Input.mousePosition;
                Ray castPoint = Camera.main.ScreenPointToRay(mouse);
                RaycastHit hit;
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
                {
                    Vector3 pos = new Vector3(hit.point.x, 0.5f, hit.point.z);
                    Instantiate(SelectedItem, pos, Quaternion.identity);
                    SelectedItem.transform.position = newPos;
                    //Instantiate(SelectedItem, SelectedItem.transform.position = newPos, Quaternion.identity);
                }
                DummyBuilding = false;
            }



            if (Input.GetMouseButtonDown(0))
            {

                Debug.Log(item.Building);

                Vector3 mouse = Input.mousePosition;
                Ray castPoint = Camera.main.ScreenPointToRay(mouse);
                RaycastHit hit;
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
                {
                    Vector3 pos = new Vector3(hit.point.x, 0.5f, hit.point.z);
                    Debug.Log("Building build in position : " + hit.point);
                    Instantiate(SelectedItem, pos, Quaternion.identity);
                    //SelectedItem.transform.position = hit.point;
                }

                PlacementStarted = false;
                DummyBuilding = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("PlacementStarted is false");
            PlacementStarted = false;
            DummyBuilding = true;
        }
 
    }
    public void UseItem()
    {
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