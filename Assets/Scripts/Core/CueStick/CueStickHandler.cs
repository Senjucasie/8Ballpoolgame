using UnityEngine;

public class CueStickHandler : MonoBehaviour
{
     [SerializeField]private CueStick _cueStick;

    //Dependency
     private InputHandler _input;
     private HitSlider _hitSlider;
     [SerializeField]private LineRenderer _lineRenderer;


    public void Init(InputHandler input,HitSlider slider,CueBall cueball)
    {
        _hitSlider = slider;
        _input =input;
        SubscribeEvents();
        _cueStick.Init(_lineRenderer,transform, cueball);
    }

    private void SubscribeEvents() 
    {
        
        _input.OnSwiped += RotateCueStick;
        _hitSlider.SliderMoved += PullCueStick;
        _hitSlider.SliderReset += StrikeCueStick;

    }

    private void RotateCueStick(float angle)
    {
        _cueStick.Rotate(angle);
    }

    private void PullCueStick(float power)
    {
        _cueStick.Pull(power);
    }
    private void StrikeCueStick(float distance)
    {
        _cueStick.Strike(distance);
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
