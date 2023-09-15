using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float speed;
    private Vector3 shootDirct;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = transform.position - player.transform.position;
        Quaternion playerRota = player.transform.rotation;
        transform.rotation = playerRota;
        rb.velocity = speed * direction.normalized;
        rb.MoveRotation(playerRota);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(Mathf.Abs(transform.position.x) > 3 || transform.position.y > 9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
