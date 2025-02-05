using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStick : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform =transform.parent;  
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _transform.Rotate(Vector3.up,Space.World);
        }
    }
}
