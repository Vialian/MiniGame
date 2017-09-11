using UnityEngine;

[System.Serializable]
public class UnitVariables {
    public string name;
    public GameObject unit;
    [Header("Damage")]
    public float Damage;
    public float DetectRange;
    public float MeleRange;
    [Header("Health")]
    [Range(10,200)]
    public float MaxHP;

}
