using System;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public Action<Collider> OnCollisionBat;
    public Action<Collider> OnCollisionWall;
    public static Action OnTriggerBackboard;
    public static Action OnTriggerBat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bat")
        {
            OnCollisionBat?.Invoke(other);
            OnTriggerBat?.Invoke();
        }
        
        if (other.tag == "Wall")
        {
            OnCollisionWall?.Invoke(other);
        }
        
        if (other.tag == "Backboard")
        {
            OnCollisionWall?.Invoke(other);
            OnTriggerBackboard?.Invoke();
        }
    }
}
