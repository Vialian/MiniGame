using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour {
    [HideInInspector]
    public int Damage;

    private void Update()
    {
        //string NameOfUnitsInRange = gameObject.transform.parent.parent.parent.GetComponent<AttackAI>().NameOfUnitsInRange; //Can use root instead of parent parent
        //string NameOfUnitsInTotal = gameObject.transform.parent.parent.parent.GetComponent<AttackAI>().NameOfUnitsInTotal;
        //if (NameOfUnitsInRange == NameOfUnitsInTotal)
        //{
            Damage = Random.Range(15, 20);

        //}
        //else
        //{
        //    Damage = 0;
        //}


    }

    public void ChangeTagForWeapon()
    {
        this.gameObject.tag = "Dead";   //Change weapon tag, so it no longer will do any damge
    }

}
