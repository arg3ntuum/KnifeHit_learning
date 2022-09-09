using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSelecter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer prefabKnife;
    [SerializeField] private SkinKnife[] _skinKnifes;

    public void ChangeKnife(int element) {
        prefabKnife.sprite = _skinKnifes[element].SpriteKnife;
    }

}
