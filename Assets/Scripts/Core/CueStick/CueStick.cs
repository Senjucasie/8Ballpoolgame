using UnityEngine;

public class CueStick : MonoBehaviour
{
    private Transform _transform;
    [SerializeField]private float _maxPulldistance;

    public void Init(Transform parenttransform)
    {
        _transform = parenttransform;
    }

    public void Rotate(float direction)
    {
        Vector2 rotationvector = Vector2.up *direction;
        _transform.Rotate(rotationvector, Space.World);
    }

    public void Pullstick(float power )
    {
        transform.Translate(Vector3.right * _maxPulldistance * power,Space.Self);
    }
     
}

