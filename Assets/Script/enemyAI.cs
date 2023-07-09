using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyAI : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;
    public GameObject gameOverUI;

    Rigidbody rb;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance < 10f)
        {
            transform.LookAt(playerTransform);
            transform.position += transform.forward * speed * Time.deltaTime;

            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver"); 
        }
    }
}
