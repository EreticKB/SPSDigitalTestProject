using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float _scanRadius;
    [SerializeField] float _scanTimer;
    Collider _target;
    float _scanTimerValue;
    bool _nonThrowing;
    [SerializeField] float _throwingItemSpawnTime;
    [SerializeField] GameObject _throwingItem;
    [SerializeField] Transform _parent;
    [SerializeField] float _throwingForce;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(ThrowFruit());
        }
        _scanTimerValue += Time.deltaTime;
        if (_scanTimerValue > _scanTimer)
        {
            _scanTimerValue = 0;
            Collider[] array = Physics.OverlapBox(transform.position + Vector3.up * 1.5f, new Vector3(_scanRadius, 2, _scanRadius));
            //Collider target = Array.Find(array, x=>CompareTag("Player")); //Не находило, похоже по письменным источникам я так и не разберусь с этим методом, нужен человек.
            _target = null;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTag("Player"))
                {
                    _target = array[i];
                    break;
                }
            }
        }

    }
    private void FixedUpdate()
    {
        if (_target != null && _nonThrowing)
        {
            if (Physics.Raycast(transform.position + Vector3.up * 1.5f, _target.transform.position - (transform.position + Vector3.up * 1.5f), out RaycastHit hit, 20))
            {
                // if (hit.transform.CompareTag("Player")) StartCoroutine(ThrowFruit());
            }
        }
    }

    IEnumerator ThrowFruit()
    {
        _animator.SetTrigger("Throw");
        //GameObject throwingItem = Instantiate(_throwingItem,new Vector3(0.1142f, -0.2229f, 0), _throwingItem.transform.rotation, _parent);
        GameObject throwingItem = Instantiate(_throwingItem, _parent.position + new Vector3(0.1142f, -0.2229f, 0), _throwingItem.transform.rotation, _parent);
        while (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
        {
            yield return null;
        }
        while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < _throwingItemSpawnTime)
        {
            yield return null;
        }
        throwingItem.transform.parent = null;
        Rigidbody body = throwingItem.GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.AddForce((_target.transform.position+Vector3.up*1.2f - throwingItem.transform.position).normalized * _throwingForce, ForceMode.Impulse); ;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawCube(new Vector3(transform.position.x, 1.5f, transform.position.z), new Vector3(_scanRadius, 2, _scanRadius));
    }
}
