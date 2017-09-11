using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CreateVariable {

    public string name;
    public GameObject unit;
    public Texture tex;
    public float Rect;
    [HideInInspector]
    public GUIStyle source;
}
