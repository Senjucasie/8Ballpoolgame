
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HitSlider : MonoBehaviour, IPointerUpHandler,IDragHandler
{
    private Slider _slider;
    private float _oldvalue;

    //Events
    public event Action<float> SliderMoved;
    public event Action<float> SliderReset;


    public void Init()
    {
        _slider = GetComponent<Slider>();
    }

    public void OnDrag(PointerEventData eventData)
    {

        SliderMoved?.Invoke(_slider.value - _oldvalue);
        _oldvalue =_slider.value;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(_slider.value>0)
        {
            SliderReset?.Invoke( _slider.value );
            _slider.value = 0;
            _oldvalue = 0;

        }
        
    }

}
