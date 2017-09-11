using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region UsefullTips
    //[HideInInspector] = hides public, so i will not be shown in inspector
    //[System.Serializable] = shows public
    //[range(0f,1f)] = creates a slider in inspector
    #endregion
    #region variable
    //public Slider healthbar;
    Animator anim;
    [HideInInspector]
    public DamageManager damageManager;
    public string opponent;
    [HideInInspector]
    public int maxHealth = 100;
    [HideInInspector]
    public int curHealth = 100;
    AttackAI attackAI;
    public string UnitName;
    //public GUIStyle customGuiStyle;-
    //float healthBarLength = 100;
    //bool AttackWait;
    //public int Damage = 10;
    //private AttackAI attackAI;
    //GUIStyle style = new GUIStyle();
    //Texture2D texture;
    //Color redColor = Color.red;
    //Color greenColor = Color.green;
    //public Transform target;
    #endregion
        
    private void Update()
    {
        //Change color of healthbar
        //if (curHealth > 50)
        //{
        //    texture.SetPixel(1, 1, greenColor);
        //}

        //if (curHealth < 50)
        //{
        //    texture.SetPixel(1, 1, redColor);
        //}
    }

    void OnGUI()
    {
        #region OnGUI Notes
        //Get position on every unit in the world from camera view
        //then draw a GUI.Box with health and name information
        //Where color depends on tag of the unit
        #endregion
        Vector2 targetPos;
        targetPos = Camera.main.WorldToScreenPoint(transform.position);
        if (gameObject.tag == "Enemy")
        {
            GUI.backgroundColor = Color.blue;
            GUI.color = Color.red;
            //GUI.backgroundColor = Color.white; //Default Color
        }
        else if (gameObject.tag == "Enemy 2")
        {
            //colour.red = 1 - percentage;
            //colour.green = percentage;
            GUI.color = Color.green;
        }
        else
        {
            GUI.color = Color.clear;
        }
        if (curHealth < maxHealth)
        {
            GUI.Box(new Rect(targetPos.x, Screen.height - targetPos.y, 100, 35), UnitName + "\n" + curHealth + "/" + maxHealth);
        }
        else
        {
            GUI.Box(new Rect(targetPos.x, Screen.height - targetPos.y, 100, 20), UnitName);
        }




        //texture.Apply();
        //var myStyle = new GUIStyle(GUI.skin.box);
        //style.normal.background = texture;
        //GUI.Box(new Rect(100, 200, 100, 100), new GUIContent(""), style);
        //GUI.Box(new Rect(targetPos.x, Screen.height - targetPos.y + 20, 100, 20), this.name);

        //GUI.Box(new Rect(targetPos.x, Screen.height - targetPos.y, 0, 0), this.name + "\n" + curHealth + "/" + maxHealth/*,customGuiStyle*/);

        //GUI.Box(new Rect(targetPos.x, Screen.height - targetPos.y, 60, 20), curHealth + "/" + maxHealth);
        //if (curHealth <= 0)
        //{
        //    GUI.Box(new Rect(Screen.width / 2.1f, Screen.height / 2.1f, 100, 25), "you are dead");
        //    Time.timeScale = 0;
        //}
        //GUI.Box(new Rect(10, 40, healthBarLength, 20), curHealth + "/" + maxHealth);

        if (curHealth <= 0) //runs "Dead", kill animation and Ienumerator for wait seconds before destroy object 
        {
            StartCoroutine(Dead());
        }
    }
    public void AddjustCurrentHealth(int adj)
    {
        curHealth -= adj;
        if (curHealth < 0)
            curHealth = 0;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        if (maxHealth < 1)
            maxHealth = 1;
        
        //healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }
    void OnTriggerEnter(Collider c)
    {
        string NameOfUnitsInRange = c.gameObject.transform.parent.parent.parent.GetComponent<AttackAI>().NameOfUnitsInRange; //Can use root instead of parent parent
        string NameOfUnitsInTotal = c.gameObject.transform.parent.parent.parent.GetComponent<AttackAI>().NameOfUnitsInTotal;
        if (c.gameObject.tag == opponent/* && NameOfUnitsInRange == NameOfUnitsInTotal*/)
        {
            //TODO: mobs do not get damaged, when 2 of the same unit are in the same area,
            //and not evry unit are attacking
            int Damage = c.gameObject.transform.GetComponent<DamageManager>().Damage;

            Debug.Log(NameOfUnitsInRange);
            //_________________________________________________________________
            //works with GUI healthbar
            //_________________________________________________________________
            Debug.Log(Damage);
            AddjustCurrentHealth(Damage);
            //anim.SetBool("IsDamaged", true);

            //_________________________________________________________________
            //works with Canvas healthbar
            //_________________________________________________________________
            //healthbar.value -= 30;
            //if (healthbar.value <= 0) {StartCoroutine(Dead());}

        }
    }
    IEnumerator Dead()
    {
        anim.SetBool("Dead", true);             //run animations
        this.gameObject.tag = "Dead";           //changes tag, so other don't target it as enemy
        damageManager.ChangeTagForWeapon();     //change tag for weapon, so it does not do any damage while falling(dead animation)
        yield return new WaitForSeconds(4);     //waits for 4 seconds(time for the dead animation)
        Destroy(this.gameObject);               //Destroy object
    }
    //public IEnumerator AttackTimer() //Wait 3 second
    //{
    //    //if (anim.GetCurrentAnimatorStateInfo(0).IsName("IsAttacking"))
    //    //{
    //    //    AttackWait = false;
    //    //    yield return new WaitForSeconds(3);
    //    //    AttackWait = true;
    //    //}
    //    //AttackWait = true;  
    //}

    void Start()
    {
        //texture = new Texture2D(1, 1);
        //texture.SetPixel(1, 1, greenColor);
        anim = GetComponent<Animator>();
    }
}