using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameManager;

public class BallScript : MonoBehaviour
{
    public int speed = 2;

    public Direction direction;
    public List<Direction> listOfDirections = new List<Direction>();

    public List<GameObject> squares = new List<GameObject>();
    public List<GameObject> blocks = new List<GameObject>();
    [SerializeField]
    int totalAmountOfSquare = 0;

    public GameObject winScreen;

    private int index = 0;
    private bool gotAHit = false, start = false, blockHit = false;
    private float distance = 100f;
    public LayerMask mask;

    float offsetX = 0f, offsetY = 0f;
    float offsetValue = 1f;

    RaycastHit2D hit;

    void Start()
    {
        winScreen.SetActive(false);
    }

    void Update()
    {
        if (start)
        {
            if (totalAmountOfSquare == 0)
            {
                Win();
            }

            if (!gotAHit)
            {
                switch (direction)
                {
                    case Direction.forward:
                        GoToNext(Vector2.up);
                        break;
                    case Direction.backwards:
                        GoToNext(Vector2.down);
                        break;
                    case Direction.left:
                        GoToNext(Vector2.left);
                        break;
                    case Direction.right:
                        GoToNext(Vector2.right);
                        break;
                    case Direction.leftAndUp:
                        GoToNext(Vector2.left, Vector2.up);
                        break;
                    case Direction.rightAndUp:
                        GoToNext(Vector2.right, Vector2.up);
                        break;
                    case Direction.leftAndDown:
                        GoToNext(Vector2.left, Vector2.down);
                        break;
                    case Direction.rightAndDown:
                        GoToNext(Vector2.right, Vector2.down);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (hit && hit.transform.CompareTag("Square"))
                {
                    if (this.transform.position != hit.transform.position)
                    {
                        this.transform.position = Vector3.MoveTowards(transform.position, hit.collider.bounds.center, speed * Time.deltaTime);
                    }
                    else
                    {
                        OnHit();
                        hit.transform.gameObject.GetComponent<SquareScript>().DestroySelf();
                    }
                }
                else if (hit && hit.transform.CompareTag("Block"))
                {
                    if (!blockHit)
                    {
                        float tempX = Mathf.Abs(hit.collider.bounds.center.x - transform.position.x);
                        float tempY = Mathf.Abs(hit.collider.bounds.center.y - transform.position.y);

                        switch (direction)
                        {
                            case Direction.forward:
                                offsetY = -offsetValue;
                                offsetX = 0;
                                break;
                            case Direction.backwards:
                                offsetY = offsetValue;
                                offsetX = 0;
                                break;
                            case Direction.left:
                                offsetX = offsetValue;
                                offsetY = 0;
                                break;
                            case Direction.right:
                                offsetX = -offsetValue;
                                offsetY = 0;
                                break;
                            case Direction.leftAndUp:
                                if (tempX > tempY)
                                {
                                    offsetX = offsetValue;
                                    offsetY = 0;
                                }
                                else if (tempX < tempY)
                                {
                                    offsetY = -offsetValue;
                                    offsetX = 0;
                                }
                                else if (tempX == tempY)
                                {
                                    offsetX = offsetValue;
                                    offsetY = -offsetValue;
                                }
                                break;
                            case Direction.rightAndUp:
                                if (tempX > tempY)
                                {
                                    offsetX = -offsetValue;
                                    offsetY = 0;
                                }
                                else if (tempX < tempY)
                                {
                                    offsetY = -offsetValue;
                                    offsetX = 0;
                                }
                                else if (tempX == tempY)
                                {
                                    offsetX = -offsetValue;
                                    offsetY = -offsetValue;
                                }

                                break;
                            case Direction.leftAndDown:
                                if (tempX > tempY)
                                {
                                    offsetX = offsetValue;
                                    offsetY = 0;
                                }
                                else if (tempX < tempY)
                                {
                                    offsetY = offsetValue;
                                    offsetX = 0;
                                }
                                else if (tempX == tempY)
                                {
                                    offsetX = offsetValue;
                                    offsetY = offsetValue;
                                }
                                break;
                            case Direction.rightAndDown:
                                if (tempX > tempY)
                                {
                                    offsetX = -offsetValue;
                                    offsetY = 0;
                                }
                                else if (tempX < tempY)
                                {
                                    offsetY = offsetValue;
                                    offsetX = 0;
                                }
                                else if (tempX == tempY)
                                {
                                    offsetX = -offsetValue;
                                    offsetY = offsetValue;
                                }
                                break;
                            default:
                                break;
                        }
                        blockHit = true;

                    }

                    Vector3 target;

                    if (FailSafeCheck() && !blockHit)
                    {
                        target = transform.position;
                    }
                    else
                    {
                        target = new Vector3(hit.collider.bounds.center.x + offsetX, hit.collider.bounds.center.y + offsetY);
                    }


                    if (this.transform.position != target)
                    {
                        this.transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                    }
                    else
                    {
                        OnHitBlock();
                        gotAHit = false;
                        blockHit = false;
                    }
                }
                else
                {
                    gotAHit = false;
                }
            }
        }
    }

    public bool FailSafeCheck()
    {
        bool safeCheck = false;

        RaycastHit2D check1;
        RaycastHit2D check2;

        switch (direction)
        {
            case Direction.leftAndUp:
                check1 = Physics2D.Raycast(this.transform.position, Vector2.left, 1, mask);
                check2 = Physics2D.Raycast(this.transform.position, Vector2.up, 1, mask);

                if (check1 || check2)
                {
                    safeCheck = true;
                }

                break;
            case Direction.rightAndUp:
                check1 = Physics2D.Raycast(this.transform.position, Vector2.right, 1, mask);
                check2 = Physics2D.Raycast(this.transform.position, Vector2.up, 1, mask);

                if (check1 || check2)
                {
                    safeCheck = true;
                }

                break;
            case Direction.leftAndDown:
                check1 = Physics2D.Raycast(this.transform.position, Vector2.left, 1, mask);
                check2 = Physics2D.Raycast(this.transform.position, Vector2.down, 1, mask);

                if (check1 || check2)
                {
                    safeCheck = true;
                }
                break;
            case Direction.rightAndDown:
                check1 = Physics2D.Raycast(this.transform.position, Vector2.right, 1, mask);
                check2 = Physics2D.Raycast(this.transform.position, Vector2.down, 1, mask);

                if (check1 || check2)
                {
                    safeCheck = true;
                }
                break;
            default:
                break;
        }

        return safeCheck;
    }

    void Win()
    {
        start = false;

        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }

        winScreen.SetActive(true);
    }

