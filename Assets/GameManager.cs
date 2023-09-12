using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject planetPrefab;
    public GameObject planetSpawnPoint;
    public int lowerX;
    public int upperX;
    public int spawnRate;
    public int spawnDelay;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiatePlanet", spawnDelay, spawnRate);
    }

    void InstantiatePlanet()
    {
        // position equal to the planetSpawnPoint position
        Vector3 pos = planetSpawnPoint.transform.position;
        pos.x = Random.Range(lowerX, upperX);
        Instantiate(planetPrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
