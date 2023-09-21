using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{


    public float timeSurvive = -9.65f;

    private GameObject scoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        timeSurvive += Time.deltaTime;
        scoreTxt.GetComponent<TMP_Text>().text = timeSurvive.ToString("0.00") + "s";
    }
}
