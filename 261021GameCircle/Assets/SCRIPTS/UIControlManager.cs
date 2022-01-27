using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControlManager : MonoBehaviour
{
    public GameObject[] Panels;

    public void ChangePanel(int panel)
    {
        if (panel != 0)
        {
            Panels[panel - 1].SetActive(false);
            Panels[panel].SetActive(true);
        }
        
        if (panel > 1)
        {
            Panels[panel - 2].SetActive(false);
        }
        if (panel == 0)
        {
            Panels[panel].SetActive(true);
            Panels[panel + 1].SetActive(false);
            Panels[panel + 2].SetActive(false);
        }
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void PlayButton(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
