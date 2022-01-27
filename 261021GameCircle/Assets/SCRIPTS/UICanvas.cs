using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICanvas : MonoBehaviour
{
    public FPSAimAssistant ReferenceAimAssistant;
    public static UICanvas instance;
    public GameObject[] bulletIcons;
    public GameObject gameOverPanel;
    public GameObject levelInfoPanel;

    public GameObject FireButton;
    public GameObject ReloadButton;

    private void Start()
    {
        StartCoroutine(LevelInfo());
    }
    private void Awake()
    {
        instance = this;
    }

    public void RemoveBulletIcon(int parameter)
    {
        bulletIcons[parameter].SetActive(false);
    }
    public void RemakeBulletIcon()
    {
        for(int i = 0; i < bulletIcons.Length; i++)
        {
            bulletIcons[i].SetActive(true);
        }
    }
    IEnumerator LevelInfo()
    {
        levelInfoPanel.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        levelInfoPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        levelInfoPanel.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
