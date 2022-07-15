using UnityEngine;

public class Kick : MonoBehaviour
{
    [SerializeField] internal Transform _parent;
    [SerializeField] internal float kickForce;
    [SerializeField] Animator _animator;
    [SerializeField] Collider _foot;
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetTrigger("Kick");
            _animator.ResetTrigger("KickInterupt");
            _foot.enabled = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("KickInterupt");
            _animator.ResetTrigger("Kick");
            _foot.enabled = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.transform.CompareTag("Environment")) return;
        _foot.enabled = false;
        collision.collider.GetComponent<Rigidbody>().AddForceAtPosition(_parent.transform.rotation * Vector3.forward * kickForce+Vector3.up*100, collision.GetContact(0).point);
    }

}
