using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; // 플레이어 이동속도
    public TextMeshProUGUI scoreText;
    public GameObject winText;
    public float nextLevelDelay = 4.0f; // 다음 스테이지로 넘어갈 때까지 대기할 시간 
    public string nextLevelName = "Stage2"; 

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
        if (score >= 10)
        {
            // 플레이어가 포인트 10개를 먹으면 win 텍스트 표시
            winText.SetActive(true);
            // 승리 후 다음 스테이지씬 로드 지연
            StartCoroutine(TransitionToNextLevel());
        }
    }

    // 다음 스테이지로 가는 코루틴
    IEnumerator TransitionToNextLevel()
    {
        // 지연 시간동안 대기
        yield return new WaitForSeconds(nextLevelDelay);
        // 스테이지2로 로드
        SceneManager.LoadScene(nextLevelName);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Point에 닿으면
        if (other.gameObject.CompareTag("Point"))
        {
            // Point 옵젝을 비활성화
            other.gameObject.SetActive(false);
            // 점수 증가 후 점수 텍스트 업데이트
            score++;
            SetScoreText();
        }
    }
}
