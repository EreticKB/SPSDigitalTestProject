using UnityEngine;

public class ShitController : MonoBehaviour
{
    [SerializeField] Rigidbody shit;
    [SerializeField] float velocity;
    void FixedUpdate()
    {
        shit.velocity = Vector3.zero;
        shit.angularVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) shit.velocity = transform.forward * velocity;
        if (Input.GetKey(KeyCode.S)) shit.velocity = transform.forward * -velocity;
        if (Input.GetKey(KeyCode.A)) shit.velocity = transform.right * -velocity;
        if (Input.GetKey(KeyCode.D)) shit.velocity = transform.right * velocity;
        if (Input.GetKey(KeyCode.E)) shit.angularVelocity = new Vector3(0, velocity, 0);
        if (Input.GetKey(KeyCode.Q)) shit.angularVelocity = new Vector3(0, -velocity, 0);
    }
}
