
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HitSlider : MonoBehaviour, IPointerUpHandler
{
    private Slider _slider;

    public void Init()
    {
        _slider = GetComponent<Slider>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _slider.value = 0;
    }
}
