using UnityEngine;
using TMPro;

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

    //public float timeSurvive = -9.65f;

    //private GameObject scoreTxt;

    private bool shootPressed=false;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        // start color = white

        // currentColor = new Color(0,0,0); // black

        currentColor = Color.black;

        shootingRate = 5;

        // scoreTxt = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerColor();
        timer += Time.deltaTime;
       // timeSurvive += Time.deltaTime;
        // scoreTxt.GetComponent<TMP_Text>().text = timeSurvive.ToString("0.00") + "s";

        GameObject body = GameObject.FindGameObjectWithTag("Body");
        
        // Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        float tmpSpeed = horizontalInput * mvSpeed * Time.deltaTime;
        float horizontalSpeed = Mathf.Abs(transform.position.x) < 2.5 ? tmpSpeed :
                (transform.position.x<0? Mathf.Max(0, tmpSpeed) : Mathf.Min(0, tmpSpeed));
        float verticalSpeed = verticalInput * mvSpeed * Time.deltaTime;
        transform.Translate(new Vector3(horizontalSpeed, verticalSpeed, 0));

        // Player rotation
        //float rota = transform.rotation.z / transform.rotation.w;
        if (Input.GetKey(KeyCode.E))
        {
            body.transform.eulerAngles += new Vector3(0, 0, -1*rotSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            body.transform.eulerAngles -= new Vector3(0, 0, -1*rotSpeed);
        }

        // Press 'R' to reset the color
        if (Input.GetKey(KeyCode.R))
        {
            currentColor = Color.black;
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

    void UpdatePlayerColor()
    { 
        GetComponent<SpriteRenderer>().color = currentColor;
    }

    public void CalculateNewColor(Color ColorToBeMixed) // planet color
    {
        Debug.Log(ColorToBeMixed.ToString());
        Color result = Color.Lerp(currentColor, ColorToBeMixed, 0.5f); // 50%
        currentColor = result;
        UpdatePlayerColor();
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
