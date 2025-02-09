using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]private HitSlider _hitSlider;
    

    public void Init()
    {
        _hitSlider.Init();
    }
}
