using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class björn : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _roatationSpeed;

    private Rigidbody2D _rigidbody;
    private test _test;
    private Vector2 _targetDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _test = GetComponent<test>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_test.AwareOfPlayer)
        {
            _targetDirection = _test.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }


    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _roatationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }


    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody.velocity = transform.up * _speed;
        }
    }
}
