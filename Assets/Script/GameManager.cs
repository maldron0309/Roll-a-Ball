using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void ReturnToStage()
    {
        SceneManager.LoadScene("ChoStage");
    }
}