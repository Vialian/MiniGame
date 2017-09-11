using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChangerWeapon : MonoBehaviour {
    public int Damage = 19;




    public void ChangeTagForWeapon()
    {
        this.gameObject.tag = "Dead";   //Change weapon tag, so it no longer will do any damge
    }


}
