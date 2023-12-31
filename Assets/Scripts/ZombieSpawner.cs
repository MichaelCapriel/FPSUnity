using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public GameObject ZombiePreFab;
    public List<Transform> spawnPoints;
    int wave;

    private void Awake()
    {
        Instance = this;
        wave = 1;
    }

    public void CountZombies()
    {
        Zombie[] zombies = FindObjectsOfType<Zombie>();

        if(zombies.Length <= 1 )
        {
            SpawnWaveOfZombies();
        }
    }

    void SpawnWaveOfZombies()
    {
        Debug.Log("SpawnWaveOFZombies");
        
        wave++;

        for (int i = 0; i < wave; i++)
        {
            int rand = Random.Range(0, spawnPoints.Count -1);

            Instantiate(ZombiePreFab, spawnPoints[rand].position, Quaternion.identity, transform);
        }

        HUD.Instance.UpdateWaveUI(wave);
    }



}
