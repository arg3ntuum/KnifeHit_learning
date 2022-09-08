using DG.Tweening;
using DG.Tweening.Core;
using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int _minValue = 5;
    public int MaxValue = 12;

    [SerializeField] private float _duration = 4f;
    public int Hp { get; private set; }
    private System.Random random = new System.Random();

    public Action Broken;
    void Start()
    {
        Rotate();
        Hp = random.Next(_minValue, MaxValue);
    }
    private void Rotate()
    {
        GetDirectionMove(GetRandomDirection()).SetLoops(-1);
    }
    private int GetRandomDirection() => 
        random.Next(-3, 2) > 0 ? 1 : -1;
    private Tweener GetDirectionMove(int directionMove) =>
        transform.DORotate(new Vector3(0, 0, directionMove * 360), _duration, RotateMode.FastBeyond360);
        //transform.DORotate(new Vector3(0, 0, directionMove * 360), _duration, RotateMode.FastBeyond360);
    public void GetDamage(int damage) { 
        if(damage > 0)
            Hp -= damage;
        if (Hp == 0) 
            Broken?.Invoke();
    }
   
}
