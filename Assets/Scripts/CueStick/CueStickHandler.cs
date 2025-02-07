using UnityEngine;

[RequireComponent(typeof(CueStick))]
public class CueStickHandler : MonoBehaviour
{
    [SerializeField] private CueStick _cueStick;


    public void Start()
    {
        _cueStick = GetComponent<CueStick>();
        _cueStick.Init(transform.parent);
    }

    public void RotateCueStick(float angle)
    {
        _cueStick.Rotate(angle);
    }
}
