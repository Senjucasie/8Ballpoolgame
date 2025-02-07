using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStick : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _prevPosition;
    private Vector3 _differnce;
    private Vector2 _speed = Vector2.zero;
    private void Awake()
    {
        _transform =transform.parent;  
    }
    private void Update()
    {
       
        if(Input.GetMouseButtonDown(0))
        {
            _prevPosition = Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            _differnce = _prevPosition - Input.mousePosition;
            _prevPosition = Input.mousePosition;
            if (_differnce == Vector3.zero)
                return; 
           if(Mathf.Abs(_differnce.y)>Mathf.Abs(_differnce.x))
            {
               if(_differnce.y < 0)
                {
                    _speed = Vector2.up;
                }
               else
                {
                    _speed = Vector2.up *-1;

                }
            }
           //horizontal swipe
           else
            {
                if (_differnce.x > 0)
                {
                    _speed = Vector2.up;
                }
                else
                {
                    _speed = Vector2.up * -1;
                }
            }
            _transform.Rotate(_speed, Space.World);
        }
       


        //if (Input.GetMouseButton(0))
        //{
        //    _transform.Rotate(Vector3.up,Space.World);
        //}
    }
}
