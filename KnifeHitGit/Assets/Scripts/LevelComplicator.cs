using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelComplicator : MonoBehaviour {
    [SerializeField] private List<GameObject> knives = new List<GameObject>();

    private void Start()
    {
        int PPLevel = PlayerPrefs.GetInt("Level");
        if (PPLevel > 2)
            SpawnKnifes(PPLevel);

    }
    private void SpawnKnifes(int level) {
        System.Random random = new System.Random();

        for (int i = 0; i < Convert.ToInt32(Math.Round(Convert.ToDecimal(level / 3))); i++)
            knives[i].SetActive(true);

    }
}
