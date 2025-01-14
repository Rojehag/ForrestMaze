using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannibal : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _roatationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarnessController _PlayerAwarnessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _PlayerAwarnessController = GetComponent<PlayerAwarnessController>();
        _targetDirection = transform.up;
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
    }

    private void HandleRandomDirectionChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;

        if (_changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (_PlayerAwarnessController.AwareOfPlayer)
        {
            _targetDirection = _PlayerAwarnessController.DirectionToPlayer;
        }
    }

    private void RotateTowardsTarget()
    {


        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _roatationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }


    private void SetVelocity()
    {
        _rigidbody.velocity = transform.up * _speed;
    }

}
