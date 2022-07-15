using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    Rigidbody[] _limbsRB;
    [SerializeField] Animator _animator;

    private void Start()
    {
        _limbsRB = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < _limbsRB.Length; i++)
        {
            _limbsRB[i].maxAngularVelocity = 3;
            _limbsRB[i].isKinematic = true;
        }


    }
    internal void EnableRagdoll()
    {
        for (int i = 0; i < _limbsRB.Length; i++) _limbsRB[i].isKinematic = false;
        _animator.enabled = false;
    }

    internal void KillRagdoll(Vector3 point)
    {
        EnableRagdoll();
        for (int i = 0; i < _limbsRB.Length; i++) _limbsRB[i].AddExplosionForce(25f, point, 1.5f, .5f, ForceMode.Impulse);
        
    }

    /*internal void DisableRagdoll()
    {
        for (int i = 0; i < _limbsRB.Length; i++) _limbsRB[i].isKinematic = true;
        _animator.enabled = true;
    }*/
    
    private void Update()
    {
        //   if (Input.GetKeyDown(KeyCode.J)) EnableRagdoll();
        //   if (Input.GetKeyDown(KeyCode.K)) DisableRagdoll();
        transform.rotation = Quaternion.Euler(0,0,0);   //хз почему, но даже bake into pose не помогало от вращения в процессе анимации.
    }
}
