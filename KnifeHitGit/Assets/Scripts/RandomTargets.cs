using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTargets : MonoBehaviour
{
    [SerializeField] private TargetAndBG[] scriptableObjects;
    [SerializeField] private GameObject _backGround;
    [SerializeField] private GameObject _target;


    private void Start()
    {
        UpdateBGandTarget(Random.Range(0, scriptableObjects.Length));
    }

    private void UpdateBGandTarget(int _takedSO)
    {
        _backGround.GetComponent<SpriteRenderer>().sprite = scriptableObjects[_takedSO].Background;
        _target.GetComponent<SpriteRenderer>().sprite = scriptableObjects[_takedSO].Target;

    }
}