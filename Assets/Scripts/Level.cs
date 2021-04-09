//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.SceneManagement;

//public class Level : MonoBehaviour
//{
//    public int index;
//    public string name;
//    public bool isUnlocked = false;

//    public Sprite unlocked, locked;
//    SpriteRenderer sr;


//    private void Start()
//    {
//        sr = GetComponent<SpriteRenderer>();     
//    }

//    public void ChangeSprite()
//    {
//        if (isUnlocked)
//        {
//            sr.sprite = unlocked;
//        }
//        else
//        {
//            sr.sprite = locked;
//        }
//    }

//    public void OnMouseDown()
//    {
//        if (isUnlocked)
//        {
//            SceneManager.LoadScene(name);
//        }
//    }
//}
