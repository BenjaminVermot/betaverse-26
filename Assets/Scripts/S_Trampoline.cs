using UnityEngine;

public class S_Trampoline : MonoBehaviour
{
    public float bounceForce = 40f;

    // Move this to OnCollisionEnter instead of Update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marble"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
   
}
