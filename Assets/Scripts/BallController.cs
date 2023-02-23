using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private BallCollision _collisionModule;
    [SerializeField] private BallMover _moverModule;
    [SerializeField] private BallRotator _rotationModule;
    [SerializeField] private float _speedModifier = 70;

    private void Awake()
    {
        _collisionModule.OnCollisionBat += OnTriggerBat;
        _collisionModule.OnCollisionWall += OnTriggerWall;
        _moverModule.OnChangeDirection += OnChangeDirection;
        _moverModule.OnChangeSpeed += OnChangeSpeed;
    }

    private void OnDestroy()
    {
        _collisionModule.OnCollisionBat -= OnTriggerBat;
        _collisionModule.OnCollisionWall -= OnTriggerWall;
        PlayerInput.Instance.OnButtonDown -= OnButtonDown;
        _moverModule.OnChangeDirection -= OnChangeDirection;
        _moverModule.OnChangeSpeed -= OnChangeSpeed;
    }

    private void Start()
    {
        PlayerInput.Instance.OnButtonDown += OnButtonDown;
    }

    private void OnTriggerWall(Collider collider)
    {
        if (collider.transform.localScale.x > collider.transform.localScale.z)
        {
            _moverModule.MirrorXDirection();
            return;
        }
        if (collider.transform.localScale.x < collider.transform.localScale.z)
        {
            _moverModule.MirrorZDirection();
            return;
        }

        if (Math.Abs(transform.position.x - collider.transform.position.x) > 
            Math.Abs(transform.position.z - collider.transform.position.z))
        {
            _moverModule.MirrorXDirection();
            return;
        }

        if (Math.Abs(transform.position.x - collider.transform.position.x) < 
            Math.Abs(transform.position.z - collider.transform.position.z))
        {
            _moverModule.MirrorZDirection();
            return;
        }
            
        _moverModule.MirrorXDirection();
        _moverModule.MirrorZDirection();
    }

    private void OnTriggerBat(Collider collider)
    {
        _moverModule.BounceWithAddXDirection(transform.position.x - collider.transform.position.x);
    }
    
    private void OnButtonDown()
    {
        _moverModule.StartMove();
        PlayerInput.Instance.OnButtonDown -= OnButtonDown;
    }
    
    private void OnChangeSpeed(float newSpeed)
    {
        _rotationModule.SetSpeed(newSpeed*_speedModifier);
    }

    private void OnChangeDirection(Vector3 newDirection)
    {
        _rotationModule.SetDirection(new Vector3(newDirection.z,newDirection.y,-newDirection.x));
    }
}
