using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    public static LevelManager Instance
    {
        get { return instance; }
    }

    public Button[] buttons;
    public Sprite unlocked, locked;

    int levelsUnlocked;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        UpdateWorldMap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerPrefs.SetInt("levelsUnlocked", buttons.Length);
        }
    }

    public void UpdateWorldMap()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].image.sprite = locked;
            buttons[i].GetComponentInChildren<Text>().enabled = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
            buttons[i].image.sprite = unlocked;
            buttons[i].GetComponentInChildren<Text>().enabled = true;
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    //public void UnlockLevel()
    //{
    //    int currentLevel = SceneManager.GetActiveScene().buildIndex;

    //    if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
    //    {
    //        PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
    //    }
    //}
}