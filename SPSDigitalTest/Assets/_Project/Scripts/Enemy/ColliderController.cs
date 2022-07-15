using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField] EnemyController _root;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Foot"))
        {
            //_root.KillRagdoll(collision.collider.transform.position);
            //gameObject.GetComponent<Rigidbody>().AddForce(collision.GetContact(0).normal.normalized*collision.gameObject.GetComponent<KickForce>().kickForce);
        }
        if (collision.transform.CompareTag("Environment"))
        {
            //if()
        }
    }
}
