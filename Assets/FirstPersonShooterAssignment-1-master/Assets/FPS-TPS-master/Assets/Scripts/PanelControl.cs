using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject helpPanel;
    public GameObject settingsPanel;


    public void Main()
    {
        mainPanel.SetActive(true);
        helpPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void Help()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Settings()
    {
        mainPanel.SetActive(false);
        helpPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
