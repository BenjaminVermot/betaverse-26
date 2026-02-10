using UnityEngine;

public class SpawningBlock : MonoBehaviour
{
    public GameObject spawnPrefab;

    private GameObject currentSpawnedObject;

    void Start()
    {
        Instantiate(spawnPrefab, transform.position, transform.rotation);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            Instantiate(spawnPrefab, transform.position, transform.rotation);
        }
    }
}
