using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class ButtonScript : MonoBehaviour
{
    public Direction direction;

    public GameObject canvas;

    public void ChangeCurrentDirection()
    {
        GetComponentInParent<NewCardSlot>().direction = this.direction;
        ChangeSpriteByDirection();

        if (CardSlotManager.instance.currentItem < CardSlotManager.instance.slots.Count - 1)
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

    public void ChangeSpriteByDirection()
    {
        switch (direction)
        {
            case Direction.none:
                break;
            case Direction.forward:
                GetComponentInParent<SpriteRenderer>().sprite = instance.up;
                break;
            case Direction.backwards:
                GetComponentInParent<SpriteRenderer>().sprite = instance.down;
                break;
            case Direction.left:
                GetComponentInParent<SpriteRenderer>().sprite = instance.left;
                break;
            case Direction.right:
                GetComponentInParent<SpriteRenderer>().sprite = instance.right;
                break;
            case Direction.leftAndUp:
                GetComponentInParent<SpriteRenderer>().sprite = instance.upLeft;
                break;
            case Direction.rightAndUp:
                GetComponentInParent<SpriteRenderer>().sprite = instance.upRight;
                break;
            case Direction.leftAndDown:
                GetComponentInParent<SpriteRenderer>().sprite = instance.downLeft;
                break;
            case Direction.rightAndDown:
                GetComponentInParent<SpriteRenderer>().sprite = instance.downRight;
                break;
            default:
                break;
        }
    }
}
