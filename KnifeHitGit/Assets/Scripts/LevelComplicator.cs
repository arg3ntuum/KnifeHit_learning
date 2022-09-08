using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelComplicator : MonoBehaviour {
    [SerializeField] private List<GameObject> _knives = new List<GameObject>();

    private void Start()
    {
        int PPLevel = PlayerPrefs.GetInt("Level");
        if (PPLevel > 2)
            SpawnKnifes(PPLevel);

    }
    private void SpawnKnifes(int level) {
        System.Random random = new System.Random();
        int levelConvert = Convert.ToInt32(Math.Round(Convert.ToDecimal(level / 3)));
        if (levelConvert > _knives.Count)
            levelConvert = _knives.Count;
        for (int i = 0; i < levelConvert; i++)
            _knives[i].SetActive(true);

    }
}
