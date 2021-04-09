using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] interactables;

    public enum Direction { none, forward, backwards, left, right, leftAndUp, rightAndUp, leftAndDown, rightAndDown }
    public Sprite up, down, left, right, upRight, downRight, upLeft, downLeft;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HideInteractables()
    {
        foreach (GameObject item in interactables)
        {
            item.SetActive(false);
        }
    }

    public void ShowInteractables()
    {
        foreach (GameObject item in interactables)
        {
            item.SetActive(true);
        }
    }
}
