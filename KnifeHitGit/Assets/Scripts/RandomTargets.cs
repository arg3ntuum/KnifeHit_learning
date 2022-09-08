using UnityEngine;

public class RandomTargets : MonoBehaviour
{
    [SerializeField] private LevelSkin[] scriptableObjects;
    [SerializeField] private SpriteRenderer _backGround;
    [SerializeField] private SpriteRenderer _target;


    private void Start()
    {
        UpdateBGandTarget(Random.Range(0, scriptableObjects.Length));
    }

    private void UpdateBGandTarget(int _takedSO)
    {
        _backGround.sprite = scriptableObjects[_takedSO].Background;
        _target.sprite = scriptableObjects[_takedSO].Target;

    }
}