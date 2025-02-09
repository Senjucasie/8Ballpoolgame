using UnityEngine;

public class CueStickHandler : MonoBehaviour
{
     [SerializeField]private CueStick _cueStick;
     private InputHandler _input;

    public void Init(InputHandler input)
    {
        _input =input;
        SubscribeEvents();
        _cueStick.Init(transform);
    }

    private void SubscribeEvents() 
    {
        _input.OnSwiped += RotateCueStick;
    }

    private void RotateCueStick(float angle)
    {
        _cueStick.Rotate(angle);
    }

    private void OnDestroy()
    {
        _input.OnSwiped -= RotateCueStick;
    }
}
