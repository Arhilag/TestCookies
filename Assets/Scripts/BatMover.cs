using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMover : MonoBehaviour
{
    private float _xPosition;
    private float _xRestriction = 3.7f;
    private void Update()
    {
        _xPosition = PlayerInput.Instance.GetXPosition();
        if (_xPosition > _xRestriction)
        {
            _xPosition = _xRestriction;
        }
        if (_xPosition < -_xRestriction)
        {
            _xPosition = -_xRestriction;
        }
        transform.position = new Vector3(_xPosition, transform.position.y, transform.position.z);
    }
}
