using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsScripts : MonoBehaviour
{
    public Button m_PlayButton, m_OptionsButton, m_ExitButton, m_LoreButton;
    public string playSceneTarget = "GameScene";
    public GameObject m_OptionsPanel;
    public bool isOptionsPanelActive = false;
    public GameObject m_LorePanel;
    public bool isLorePanelActive = false;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayButton.onClick.AddListener(StartButton);
        m_OptionsButton.onClick.AddListener(OptionsButton);
        m_ExitButton.onClick.AddListener(ExitButton);
        m_LoreButton.onClick.AddListener(LoreButton);
    }

    void StartButton()
    {
        SceneManager.LoadScene(playSceneTarget);
    }

    void OptionsButton()
    {
        if (isOptionsPanelActive)
        {
            m_OptionsPanel.SetActive(false);
        }
        else
        {
            m_OptionsPanel.SetActive(true);
        }
        isOptionsPanelActive = !isOptionsPanelActive;
    }

    void LoreButton()
    {
        if (isLorePanelActive)
        {
            m_LorePanel.SetActive(false);
        }
        else
        {
            m_LorePanel.SetActive(true);
        }
        isLorePanelActive = !isLorePanelActive;
    }

    void ExitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
