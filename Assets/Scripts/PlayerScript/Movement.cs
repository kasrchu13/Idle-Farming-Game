using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    //references
    private PlayerStats _stats;

    //references inside player
    private Rigidbody2D _rb;

    //paramters
    private FrameInput _frameInput;
    private Vector2 _frameVelocity;
    private float _horizontal;
    private float _vertical;

    private void Start() {
        _stats = DataManager.Instance._playerSO;
        _rb = GetComponent<Rigidbody2D>();

        _frameInput = new FrameInput();

    }
    private void Update() {
        GatherInput();
        HandleMotion();
        ApplyMovement();
    }

    private void GatherInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        _frameInput.MoveDir = new Vector2(_horizontal, _vertical);
    }

    private void HandleMotion()
    {
        //accelerate
        if(_frameInput.MoveDir.x != 0 || _frameInput.MoveDir.y != 0) 
        {
            var tarSpeed = _stats._speed * _frameInput.MoveDir.normalized;
            _frameVelocity = Vector2.MoveTowards(_frameVelocity, tarSpeed, _stats._accel);
        }

        //deccelerate
        if(_frameInput.MoveDir.x == 0 && _frameInput.MoveDir.y == 0) 
        {
            var tarSpeed = Vector2.zero;
            _frameVelocity = Vector2.MoveTowards(_frameVelocity, tarSpeed, _stats._accel);
        }
    }

    private void ApplyMovement() => _rb.velocity = _frameVelocity;
    
    
}
public struct FrameInput
{
    public Vector2 MoveDir;
}
