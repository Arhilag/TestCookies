using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private float _xPosition;
    public Action OnButtonDown;

    public static PlayerInput Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity,layerMask))
        {
            _xPosition = hit.point.x;
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnButtonDown?.Invoke();
        }
    }

    public float GetXPosition()
    {
        return _xPosition;
    }
}
