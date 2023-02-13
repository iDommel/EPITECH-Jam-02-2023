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
    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayButton.onClick.AddListener(StartButton);
        m_OptionsButton.onClick.AddListener(OptionsButton);
        m_ExitButton.onClick.AddListener(ExitButton);
        m_LoreButton.onClick.AddListener(LoreButton);
        m_AudioSource = GetComponent<AudioSource>();
    }

    void StartButton()
    {
        m_AudioSource.Play();
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
        m_AudioSource.Play();
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
        m_AudioSource.Play();
    }

    void ExitButton()
    {
        m_AudioSource.Play();
        Application.Quit();
    }

}
