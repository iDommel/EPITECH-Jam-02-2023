using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsScripts : MonoBehaviour
{
    public Button m_PlayButton, m_OptionsButton, m_ExitButton;
    public string playSceneTarget = "GameScene";

    // Start is called before the first frame update
    void Start()
    {
        m_PlayButton.onClick.AddListener(StartButton);
        m_OptionsButton.onClick.AddListener(OptionsButton);
        m_ExitButton.onClick.AddListener(ExitButton);
    }

    void StartButton()
    {
        SceneManager.LoadScene(playSceneTarget);
    }

    void OptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    void ExitButton()
    {
        Application.Quit();
    }

}
