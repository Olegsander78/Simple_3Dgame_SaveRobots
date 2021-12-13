using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public Vector3 MoveDirection;
    public float MoveDistance;

    private Vector3 _startPos;
    private bool _movingToStart;

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        if (_movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPos, Speed * Time.deltaTime);
            if (transform.position == _startPos)
            {
                _movingToStart = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPos + (MoveDirection * MoveDistance), Speed * Time.deltaTime);
            if (transform.position == _startPos + (MoveDirection * MoveDistance))
            {
                _movingToStart = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GameOver();
        }
    }

}
