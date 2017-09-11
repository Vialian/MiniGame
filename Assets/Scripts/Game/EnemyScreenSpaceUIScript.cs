﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScreenSpaceUIScript : MonoBehaviour {
    private EnemyScript enemyScript;

    public Canvas canvas;
    public GameObject healthPrefab;

    public float healthPanelOffset = 0.35f;
    public GameObject healthPanel;
    private Text enemyName;
    private Slider healthSlider;
    // Use this for initialization
    void Start () {
        enemyScript = GetComponent<EnemyScript>();
        healthPanel = Instantiate(healthPrefab) as GameObject;
        healthPanel.transform.SetParent(canvas.transform, false);

        enemyName = healthPanel.GetComponentInChildren<Text>();
        enemyName.text = enemyScript.monsterName;

        healthSlider = healthPanel.GetComponentInChildren<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        healthSlider.value = enemyScript.HP / (float)enemyScript.maxHP;

        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y + healthPanelOffset, transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        healthPanel.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
    }
}
