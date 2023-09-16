using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public float decreaseSpeed;
    public float limitTime;

    private SpriteRenderer sr;
    private float initWidth;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // Get a random color when game starts.
        sr = gameObject.GetComponent<SpriteRenderer>();
        int[] color = { 255, 255, 255 };

        int randomSeed = Random.Range(0, 6);
        if (randomSeed>=3)
        {
            color[randomSeed - 3] = 0;

        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == randomSeed)
                {
                    continue;
                }
                color[i] = 0;
            }
        }
        sr.color = new Color(color[0], color[1], color[2]);

        // Save the original width and set timer.
        initWidth = transform.localScale.x;
        timer = limitTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime*decreaseSpeed;
        Vector3 ls = transform.localScale;
        float newX = initWidth * timer / limitTime > 0 ? initWidth * timer / limitTime : 0;
        transform.localScale = new Vector3(newX, ls.y, ls.z);
    }
}
