using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{ 
    
    #region Components
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private TrailRenderer _tr;
    [SerializeField] private Animator _anim;
    #endregion
    
    #region MovementVariables
    [Header("MovementVariables")]
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpingPower = 12f;
    #endregion
    
    #region InternalVariables
    [Header("JumpVariables")]
    private float _horizontal;
    private bool _isFacingRight = true;
    private bool _doubleJump;
    
    
    [Header("DashVariables")]
    [SerializeField] private bool _canDash = true;
    [SerializeField] private bool _isDashnig;
    [SerializeField] private float _dashingPower = 16f;
    [SerializeField] private float _dashingTime = 0.2f;
    [SerializeField] private float _dashingCooldown = 1f;
    #endregion
    

    void Update()
    {
        if(_isDashnig)
            return;
        
        _horizontal = Input.GetAxisRaw("Horizontal");
        Jump();
        Flip();
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if(_isDashnig)
            return;
        
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
        _anim.SetFloat("Speed",Mathf.Abs(_horizontal));
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position,0.2f,_groundLayer);
    }

    private void Jump()
    {
        _anim.SetBool("Jump", !IsGrounded());
        if (IsGrounded()&& !Input.GetButton("Jump"))
        {
            _doubleJump = false;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded()|| _doubleJump)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);

                _doubleJump= !_doubleJump;
            }
        }

        /*
         
         eğer ne kadar uzun basarsa o kadar fazla zıplasın istersek bu kodu yorum satırından çıkarıcaz
         
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

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashnig = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * _dashingPower, 0f);
        _tr.emitting = true;
        yield return new WaitForSeconds(_dashingTime);
        _tr.emitting = false;
        _rb.gravityScale = originalGravity;
        _isDashnig = false;
        yield return new WaitForSeconds(_dashingCooldown);
        _canDash = true;
    }
}
