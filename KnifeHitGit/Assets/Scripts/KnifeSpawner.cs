using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private Knife knifePrefab;
    
    [SerializeField] public List<SpriteRenderer> SpriteRenderers;

    private Vector3Int randomRange = new Vector3Int(0, -3, 0);
    public Action Win;
    public Action KnifeAdd;
    private void Start()
    {
        CreateNew();
    }
    private void CreateNew() {
        KnifeAdd?.Invoke();
        var newKnife = Instantiate(knifePrefab, randomRange, Quaternion.identity);
        SpriteRenderers.Add(newKnife.GetComponent<SpriteRenderer>());
        newKnife.isStuck += StuckedTarget;
        newKnife.IsCollisionKnife += StuckedKnife;

    }

    private void StuckedTarget(Knife knife) {
        knife.isStuck -= StuckedTarget;
        knife.IsCollisionKnife -= StuckedKnife;
        CreateNew();
    }

    private void StuckedKnife(Knife knife) {
        Win?.Invoke();
    }
}
