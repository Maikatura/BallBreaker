using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GameManager;

public class NewCardSlot : MonoBehaviour
{
    public Direction direction;

    public Canvas canvas;

    public bool isInteractable = true;

    private void Start()
    {
        GameManager.instance.ShowInteractables();
        canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }
    }

    private void OnMouseDown()
    {
        if (isInteractable)
        {
            for (int i = 0; i < CardSlotManager.instance.slots.Count; i++)
            {
                if (CardSlotManager.instance.slots[i].gameObject == this.gameObject)
                {
                    CardSlotManager.instance.currentItem = i;
                    break;
                }
            }
            Activate();
        }
    }

    public void Activate()
    {
        GameManager.instance.HideInteractables();
        canvas.gameObject.SetActive(true);
        CardSlotManager.instance.DisableInteractable();
    }

    //public void ChangeCurrentDirection()
    //{
    //    this.direction = this.gameObject.GetComponent<ButtonScript>().direction;
    //    GameManager.instance.ShowInteractables();
    //    CardSlotManager.instance.EnableInteractable();
    //    canvas.gameObject.SetActive(false);
    //}

    public void ChangeCurrentDirection()
    {
        this.direction = this.gameObject.GetComponent<ButtonScript>().direction;

        if (CardSlotManager.instance.currentItem < CardSlotManager.instance.slots.Count)
        {
            CardSlotManager.instance.currentItem++;
            CloseMenu();
            CardSlotManager.instance.slots[CardSlotManager.instance.currentItem].GetComponent<NewCardSlot>().Activate();
        }
        else
        {
            CloseMenu();
        }
    }

    public void CloseMenu()
    {
        GameManager.instance.ShowInteractables();
        CardSlotManager.instance.EnableInteractable();
        canvas.gameObject.SetActive(false);
    }
}
