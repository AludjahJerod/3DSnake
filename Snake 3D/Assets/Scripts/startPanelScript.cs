using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPanelScript : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
        par.SetActive(false);
    }

    public GameObject pan;
    public GameObject par;
    public AudioSource audiomain;
    public void OkClick()
    {
        pan.SetActive(false);
        Time.timeScale = 1f;
        par.SetActive(true);
        audiomain.Play();
    }
}
