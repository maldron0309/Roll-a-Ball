using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    // 다시하기 버튼 클릭 시 호출될 함수
    public void OnRetryButtonClick()
    {
        // Stage2 씬을 로드합니다.
        SceneManager.LoadScene("Stage2");
    }

    // 메인 버튼 클릭 시 호출될 함수
    public void OnMainMenuButtonClick()
    {
        // MainMenu 씬을 로드합니다.
        SceneManager.LoadScene("MainMenu");
    }
}
