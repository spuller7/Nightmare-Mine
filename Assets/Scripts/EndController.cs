using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour {

    public Animator whiteAnim;
    public Animator blackAnim;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            whiteAnim.SetBool("End", true);
            StartCoroutine(End(4));
        }

    }

    IEnumerator End(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject.Find("FPSController(Clone)").GetComponent<AudioSource>().enabled = false;
        blackAnim.SetBool("Alpha", false);
        blackAnim.SetBool("Black", true);
        yield return new WaitForSeconds(seconds);
        Application.LoadLevel("Main Menu");
    }
}
