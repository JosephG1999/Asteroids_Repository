using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;
    
    public Asteroid asteroidPrefab;
    
    
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 3.0f, this.spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * 8.0f;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            
            float variance = Random.Range(-15.0f, 15.0f);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, 
            rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
    
}
