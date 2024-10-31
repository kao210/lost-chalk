using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void GameStartButtonDown()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameReStartButtonDown()
    {
        SceneManager.LoadScene("StartScene");
    }
}
