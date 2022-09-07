using DG.Tweening;
using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int _minValue = 5;
    public int MaxValue = 12;

    [SerializeField] private float _duration = 4f;
    public int Hp { get; private set; }

    public Action Broken;
    void Start()
    {
        System.Random random = new System.Random();
        Rotate();
        Hp = random.Next(_minValue, MaxValue);
    }
    private void Rotate() =>
        transform.DORotate(new Vector3(0, 0, 360), _duration, RotateMode.FastBeyond360).SetLoops(-1);

    public void GetDamage(int damage) { 
        if(damage > 0)
            Hp -= damage;
        if (Hp == 0) 
            Broken?.Invoke();
    }
   
}
