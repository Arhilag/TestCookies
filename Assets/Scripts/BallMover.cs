using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    [SerializeField] private float _maxSpeed = 0.5f;
    [SerializeField] private float _speedChange = 0.0005f;
    private Vector3 _direction;
    private bool _isMove;

    public Action<Vector3> OnChangeDirection;
    public Action<float> OnChangeSpeed;

    public void StartMove()
    {
        if (!_isMove)
        {
            _isMove = true;
            _direction = new Vector3(Random.Range(-1f,1f), 0,1).normalized;
            OnChangeSpeed?.Invoke(_speed);
            OnChangeDirection?.Invoke(_direction);
        }
    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            transform.position += _speed * _direction;
            UpdateSpeed();
        }
    }

    public void MirrorXDirection()
    {
        _direction.x = -_direction.x;
        OnChangeDirection?.Invoke(_direction);
    }

    public void MirrorZDirection()
    {
        _direction.z = -_direction.z;
        OnChangeDirection?.Invoke(_direction);
    }

    public void BounceWithAddXDirection(float additionalXDirection)
    {
        _direction.x += additionalXDirection;
        _direction.z = Math.Abs(_direction.z);
        _direction = _direction.normalized;
        OnChangeDirection?.Invoke(_direction);
    }

    private void UpdateSpeed()
    {
        if (_speed < _maxSpeed)
        {
            _speed += _speedChange;
            OnChangeSpeed?.Invoke(_speed);
        }
    }
}
