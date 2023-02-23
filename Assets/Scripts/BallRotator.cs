using UnityEngine;

public class BallRotator : MonoBehaviour
{
    [SerializeField] private Transform _visualisation;
    private float _speed;
    private void Update()
    {
        _visualisation.Rotate(Vector3.right * _speed);
    }

    public void SetDirection(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,
            Vector3.SignedAngle(Vector3.right,newDirection, Vector3.up),0));
    }

    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}
