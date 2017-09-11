using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePiece : MonoBehaviour {
    public CreateVariable[] unitList;
    int i = 0;

    private void OnGUI()
    {
        //foreach (var Unit in unitList)
        //{

        //    if (Unit.tex)
        //    {
        //        GUILayout.Button(Unit.tex);
        //    }
        //    else
        //    {
        //        GUILayout.Button(Unit.name);
        //    }

        //Instantiate(Resources.Load("Prefabs\\" + Unit.unit), this.transform.position, transform.rotation);

        //}

        for (int i = 0; i < unitList.Length; i++) // Henter objecter fra en liste (drag in i Unity)
        {
            transform.localScale += new Vector3(1F, 1, 1);
            if (GUILayout.Button(unitList[i].tex) && unitList[i].tex != null);


            //else GUILayout.Button(unitList[i].name);
        }
    }

}
