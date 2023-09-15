using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // speed of the planet
    public float speed = 5.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = spawnPoint.transform.position;
        // start with either blue color or red color on sprite renderer (ternary operator)
        GetComponent<SpriteRenderer>().color = Random.Range(0, 2) == 0 ? Color.blue : Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        // move down the screen
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

}