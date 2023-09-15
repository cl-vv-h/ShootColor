using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    // variable to store color value for sprite renderer
    public Color currentColor;
    public float shootingRate;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // start color = white
        currentColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float rota = transform.rotation.z / transform.rotation.w;
        if (Input.GetKey(KeyCode.RightArrow) && rota > -1)
        {
            transform.eulerAngles += new Vector3(0, 0, -5);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && rota < 1)
        {
            transform.eulerAngles -= new Vector3(0, 0, -5);
        }

        if (timer > (1/shootingRate))
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
