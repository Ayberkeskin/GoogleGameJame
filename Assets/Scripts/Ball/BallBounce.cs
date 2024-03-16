using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = _rb.velocity;
        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        var speed = _velocity.magnitude;
        var direction = Vector3.Reflect(_velocity.normalized, collision2D.contacts[0].normal);
        _rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
