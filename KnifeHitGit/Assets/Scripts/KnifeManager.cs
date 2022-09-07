using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _prefabKnife;
    [SerializeField] private SkinKnife[] skinKnifes;

    public void ChangeKnife(int element) {
        _prefabKnife.sprite = skinKnifes[element].SpriteKnife;
    }
}
