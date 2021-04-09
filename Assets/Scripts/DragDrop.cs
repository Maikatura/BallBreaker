using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameManager;

public class DragDrop : MonoBehaviour
{
    private bool place = true;
    public bool inSlot = false;
    public Vector2 startPos;

    public Direction direction;

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnMouseDown()
    {
        place = false;
        inSlot = false;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        place = true;

        StartCoroutine(DropBack());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot") && place && !collision.GetComponent<CardSlot>().hasACard)
        {
            inSlot = true;
            transform.position = collision.transform.position;
            place = false;
            collision.GetComponent<CardSlot>().direction = this.direction;
            collision.GetComponent<CardSlot>().hasACard = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Slot") && collision.GetComponent<CardSlot>().hasACard && inSlot)
        {
            collision.GetComponent<CardSlot>().hasACard = false;
        }
    }

    IEnumerator DropBack()
    {
        yield return new WaitForSeconds(0.1f);

        if (!inSlot)
        {
            transform.position = startPos;
        }
    }
}
