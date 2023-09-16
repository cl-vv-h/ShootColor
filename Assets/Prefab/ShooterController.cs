using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    // variable to store color value for sprite renderer
    public Color currentColor;
    public float shootingRate;

    public float mvSpeed;
    public float rotSpeed;

    public float horizontalInput;

    public float verticalInput;

    private bool shootPressed=false;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // start color = white
        currentColor = Color.blue;
        shootingRate = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        GameObject body = GameObject.FindGameObjectWithTag("Body");
        // Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        float tmpSpeed = horizontalInput * mvSpeed * Time.deltaTime;
        float horizontalSpeed = Mathf.Abs(transform.position.x) < 2.5 ? tmpSpeed :
                (transform.position.x<0? Mathf.Max(0, tmpSpeed) : Mathf.Min(0, tmpSpeed));
        float verticalSpeed = verticalInput * mvSpeed * Time.deltaTime;
        transform.Translate(new Vector3(horizontalInput * mvSpeed * Time.deltaTime, verticalInput * mvSpeed * Time.deltaTime, 0));

        // Player rotation
        float rota = transform.rotation.z / transform.rotation.w;
        if (Input.GetKey(KeyCode.E) && rota > -1)
        {
            body.transform.eulerAngles += new Vector3(0, 0, -1*rotSpeed);
        }
        if (Input.GetKey(KeyCode.Q) && rota < 1)
        {
            body.transform.eulerAngles -= new Vector3(0, 0, -1*rotSpeed);
        }

        // Player shooting
        if (Input.GetKey(KeyCode.Space))
        {
            shootPressed = true;
        }
        else
        {
            shootPressed = false;
        }
        if (timer > 1/shootingRate)
        {
            if (shootPressed)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
