using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI scoreText;
    public GameObject winText;

    private Rigidbody rb;
    private int score;
    private float movementX;
    private float movementY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

        SetScoreText();
        winText.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 362)
        {
            winText.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }

    }

    }