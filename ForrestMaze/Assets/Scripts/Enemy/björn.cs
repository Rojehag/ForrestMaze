using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class björn : MonoBehaviour
{
    [SerializeField]
    private float _walkingSpeed;
    [SerializeField]
    private float _runingSpeed;

    bool playerNearby = false;

    [SerializeField]
    private float _roatationSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarnessController _PlayerAwarnessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;

    Animator animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _PlayerAwarnessController = GetComponent<PlayerAwarnessController>();
        _targetDirection = transform.up;
        animator = GetComponent<Animator>();
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

        playerNearby = false;
    }

    private void HandleRandomDirectionChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;

        if (_changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-80f, 80f);
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

        playerNearby = true;
    }


    private void SetVelocity()
    {
        if (playerNearby == false)
        {
            _rigidbody.velocity = transform.up * _walkingSpeed;
            animator.SetFloat("WolfWalk", 1);
        }

        if (playerNearby == true)
        {
            _rigidbody.velocity = transform.up * _runingSpeed;
            animator.SetFloat("WolfWalk", 1);
        }
    }

}
