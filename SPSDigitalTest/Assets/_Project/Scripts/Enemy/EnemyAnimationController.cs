using System.Collections;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    Rigidbody[] _limbsRB;
    Collider[] _limbsCollider;
    [SerializeField] Animator _animator;


    private void Start()
    {
        _limbsRB = GetComponentsInChildren<Rigidbody>();
        _limbsCollider = GetComponentsInChildren<Collider>();
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
        StartCoroutine(HalfLife());
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
    IEnumerator HalfLife()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < _limbsRB.Length; i++) _limbsRB[i].isKinematic = true;
        for (int i = 0; i < _limbsCollider.Length; i++) _limbsCollider[i].enabled = false;
    }
}
