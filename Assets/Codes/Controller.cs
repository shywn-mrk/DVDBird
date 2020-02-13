using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    static public Controller instance;
    public int gameScore;
    public static int bestScore;
    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highScoreText.text = "Best: " + (gameScore > bestScore ? ++bestScore : bestScore);
        for (int i = 0; i < 1024; i++)
            randoms.Enqueue(UnityEngine.Random.Range(0F, UnityEngine.Random.Range(0.0001F, UnityEngine.Random.Range(0.0002F, 3F))));
    }

    public Transform bird;

    public GameObject[] gameObjectsToActive;
    public GameObject[] gameObjectsToDeactive;
    bool started = false;
    void Update()
    {
        if (started) return;
        if (Input.anyKeyDown || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Array.ForEach(gameObjectsToActive, g => { g.SetActive(true); });
            Array.ForEach(gameObjectsToDeactive, g => { g.SetActive(false); });
            started = true;
        }
    }

    public Queue<float> randoms = new Queue<float>();
    public void SpawnPipe(Transform pipe)
    {
        float x = bird.position.x + 16;
        bool isUpper = pipe.position.y > 0;
        if (randoms.Count == 0) Start();
        float y = randoms.Dequeue();
        pipe.transform.position = new Vector3(x, isUpper ? (3.5F + y) : (-3.5F - y));
    }

    public void ScoreCounter()
    {
        gameScore++;
        scoreText.text = "Score: " + gameScore;
        highScoreText.text = "Best: " + (gameScore > bestScore? ++bestScore : bestScore);
    }
}
