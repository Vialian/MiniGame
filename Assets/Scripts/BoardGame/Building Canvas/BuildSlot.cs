using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class BuildSlot : MonoBehaviour
{
#region Variables
    //OnHover
    Transform Cost;
    //Sprite/image for building inventory
    Transform childImage;
    //reference to ChoosBuildidng
    public ChooseBuilding item;
    //from ChooseBuilding items("Build")
    private GameObject SelectedItem;
    private GameObject BuildingDummy;
    private GameObject BuildingTimer;

    private bool PlacementStarted = false;

    Vector3 BuildingDummyPos;
    GameObject BuildingTimerDestroy;

    //Testing, each inventory have 100, set money a place, where all access the same
    int Money = 100;


    PlacementCollider placementCollider;
    #endregion
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
        //On Mouse Hover on items in Build inventory, it will show information about the item cost and name of item
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
        //When mouse will move away from item, it will disable information text
        Cost = this.gameObject.transform.GetChild(1);
        Text costTxt = Cost.GetComponentInChildren<Text>();
        costTxt.enabled = false;
    }
    public void ItemSelection(GameObject Building, GameObject BuildingTimerSend, GameObject BuildingDummySend)
    {
        //receives the GameObjects items from "Build", and starts Placement of building(Update), and instantiates the dummy
        if (item.name == "Empty" || item.IsEnaled == false)
        {
            return;
        }
        PlacementStarted = true;
        BuildingDummy = Instantiate(BuildingDummySend, new Vector3(0, 0.5f, 0), Quaternion.identity);
        SelectedItem = Building;
        BuildingTimer = BuildingTimerSend;

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

            if (Input.GetMouseButtonDown(0))
            {

                //NavMeshHit hitNavmesh;


                //if (NavMesh.SamplePosition(BuildingDummy.transform.position, out hitNavmesh, 20f, NavMesh.AllAreas) /*!= NavMesh.SamplePosition(BuildingDummy.transform.position, out hitNavmesh, 20f, NavMesh.GetAreaFromName("Not Walkable"))*/)
                //{
                //    if (hitNavmesh.mask == 9)
                //    {
                //        Debug.Log("Navmesh");
                //    }

                //}
                //Sets SelectedItem(Building from the item "Build"), at BuildingDummy position, and destroys BuildingDummy

                //builds multiple buildings while holding leftshift, and have enough ressources to buy the building
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (Money < item.Cost) { }

                    else
                    {

                        BuildingDummyPos = BuildingDummy.transform.position;
                        BuildingTimerDestroy = Instantiate(BuildingTimer, BuildingDummyPos, Quaternion.identity);
                        Money -= item.Cost;
                        
                        StartCoroutine(BuildingTimeIEnumerator(item.AnimationTime, BuildingTimerDestroy, BuildingDummyPos));

                        StopCoroutine(BuildingTimeIEnumerator(item.AnimationTime, BuildingTimerDestroy, BuildingDummyPos));
                    }

                }
                else //Builds 1 building if ressources suffice
                {
                    if (Money < item.Cost){ }

                    else
                    {
                        BuildingDummyPos = BuildingDummy.transform.position;
                        BuildingTimerDestroy = Instantiate(BuildingTimer, BuildingDummyPos, Quaternion.identity);
                        Money -= item.Cost;

                        StartCoroutine(BuildingTimeIEnumerator(item.AnimationTime, BuildingTimerDestroy, BuildingDummyPos));

                        StopCoroutine(BuildingTimeIEnumerator(item.AnimationTime, BuildingTimerDestroy, BuildingDummyPos));
                    }
 
                    Destroy(BuildingDummy);
                    PlacementStarted = false;

                }
                Debug.Log(Money);


            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Stops the buildingplacement, and destroys the temporary GameObject "BuildingDummy"
            Debug.Log("Placement ended");
            PlacementStarted = false;
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

    IEnumerator BuildingTimeIEnumerator(int timer, GameObject BuildingAnimationObject, Vector3 pos)
    {
        Debug.Log("Animation time " + timer);
        yield return new WaitForSeconds(timer);
        Instantiate(SelectedItem, pos, Quaternion.identity).name = SelectedItem.name;
        Destroy(BuildingAnimationObject);
    }
}