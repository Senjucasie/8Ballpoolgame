using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    private Vector3 _prevPosition;
    private Vector3 _differnce;

    public event Action<float> OnSwiped;
    private EventSystem _eventSystem;
    private bool _rotaeCueStick;
    private bool clickaboveball = false, clickrightofball = false;

    [SerializeField] private Transform _cueBall;
    [SerializeField] private Camera _camera;

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
                return;

            _rotaeCueStick = true;
            _prevPosition = Input.mousePosition;

            Vector3 ballscreenpos = _camera.WorldToScreenPoint(_cueBall.position);

            clickaboveball = _prevPosition.y > ballscreenpos.y;
            clickrightofball = _prevPosition.x > ballscreenpos.x;
        }

       
        if (!_rotaeCueStick) return;

        if (Input.GetMouseButtonUp(0))
        {
            _rotaeCueStick = false;
        }

        if (Input.GetMouseButton(0))
        {
            _differnce = _prevPosition - Input.mousePosition;
            _prevPosition = Input.mousePosition;
            float _speed;

            if (_differnce == Vector3.zero)
                return;

            //Vertical Swipe
            if (Mathf.Abs(_differnce.y) > Mathf.Abs(_differnce.x))
            {
                _speed = Mathf.Sign(_differnce.y);

                if (clickrightofball)
                    _speed *= -1;
            }
            //horizontal swipe
            else
            {
                _speed = Mathf.Sign(_differnce.x);

                if (!clickaboveball)
                    _speed *= -1;
            }
            OnSwiped?.Invoke(_speed);
         
        }
    }
  
}
