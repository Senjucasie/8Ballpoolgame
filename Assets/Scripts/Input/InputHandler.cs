using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    private Vector3 _prevPosition;
    private Vector3 _differnce;

    public event Action<float> OnSwiped;
    private EventSystem _eventSystem;
    private bool _isOverUI;
 
    public void Init()
    {
        _eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            if (_eventSystem.IsPointerOverGameObject())
            {
                _isOverUI = true;
                return;
            }
            _prevPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isOverUI = false;
        }
        if (_isOverUI) return;
       
        if (Input.GetMouseButton(0))
        {
            _differnce = _prevPosition - Input.mousePosition;
            _prevPosition = Input.mousePosition;
            float _speed = 1;
            if (_differnce == Vector3.zero)
                return;

            //Vertical Swipe
            if (Mathf.Abs(_differnce.y) > Mathf.Abs(_differnce.x))
            {
                _speed = _differnce.y < 0 ? -1 : 1;
            }
            //horizontal swipe
            else
            {
                _speed = _differnce.x > 0 ? 1 : -1;
            }
            OnSwiped?.Invoke(_speed);
         
        }
    }
  
}
