using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public Animator anim;
    float audioVolume = 1.0f;
    public AudioSource audioSource;
    public GameObject soundBoom;
    bool fade = false;
    private bool optionsOpen = false;
    public GameObject optionMenu;

	void Start ()
    {
        StartCoroutine(WaitFor(2));
	}
	
    public void onPlay()
    {
        fade = true;
        soundBoom.SetActive(true);
        StartCoroutine(Start(10));
    }

    public void onOptions()
    {
        optionMenu.SetActive(!optionsOpen);
        optionsOpen = !optionsOpen;
    }

    void Update()
    {
        if(fade)
        {
            fadeOut();
        }
    }

    IEnumerator Start(int seconds)
    {
        anim.SetBool("Alpha", false);
        anim.SetBool("Black", true);
        yield return new WaitForSeconds(seconds);
        Application.LoadLevel("Main");
    }
    IEnumerator WaitFor(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.SetBool("Alpha", true);
        anim.SetBool("Black", false);
    }

    void fadeOut()
    {
        if (audioVolume > 0.0f)
        {
            audioVolume -= 0.4f * Time.deltaTime;
            audioSource.volume = audioVolume;
        }
    }
}
