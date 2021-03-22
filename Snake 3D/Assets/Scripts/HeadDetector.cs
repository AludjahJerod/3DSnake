using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HeadDetector : MonoBehaviour
{
    public SnakeMovement snake;
    public UnityEvent onAppleEaten;
    public UnityEvent Lose;

    private void Awake()
    {
        if (onAppleEaten == null)
            onAppleEaten = new UnityEvent();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Snake")
        {
            //Debug.Log("GAME OVER SELF BITEEE");
            Lose.Invoke();
        }
        if (other.tag == "Apple")
        {
            //Debug.Log("Appleeeeee");
            snake.UpgradeSnake();
            Destroy(other.gameObject);
            onAppleEaten.Invoke();
        }
        if(other.tag == "Water")
        {
            //Debug.Log("Glouglou");
            Lose.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            //Debug.Log("GAME OVER");
            Lose.Invoke();
        }

        if (collision.collider.tag == "Snake")
        {
            //Debug.Log("GAME OVER SELF BITEEE");
            Lose.Invoke();
        }
    }
}
