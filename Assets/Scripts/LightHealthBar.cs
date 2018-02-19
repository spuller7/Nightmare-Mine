using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHealthBar : MonoBehaviour {

    public float lightLevel = 4f;
    public Light[] lights;
    private const float coef = 0.05f;
    public GameObject bar;
    float audioVolume = 1.0f;
    bool fade = false;
    GameObject breath;
    public GameObject scaryDeath;
    public GameObject image;
    public GameObject bar2;

    void Update()
    {
        if(fade)
        {
            fadeOut();
        }

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (lightLevel > 0.0f)
        {
            lightLevel -= Time.deltaTime / 53;
            for (int i = 0; i < lights.Length; i++)
            {
                float barTransfor = lightLevel / 4;
                bar.transform.localScale = new Vector3(barTransfor, 1, 1);
                lights[i].intensity = lightLevel;

                float rand = Random.Range(0.0f, 1000.0f);
                if (Mathf.Floor(rand) == 2.0f)
                {
                    float timeOff = Random.Range(0.05f, 0.1f);
                    StartCoroutine(flicker(timeOff, lights[i]));
                }
            }
        }
        if(lightLevel < 0.05)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                
                lights[i].enabled = false;
                if(lights[i].gameObject.transform.parent.Find("Sphere"))
                {
                    lights[i].gameObject.transform.parent.Find("Sphere").gameObject.SetActive(false);
                }
            }
            image.SetActive(false);
            bar2.SetActive(false);
            StartCoroutine(EndGame(31.0f));
            GameObject go = GameObject.Find("FPSController(Clone)");
            go.GetComponent<AudioSource>().enabled = false;
            breath = go.transform.Find("Breathing").gameObject;
        }
    }

    IEnumerator flicker(float seconds, Light light)
    {
        light.enabled = false;
        yield return new WaitForSeconds(seconds);
        light.enabled = true;
    }

    IEnumerator EndGame(float seconds)
    {
        fade = true;
        yield return new WaitForSeconds(5);
        scaryDeath.SetActive(true);
        yield return new WaitForSeconds(seconds);
        Application.LoadLevel("Main Menu");
    }

    void fadeOut()
    {
        
        AudioSource audioSource = breath.GetComponent<AudioSource>();
        
        if (audioVolume > 0.0f)
        {
            audioVolume -= 0.4f * Time.deltaTime;
            audioSource.volume = audioVolume;
        }
    }
}
