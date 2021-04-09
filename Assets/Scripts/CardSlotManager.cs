using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class CardSlotManager : MonoBehaviour
{
    public static CardSlotManager instance;

    public int numberOfSlots;

    public List<GameObject> slots = new List<GameObject>();
    public GameObject slot;

    private float offset = 0;
    public float offsetAmount = 2;

    public Direction direction;
    public List<Direction> listOfDirections = new List<Direction>();

    public int currentItem = 0;

    private void Start()
    {
        instance = this;

        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject temp = Instantiate(slot, new Vector2(this.transform.position.x + offset, this.transform.position.y), Quaternion.identity);
            slots.Add(temp);
            offset += offsetAmount;
        }
    }

    public void OnStart()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            listOfDirections.Add(slots[i].GetComponent<NewCardSlot>().direction);
        }
    }

    public void DisableInteractable()
    {
        foreach (GameObject item in slots)
        {
            item.GetComponent<NewCardSlot>().isInteractable = false;
        }
    }

    public void EnableInteractable()
    {
        foreach (GameObject item in slots)
        {
            item.GetComponent<NewCardSlot>().isInteractable = true;
        }
    }
}
