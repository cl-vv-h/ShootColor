using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // destroy anything that collides with this
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");
        Destroy(collision.gameObject);
    }

}
