
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]private HitSlider _hitSlider;

    public HitSlider GetHitSlider() { return _hitSlider; }

    public void Init()
    {
        _hitSlider.Init();
    }
}
