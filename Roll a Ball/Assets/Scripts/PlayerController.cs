using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetAllText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            SetAllText();
        }
    }

    void SetAllText ()
    {
        scoreText.text = "Score: " + score.ToString ();
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "You won game with a score of: " + count.ToString();
        }
    }

}
