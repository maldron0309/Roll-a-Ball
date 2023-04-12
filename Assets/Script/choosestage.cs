using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choosestage : MonoBehaviour
{
    public void OnClickStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void OnClickStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void OnClickBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}