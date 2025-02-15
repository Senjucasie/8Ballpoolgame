using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CueBall : MonoBehaviour
{
    private Rigidbody _rigidBody;
    
    public void Init()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

   public void Strike(Vector3 force)
    {
        _rigidBody.AddForce(force, ForceMode.Impulse);
    }
}
