using UnityEngine;

public class CueStick : MonoBehaviour
{
    private Transform _transform;
    [SerializeField]private float _maxPulldistance;
    [SerializeField] private float _strikeIntensity = 1;
    private CueBall _cueBall;

    private float _speed;


    public void Init(Transform parenttransform,CueBall cueball)
    {
        _cueBall = cueball;
        _transform = parenttransform;
        _speed = 10f;
    }

    public void Rotate(float direction)
    {
        Vector2 rotationvector = direction * _speed * Time.deltaTime * Vector2.down;
        _transform.Rotate(rotationvector, Space.World);
    }

    public void Pull(float power )
    {
        transform.Translate(Vector3.left * _maxPulldistance * power,Space.Self);
    }
     
    public void Strike(float distance)
    {
        transform.Translate( _maxPulldistance * distance * Vector3.left, Space.Self);
        Vector3 force = distance * _strikeIntensity * _transform.right;
        _cueBall.Strike(force);
    }
}

