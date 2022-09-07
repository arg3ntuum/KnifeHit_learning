using System;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private float _speed = 80f;

    public Action<Knife> isStuck;
    public Action<Knife> IsCollisionKnife;
    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            Attack();
            Debug.Log("Attack");
        }

    }

    private void Attack() {

        _rigidbody2D.AddForce(Vector2.up * _speed * 5, ForceMode2D.Impulse);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
        {
            transform.SetParent(collision.transform);
            isStuck?.Invoke(this);
            _rigidbody2D.velocity = Vector2.zero;
            target.GetDamage(1);
            enabled = false;
        }
        else if (collision.gameObject.TryGetComponent(out Knife knife)){
            IsCollisionKnife?.Invoke(this);
        }
    }
}
