using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Vector3 _prevPosition;
    private Vector3 _differnce;

    [SerializeField]private CueStickHandler _cueStickHandler;


    private event Action<float> OnSwiped;

    // Start is called before the first frame update
    void Start()
    {
        OnSwiped += _cueStickHandler.RotateCueStick;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _prevPosition = Input.mousePosition;
        }
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
    private void OnDestroy()
    {
        OnSwiped -= _cueStickHandler.RotateCueStick;
    }
}
