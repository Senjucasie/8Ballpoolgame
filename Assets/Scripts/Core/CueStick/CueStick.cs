using UnityEngine;

public class CueStick : MonoBehaviour
{
    private Transform _parentTransform;
    [SerializeField]private float _maxPulldistance;
    [SerializeField] private float _strikeIntensity = 1;
    private CueBall _cueBall;
    private float _speed;
    private LineRenderer _lineRenderer;


    public void Init(LineRenderer linerenderer,Transform parenttransform,CueBall cueball)
    {
        _cueBall = cueball;
        _parentTransform = parenttransform;
        _speed = 100f;
        _lineRenderer = linerenderer;
    }

    public void Rotate(float direction)
    {
        Vector2 rotationvector = direction * _speed * Time.deltaTime * Vector2.down;
        _parentTransform.Rotate(rotationvector, Space.World);
        DrawAimLine();
    }

    public void Pull(float power )
    {
        transform.Translate(Vector3.right * _maxPulldistance * power,Space.Self);
    }
     
    public void Strike(float distance)
    {
        transform.Translate( _maxPulldistance * distance * Vector3.left, Space.Self);
        Vector3 force = distance * _strikeIntensity * _parentTransform.right;
        _cueBall.Strike(force);
    }
    private void DrawAimLine()
    {
        _lineRenderer.SetPosition(0,_parentTransform.position);
        _lineRenderer.SetPosition(1, _parentTransform.right*3+_parentTransform.position);
    }
}

