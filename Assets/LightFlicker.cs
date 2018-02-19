using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    float timeOn = 5.0f;
    float timeOff = 0.08f;
    private float changeTime = 0;

    void Update()
    {
        if (Time.time > changeTime)
        {
            gameObject.GetComponent<Light>().enabled = !gameObject.GetComponent<Light>().enabled;
            if (gameObject.GetComponent<Light>().enabled)
            {
                timeOn = Random.Range(4.0f, 12.0f);
                changeTime = Time.time + timeOn;
            }
            else
            {
                timeOff = Random.Range(0.05f, 0.1f);
                changeTime = Time.time + timeOff;
                
            }
        }
    }
}
