using UnityEngine;

public class SpawningBlock : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Vector3 spawnRotation;

    private GameObject currentSpawnedObject;


    void Start()
    {
        Instantiate(spawnPrefab, transform.position, Quaternion.Euler(spawnRotation));
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            Instantiate(spawnPrefab, transform.position, Quaternion.Euler(spawnRotation));
        }
    }
}
