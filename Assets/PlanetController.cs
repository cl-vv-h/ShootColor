using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{   
    // speed of the planet
    public float speed = 5.0f;

    private Dictionary<int, Color> colorDict;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = spawnPoint.transform.position;
        // start with either blue color or red color on sprite renderer (ternary operator)
        colorDict = new Dictionary<int, Color>();
        colorDict.Add(0, Color.red);
        colorDict.Add(1, Color.green);
        colorDict.Add(2, Color.blue);

        GetComponent<SpriteRenderer>().color = colorDict[Random.Range(0,3)];
        
    }

    // Update is called once per frame
    void Update()
    {
        // move down the screen
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

}
