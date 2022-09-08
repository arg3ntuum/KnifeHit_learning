using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Knife : MonoBehaviour
{
    [SerializeField] private float _speed = 80f;
    private Rigidbody2D _rigidbody2D;

    public Action<Knife> isStuck;
    public Action<Knife> IsCollisionKnife;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

    }

    private void Attack()
    {

        _rigidbody2D.AddForce(Vector2.up * _speed * 5, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
        {
            TransformKnife(target);
        }
        else if (collision.gameObject.TryGetComponent(out Knife knife))
        {
            IsCollisionKnife?.Invoke(this);
        }
    }
    public void TransformKnife(Target target)
    {
        transform.SetParent(target.transform);
        isStuck?.Invoke(this);
        if (_rigidbody2D != null)
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        target.GetDamage(1);
        enabled = false;
    }
}
