using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverScript : MonoBehaviour
{
    public GameObject pan;
    void Start()
    {
        
    }

    public void GameOver()
    {
        pan.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        pan.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SnakeBackup");
    } 
}
