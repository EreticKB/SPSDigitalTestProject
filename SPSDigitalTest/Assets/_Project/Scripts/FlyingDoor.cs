using UnityEngine;

public class FlyingDoor : MonoBehaviour
{
    bool _disable;
    Collider _collider;
    Rigidbody _rigidBody;
    private void Start()
    {
        _disable = false;
        _collider = GetComponent<MeshCollider>();
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (_rigidBody.velocity.sqrMagnitude < 0.04f && _disable)
        {
            _rigidBody.isKinematic = true;
            _collider.enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Foot")) _disable = true;
    }
}
