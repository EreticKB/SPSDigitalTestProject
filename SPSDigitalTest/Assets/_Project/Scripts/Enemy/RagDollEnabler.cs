using UnityEngine;

public class RagDollEnabler : MonoBehaviour
{
    [SerializeField] Collider[] limbs;
    [SerializeField] Rigidbody[] _limbsRB;
    [SerializeField] Animator _animator;
    public void EnableRagdoll()
    {
        for (int i = 0; i < limbs.Length; i++)
        {
            _limbsRB[i].velocity = Vector3.zero;
            limbs[i].enabled = true;
        }

        _animator.enabled = false;
    }
    public void DisableRagdoll()
    {
        for (int i = 0; i < limbs.Length; i++) limbs[i].enabled = false;
        _animator.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) EnableRagdoll();
        if (Input.GetKeyDown(KeyCode.K)) DisableRagdoll();
    }
}
