using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    private Rigidbody rb;
    private int score;
    private float movementx;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

        SetScoreText();
        winText.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVecter = movementValue.Get<Vector2>();

        movementx = movementVecter.x;
        movementY = movementVecter.y;
    }

    void SetScoreText()
    {
        scoreText.text = "AMBATUscore : " + score.ToString();
        if (score == 10)
        {
            winText.gameObject.SetActive (true);

        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementx, 0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;

            SetScoreText();
        }
        else if (other.gameObject.CompareTag("UnPickUp"))
        {
            other.gameObject.SetActive(false);
            score--;

            SetScoreText();
        }

    }
}

