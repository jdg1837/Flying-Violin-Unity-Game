using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int maxSize;
    public int currentSize;
    public int xBound;
    public int yBound;
    public int score;
    public GameObject foodPrefab;
    public GameObject currentFood;
    public GameObject snakePrefab;
    public Snake head;
    public Snake tail;
    public int NESW;
    public Vector2 nextPos;
    public float deltaTimer;
    public Text scoreText;

    void OnEnable()
    {
        Snake.hit += hit;
    }

    // Use this for initialization
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        InvokeRepeating("TimerInvoke", 0, deltaTimer);
        FoodFunction();
    }

    void OnDisable()
    {
        Snake.hit -= hit;
    }

    // Update is called once per frame
    void Update()
    {
        ComChangeD();
    }

    void TimerInvoke()
    {
        Movement();
        StartCoroutine(checkVisable());
        if (currentSize >= maxSize)
        {
            TailFunction();
        }
        else
        {
            currentSize++;
        }
    }

    void Movement()
    {
        GameObject temp;
        nextPos = head.transform.position;
        switch (NESW)
        {
            case 0:
                nextPos = new Vector2(nextPos.x, nextPos.y + 1);
                break;
            case 1:
                nextPos = new Vector2(nextPos.x + 1, nextPos.y);
                break;
            case 2:
                nextPos = new Vector2(nextPos.x, nextPos.y - 1);
                break;
            case 3:
                nextPos = new Vector2(nextPos.x - 1, nextPos.y);
                break;
        }
        temp = (GameObject)Instantiate(snakePrefab, nextPos, transform.rotation);
        head.Setnext(temp.GetComponent<Snake>());
        head = temp.GetComponent<Snake>();

        return;

    }

    void ComChangeD()
    {
        if (NESW != 2 && Input.GetKeyDown(KeyCode.W))
        {
            NESW = 0;
        }

        if (NESW != 3 && Input.GetKeyDown(KeyCode.D))
        {
            NESW = 1;
        }

        if (NESW != 0 && Input.GetKeyDown(KeyCode.S))
        {
            NESW = 2;
        }

        if (NESW != 1 && Input.GetKeyDown(KeyCode.A))
        {
            NESW = 3;
        }
    }

    public void MobChangeD(int direction)
    {
        if (NESW != 2 && direction == 0)
        {
            NESW = direction;
        }

        if (NESW != 3 && direction == 1)
        {
            NESW = direction;
        }

        if (NESW != 0 && direction == 2)
        {
            NESW = direction;
        }

        if (NESW != 1 && direction == 3)
        {
            NESW = direction;
        }
    }

    void TailFunction()
    {
        Snake tempSnake = tail;
        tail = tail.GetNext();
        tempSnake.RemoveTail();
    }

    void FoodFunction()
    {
        int xPos = Random.Range(-xBound, xBound);
        int yPos = Random.Range(-yBound, yBound);

        currentFood = (GameObject)Instantiate(foodPrefab, new Vector2(xPos, yPos), transform.rotation);
        StartCoroutine(CheckRender(currentFood));
    }

    IEnumerator CheckRender(GameObject IN)
    {
        yield return new WaitForEndOfFrame();
        if (IN.GetComponent<Renderer>().isVisible == false)
        {
            if (IN.tag == "Food")
            {
                Destroy(IN);
                FoodFunction();
            }
        }
    }

    void hit(string WhatWasSent)
    {
        if (WhatWasSent == "Food")
        {
            if(deltaTimer >= .1f)
            {
                deltaTimer -= .05f;
                CancelInvoke("TimerInvoke");
                InvokeRepeating("TimerInvoke", 0, deltaTimer);
            }
            FoodFunction();
            maxSize++;
            score++;
            scoreText.text = score.ToString();
            if(score == 15)
            {
				Save.Instance.lost = 0;
				Save.Instance.score = Save.Instance.score + 100;
                Exit();
            }
        }
        if (WhatWasSent == "Snake")
        {
            CancelInvoke("TimerInvoke");
			Save.Instance.lost = 1;
            Exit();
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(6);
    }

    void Wrap()
    {
        if(NESW == 0)
        {
            head.transform.position = new Vector2(head.transform.position.x, -(head.transform.position.y - 1));
        }
        else if (NESW == 1)
        {
            head.transform.position = new Vector2(-(head.transform.position.x - 1), head.transform.position.y);
        }
        else if (NESW == 2)
        {
            head.transform.position = new Vector2(head.transform.position.x, -(head.transform.position.y + 1));
        }
        else if (NESW == 3)
        {
            head.transform.position = new Vector2(-(head.transform.position.x + 1), head.transform.position.y);
        }
    }

    IEnumerator checkVisable()
    {
        yield return new WaitForEndOfFrame();
        if (!head.GetComponent<Renderer>().isVisible)
        {
            Wrap();
        }
    }
}
