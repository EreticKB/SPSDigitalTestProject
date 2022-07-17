using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float _scanRadius;
    [SerializeField] float _scanTimer;
    float _scanTimerValue;
    private void Update()
    {
        _scanTimerValue += Time.deltaTime;
        if (_scanTimerValue > _scanTimer)
        {
            _scanTimerValue = 0;
            Physics.CheckBox(transform.position, new Vector3(_scanRadius, 2, _scanRadius));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector3(transform.position.x, 1.5f, transform.position.z), new Vector3(_scanRadius, _scanRadius, _scanRadius));
    }
}
