using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Animator anim;

    void Start () {
        StartCoroutine(StartGame(6));
    }

    IEnumerator StartGame(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        anim.SetBool("Alpha", true);
        anim.SetBool("Black", false);
    }


}
