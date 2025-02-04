using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarnessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _PlayerAwarnessDistance;

    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovment>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= _PlayerAwarnessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
