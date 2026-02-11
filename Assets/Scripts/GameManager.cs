using System.Collections;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 0;
    public GameObject[] currentLevelBlocks;
    public GameObject[] currentLevelMarbles;
    public GameObject[] currentLevelCheckpoints;
    public GameObject[] currentLevelDispensers;


    public GameObject checkPointSpawnerPrefab;
    public GameObject dispenserSpawnerPrefab;

    public Material[] checkpointMaterials; // Array pour stocker les matériaux des checkpoints


    void Start()
    {
        LoadNextLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadNextLevel()
    {

        currentLevel++;
        destroyCurrentLevel();
        spawnNextLevel();

        StartCoroutine(updateArrays());


        // Logic to load the next level goes here
    }

    void destroyCurrentLevel()
    {
        foreach (GameObject block in currentLevelBlocks)
        {
            Destroy(block);
            currentLevelBlocks = new GameObject[0];
        }

        foreach (GameObject marble in currentLevelMarbles)
        {
            Destroy(marble);
            currentLevelMarbles = new GameObject[0];
        }

        foreach (GameObject checkpoint in currentLevelCheckpoints)
        {
            Destroy(checkpoint);
            currentLevelCheckpoints = new GameObject[0];
        }

        foreach (GameObject dispenser in currentLevelDispensers)
        {
            Destroy(dispenser);
            currentLevelDispensers = new GameObject[0];
        }
    }

    void spawnNextLevel()
    {
        if (currentLevel == 1)
        {
            Instantiate(checkPointSpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Instantiate(dispenserSpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        }

        if (currentLevel == 2)
        {
            Instantiate(checkPointSpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Instantiate(dispenserSpawnerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }


    }

    IEnumerator updateArrays()
    {
        yield return new WaitForSeconds(0.5f);

        currentLevelBlocks = GameObject.FindGameObjectsWithTag("Block");
        currentLevelMarbles = GameObject.FindGameObjectsWithTag("Marble");
        currentLevelCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        currentLevelDispensers = GameObject.FindGameObjectsWithTag("Dispenser");

        setCheckpointsOrder();
    }

    void setCheckpointsOrder()
    {
        for (int i = 0; i < currentLevelCheckpoints.Length; i++)
        {
            // 1. On cherche l'enfant
            Transform colliderTransform = currentLevelCheckpoints[i].transform.Find("CheckPointCollider");
            UnityEngine.Debug.Log("Collider trouvé : " + colliderTransform.name);

            // 2. On vérifie d'abord s'il existe !
            if (colliderTransform != null)
            {
                // On le renomme
                colliderTransform.gameObject.name = "CheckPointCollider" + (i + 1);

                // 3. On récupère le parent (Correction : colliderTransform.parent est déjà un Transform)
                Transform planeTransform = colliderTransform.parent;
                UnityEngine.Debug.Log("Parent trouvé : " + planeTransform.name);

                // 4. On récupère le Renderer sur ce parent
                Renderer planeRenderer = planeTransform.GetComponent<Renderer>();

                if (planeRenderer != null && i < checkpointMaterials.Length)
                {
                    planeRenderer.material = checkpointMaterials[i];
                }
            }

        }
    }
}
