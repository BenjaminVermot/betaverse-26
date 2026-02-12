using System.Collections; // <--- Ajoutez cette ligne !

using UnityEngine;

public class MarbleScript : MonoBehaviour
{
    public enum MarbleState { Checkpoint1, Checkpoint2, Checkpoint3, Win }
    public GameManager gameManager;

    private SphereCollider TargetSpotCollider;
    private BoxCollider[] CheckPointColliders;

    public ParticleSystem confettis;

    public Material[] materials;
    public MarbleState CurrentState { get; private set; }
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
        gameManager = GameObject.Find("GAME_MANAGER").GetComponent<GameManager>();
        gameManager.updateMarbleArray();

        TargetSpotCollider = GameObject.Find("TargetSpot").GetComponent<SphereCollider>();

        int checkpointLength = gameManager.currentLevelCheckpoints.Length;
        CheckPointColliders = new BoxCollider[checkpointLength];
        for (int i = 0; i < checkpointLength; i++)
        {
            CheckPointColliders[i] = GameObject.Find("CheckPointCollider" + (i + 1)).GetComponent<BoxCollider>();
        }
        CurrentState = MarbleState.Checkpoint1;
    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other == CheckPointColliders[0] && CurrentState == MarbleState.Checkpoint1)
        {
            CurrentState = MarbleState.Checkpoint2;
            UnityEngine.Debug.Log("Checkpoint 2 reached");
            spawnConfettis();
            return;
        }

        if (other == CheckPointColliders[1] && CurrentState == MarbleState.Checkpoint2)
        {
            CurrentState = MarbleState.Checkpoint3;
            spawnConfettis();
            UnityEngine.Debug.Log("Checkpoint 2 reached");
            return;
        }

        if (other == TargetSpotCollider)
        {
            CheckForWin();
            return;
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    void CheckForWin()
    {
        if (CurrentState == MarbleState.Checkpoint3)
        {
            spawnConfettis();
            gameManager.WinLevel();
        }
    }

    void spawnConfettis()
    {
        if (confettis == null) return;
        Instantiate(confettis, transform.position, Quaternion.identity);
    }
}