    void GoToNext(Vector2 direction)
    {
        Debug.DrawRay(transform.position, direction, Color.red, 1f);
        hit = Physics2D.Raycast(this.transform.position, direction, distance, mask);
        if (hit)
        {
            gotAHit = true;
        }
        else
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void GoToNext(Vector2 direction1, Vector2 direction2)
    {
        hit = Physics2D.Raycast(this.transform.position, direction1 + direction2, distance, mask);
        if (hit)
        {
            gotAHit = true;
        }
        else
        {
            transform.Translate((direction1 + direction2) * speed * Time.deltaTime);
        }
    }

    void OnHit()
    {
        if (index <= listOfDirections.Count)
        {
            index++;
            direction = listOfDirections[index];
            totalAmountOfSquare--;
        }
    }

    void OnHitBlock()
    {
        if (index <= listOfDirections.Count)
        {
            index++;
            direction = listOfDirections[index];
        }
    }

    public void OnStart()
    {
        squares.AddRange(GameObject.FindGameObjectsWithTag("Square"));
        blocks.AddRange(GameObject.FindGameObjectsWithTag("Block"));
        foreach (GameObject square in squares)
        {
            totalAmountOfSquare++;
        }
        CardSlotManager.instance.OnStart();
        this.listOfDirections = CardSlotManager.instance.listOfDirections.GetRange(0, CardSlotManager.instance.listOfDirections.Count);
        listOfDirections.Add(Direction.forward);
        direction = listOfDirections[index];
        start = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Square"))
        //{
        //    OnHit();
        //    collision.GetComponent<SquareScript>().DestroySelf();
        //}
    }
}
