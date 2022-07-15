using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyAnimationController _ragdoll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    internal void KillRagdoll(Vector3 point)
    {
        _ragdoll.KillRagdoll(point);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Foot")) KillRagdoll(other.transform.position);
        if (other.transform.CompareTag("Environment")|| other.transform.CompareTag("Enemy"))
        {
            Rigidbody othersBody = other.GetComponent<Rigidbody>();
            if (othersBody.velocity.sqrMagnitude > 2.25f && !othersBody.isKinematic) _ragdoll.EnableRagdoll();
        }
    }
}
