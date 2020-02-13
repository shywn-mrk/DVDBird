using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public GameObject gameOverObject;
    private bool isOver = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animation>().Play();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOver)
            if (Input.anyKeyDown || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
                SceneManager.LoadScene("MainScene");
        if (Input.anyKeyDown || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            rigidBody.velocity = new Vector2(5, 5);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isOver = true;
    }
}
