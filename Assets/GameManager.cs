using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    // planet
    public GameObject planetPrefab;
    public GameObject planetSpawnPoint;
    public float planetLowerX;
    public float planetUpperX;
    public int planetSpawnRate;
    public int planetSpawnDelay;

    // wall
    public GameObject wallPrefab;
    public GameObject wallSpawnPoint;
    public float wallLowerX;
    public float wallUpperX;
    //public int wallSpawnRate;
    //public int wallSpawnDelay;

    // variable to hold panel UI object
    public GameObject startGamepanel;
    // variable to hold end game panel UI object
    //public GameObject endGamePanel;

    

    // Start is called before the first frame update
    void Start()
    {

        //InvokeRepeating("InstantiatePlanet", planetSpawnDelay, planetSpawnRate);
        //InvokeRepeating("InstantiateWall", wallSpawnDelay, wallSpawnRate);


        // delay 10 seconds using coroutine
        StartCoroutine(waiter());
        
        //InvokeRepeating("InstantiateWall", wallSpawnDelay, wallSpawnRate);


    }
    IEnumerator waiter()
    {
        

        //Wait for 4 seconds
        yield return new WaitForSecondsRealtime(10);
        InvokeRepeating("InstantiatePlanet", planetSpawnDelay, planetSpawnRate);
        startGamepanel.gameObject.SetActive(false);
    }


    void InstantiatePlanet()
    {
        // position equal to the planetSpawnPoint position
        Vector3 pos = planetSpawnPoint.transform.position;
        pos.x = Random.Range(planetLowerX, planetUpperX);
        Instantiate(planetPrefab, pos, Quaternion.identity);
    }

    void InstantiateWall()
    {
        // position equal to the planetSpawnPoint position
        Vector3 pos = wallSpawnPoint.transform.position;
        // randomly select -1 or 1
        int direction = Random.Range(0, 2) == 0 ? -1 : 1;
        pos.x = direction == -1 ? wallUpperX : wallLowerX;
        Instantiate(wallPrefab, pos, Quaternion.identity);
    }
}
