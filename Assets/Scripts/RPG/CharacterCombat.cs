using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {


    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    CharacterStats myStats;
    public float attackDelay = .6f;

    //Animator controller
    public event System.Action OnAttack; //quick way to make a delegate of void, and no arguments

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack (CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(doDamage(targetStats, attackDelay));
            if (OnAttack != null)     //Animator controller
                OnAttack();     //Animator controller

            attackCooldown = 1f / attackSpeed;
        }

    }

    IEnumerator doDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());

    }
}
