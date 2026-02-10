using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MarbleScript : MonoBehaviour
{
    public enum MarbleState { Checkpoint1, Checkpoint2, Checkpoint3, Win }

    private SphereCollider TargetSpotCollider;
    private BoxCollider[] CheckPointColliders;

    private ParticleSystem confettis;
    public MarbleState CurrentState { get; private set; }
    void Start()
    {
        TargetSpotCollider = GameObject.Find("TargetSpot").GetComponent<SphereCollider>();
        CheckPointColliders = new BoxCollider[3];
        for (int i = 0; i < 3; i++)
        {
            CheckPointColliders[i] = GameObject.Find("CheckPointCollider" + (i + 1)).GetComponent<BoxCollider>();
        }
        CurrentState = MarbleState.Checkpoint1;

        confettis = GameObject.Find("Confettis").GetComponent<ParticleSystem>();
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
    }

    void CheckForWin()
    {
        if (CurrentState == MarbleState.Checkpoint3)
        {
            spawnConfettis();
            CurrentState = MarbleState.Win;
        }
    }

    void spawnConfettis()
    {
        confettis.Play();
    }
}
