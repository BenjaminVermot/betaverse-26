using UnityEngine;

public class SpawningMarble : MonoBehaviour
{
    public GameObject marblePrefab;
    float yet;
    public float interval = 1.0f;

    void Update()
    {
        yet += Time.deltaTime;

        if (yet >= interval)
        {
            yet -= interval;

            spawnMarble();
        }
    }

    void spawnMarble()
    {
        Instantiate(marblePrefab, transform.position, Quaternion.identity);
    }
}
