using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[System.Serializable]
public class AttackAI : MonoBehaviour
{
    #region variable
    public float DetectRange = 500f;
    public float distancesquare;
    private float MeleRange = 7.755256f;
    private float speed = 10f;
    static Animator anim;
    public string opponent;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject[] targets;
    [HideInInspector]
    public string NameOfUnitsInRange;
    [HideInInspector]
    public string NameOfUnitsInTotal;

    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsIdle", true);
    }
    void Update()
    {
        //Remove if spot in list is null
        enemies.RemoveAll(GameObject => GameObject == null);

        #region Foreach Notes
        //Adds every units to list, and compare with units in an range around, then checks if name exist in both, 
        //if they don't, it adds to enemies list(In range)
        #endregion
        targets = GameObject.FindGameObjectsWithTag(opponent);
        foreach (var target in targets)
        {
            Vector3 distance = target.transform.position - this.transform.position;
            distancesquare = distance.sqrMagnitude;
            NameOfUnitsInTotal = target.transform.name;
            if (distancesquare <= DetectRange && enemies.Count == 0)
            {
                enemies.Add(target);
            }
            else
            {
            }

            if (distancesquare <= DetectRange)
            {
                if (enemies.Count == 1)
                {
                    NameOfUnitsInRange = enemies[0].transform.name;
                    #region In case of expand, regarding within area and are in enemies list
                    //foreach (var unitsInRange in enemies)
                    //{

                    //    NameOfUnitsInRangeExtra = unitsInRange.transform.name;
                    //    if (enemies != null)
                    //    {
                    //        if (Vector3.Distance(target.transform.position, this.transform.position) <= DetectRange && NameOfUnitsInTotal != NameOfUnitsInRangeExtra)
                    //        {
                    //            #region TODO:

                    //            //TODO: With only 1 in enemies, they stop up if more than 1 unit
                    //            //TODO: if every unit in area get put in enemies, fix multiple in list of same unit
                    //            #endregion
                    //            //enemies.Add(target);
                    //            return;
                    //        }
                    //        else if (Vector3.Distance(target.transform.position, this.transform.position) <= DetectRange && NameOfUnitsInTotal == NameOfUnitsInRangeExtra)
                    //        {
                    //        }
                    //        else
                    //        {
                    //            Debug.Log("Equal");
                    //            enemies.Remove(unitsInRange);
                    //        }
                    //    }
                    //}

                    #endregion
                }
            }
            else
            {
                enemies.Remove(target);
            }
        }

        //Animations + movement
        if (enemies.Count > 0)
        {
            Vector3 distance = enemies[0].transform.position - this.transform.position;
            distancesquare = distance.sqrMagnitude;
            if (distancesquare < DetectRange && distancesquare > MeleRange)
            {
                distance.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distance), speed * Time.deltaTime);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsAttacking", false);
                this.transform.Translate(0, 0, 0.05f);
            }
            else if (distancesquare <= MeleRange)
            {              
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distance), speed * Time.deltaTime);
                //StartCoroutine(GetComponent<PlayerHealth>().AttackTimer());
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsAttacking", true);

                //StopCoroutine(GetComponent<PlayerHealth>().AttackTimer());
                //Todo: Startcorutine virker, Stopcorotine køre men der sker ikke noget
            }
            else
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", false);
                anim.SetBool("IsIdle", true);
            }
        }
        else if (enemies.Count <= 0)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsIdle", true);
        }
    }
}