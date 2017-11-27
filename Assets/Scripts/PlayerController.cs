using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {
    private int numberOfLevels;
    public int numberOfPoints;
    public int currentLevel;
    public float speed;
    public Text countText;
    public Text winText;
    public Text timeLeftText;
    public Button quitGameButton;
    public Button restartLevelButton;
    public Button nextLevelButton;
    public float timeLeft;

    private Rigidbody rb;
    private int count;

    public int jumpHeight;
    private Boolean isFalling;

	// This is the called in the first frame that the script is active
	// This is often the very first frame of the game
	void Start ()
    {
        isFalling = false;
        winText.text = "Level " + currentLevel.ToString();
        rb = GetComponent<Rigidbody> ();
        quitGameButton.gameObject.SetActive(false);
        restartLevelButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        count = 0;
	}
	// This is called before rendering a frame.
	// This is where most of are code will go
	void Update ()
    {
        timeLeft = timeLeft - Time.deltaTime;
        timeLeftText.text = Convert.ToInt32(timeLeft).ToString() + " seconds left";
        if (timeLeft < 0)
        {
            FinishGame(false);
        }

        if (Input.GetKeyDown("space") && isFalling == false)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isFalling = true;
        }

    }

    // This is executed in every frame that there is a collision
    void OnCollisionStay()
    {
        // We set up this to false because the ball should stop when it gets to the flour
        isFalling = false;
    }

    // This is called before performing any physics calculation
    // This is where our physics code will go
    void FixedUpdate ()
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

    // This is called when an object collides with another object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Points: " + (count * 100).ToString();

            if (count == numberOfPoints)
            {
                FinishGame(true);
            }
        }
    }

    // This is called when an object collides with another object
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            FinishGame(false);
        }
    }

    void FinishGame (bool result)
    {
        if (result == true)
        {
            winText.text = "You Win!";
        } else
        {
            winText.text = "You Lose";
        }
        Time.timeScale = 0;
        quitGameButton.gameObject.SetActive(true);
        restartLevelButton.gameObject.SetActive(true);
        if (result == true)
        {
            nextLevelButton.gameObject.SetActive(true);
        }
    }
}