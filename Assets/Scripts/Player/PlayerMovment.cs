using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{ 
    [SerializeField]private float _speed=8f;
    [SerializeField] private float _jumpingPower=12f;
    
    
    private float _horizontal;
    private bool _isFacingRight = true;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

  
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        Jump();
        Flip();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position,0.2f,_groundLayer);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
        }
        /*   eğer ne kadar uzun basarsa o kadar fazla zıplasın istersek bu kodu yorum satırından çıkarıcaz
        if (Input.GetButtonUp("Jump")&& _rb.velocity.y>0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }*/
    }
    
    
    //Karakterin yönünü sağ sola çeviren fonk.
    private void Flip()
    {
        if (_isFacingRight&& _horizontal<0||!_isFacingRight&& _horizontal>0)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
