using UnityEngine;

public class CueStickHandler : MonoBehaviour
{
     [SerializeField]private CueStick _cueStick;

    //Dependency
     private InputHandler _input;
     private HitSlider _hitSlider;


    public void Init(InputHandler input,HitSlider slider)
    {
        _hitSlider = slider;
        _input =input;
        SubscribeEvents();
        _cueStick.Init(transform);
    }

    private void SubscribeEvents() 
    {
        _input.OnSwiped += RotateCueStick;
        _hitSlider.SliderMoved += PullCueStick;
    }

    private void RotateCueStick(float angle)
    {
        _cueStick.Rotate(angle);
    }

    private void PullCueStick(float power)
    {
        _cueStick.Pullstick(power);
    }

    private void OnDestroy()
    {
       UnSubScribeEvents();
    }

    private void UnSubScribeEvents()
    {
        _input.OnSwiped -= RotateCueStick;
        _hitSlider.SliderMoved -= PullCueStick;
    }
}
