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
                Debug.Log("jump" + collision.contacts[0].normal);

                rb.AddForce(-collision.contacts[0].normal * bounceForce, ForceMode.Impulse);
            }
        }
    }

}
