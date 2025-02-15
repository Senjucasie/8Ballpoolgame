using UnityEngine;

public class CueStick : MonoBehaviour
{
    private Transform _transform;
    [SerializeField]private float _maxPulldistance;
    [SerializeField] private float _strikeIntensity = 1;
    private CueBall _cueBall;


    public void Init(Transform parenttransform,CueBall cueball)
    {
        _cueBall = cueball;
        _transform = parenttransform;
    }

    public void Rotate(float direction)
    {
        Vector2 rotationvector = Vector2.up *direction;
        _transform.Rotate(rotationvector, Space.World);
    }

    public void Pull(float power )
    {
        transform.Translate(Vector3.right * _maxPulldistance * power,Space.Self);
    }
     
    public void Strike(float distance)
    {
        transform.Translate( _maxPulldistance * distance * Vector3.left, Space.Self);
        Vector3 force = distance * _strikeIntensity * _transform.right;
        _cueBall.Strike(force);
    }
}

