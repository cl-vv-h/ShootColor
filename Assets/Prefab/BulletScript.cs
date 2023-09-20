using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float speed;
    private GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        body = GameObject.FindGameObjectWithTag("Body");
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = transform.position - body.transform.position;
        Quaternion bodyRota = body.transform.rotation;
        transform.rotation = bodyRota;
        rb.velocity = speed * direction.normalized;
        rb.MoveRotation(bodyRota);
        // color of bullet = currentColor value in ShooterController script
        gameObject.GetComponent<SpriteRenderer>().color = player.GetComponent<ShooterController>().currentColor;
    }

    // Update is called once per frame
    void Update()
    {

        if(Mathf.Abs(transform.position.x) > 3 || transform.position.y > 7)
        {
            Destroy(gameObject);
        }

        // move bullet forward
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // gameobject tag is wall
        if (other.gameObject.tag == "Wall")
        {
            // destroy wall
           //Destroy(other.gameObject);
            Debug.Log("wall destroyed!");
            // update player current color to wall color
            player.GetComponent<ShooterController>().currentColor = other.gameObject.GetComponent<SpriteRenderer>().color;
        }
        if(other.gameObject.tag == "Planet" )
        {
            // add color into play
            addColor(other.gameObject.GetComponent<SpriteRenderer>().color);
            // destroy planet && bullet destroyed
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("planet destroyed!");
        }
    }

    void addColor(Color color)
    {
        Color curColor = player.GetComponent<ShooterController>().currentColor;
        curColor.r = Mathf.Min(1, color.r + curColor.r);
        curColor.g = Mathf.Min(1, color.g + curColor.g);
        curColor.b = Mathf.Min(1, color.b + curColor.b);
        player.GetComponent<ShooterController>().currentColor = curColor;
    }
}
