using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melon : MonoBehaviour
{
    [SerializeField] Collider _collider;
    [SerializeField] Rigidbody _body;
    float _timer;
    private void Update()
    {
        if (!_body.isKinematic) _timer += Time.deltaTime;
        if (_timer > 0.05f) _collider.isTrigger = false;
    }
}
