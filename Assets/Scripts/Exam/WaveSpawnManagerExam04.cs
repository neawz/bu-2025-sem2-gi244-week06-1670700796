using UnityEngine;

public class WaveSpawnManagerExam04 : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public bool enableWaveCycling;

    private int currentWave = 0;
    [SerializeField] private float waveEndTime = 0f;

    void Start()
    {
        WaveSpawn();    
    }

    void Update()
    {
        if (currentWave >= waveConfigurations.Length)
        {
            return;
        }

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
                Debug.Log("All waves completed!");
                if (enableWaveCycling)
                {
                    Debug.Log("Restart Wave 1");
                    currentWave = 0;
                    WaveSpawn();
                }
            }
            else
            {
                WaveSpawn();
            }
        }
    }
    public void WaveSpawn()
    {
        waveController.StartWave(waveConfigurations[currentWave]);
        waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
        Debug.Log($"Wave: {currentWave + 1}");
    }
}