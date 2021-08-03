using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public GameObject BGPanel, ExitPanel, GameplayPanel, GuidePanel, OptionsMenu_1, OptionsMenu_2, MusicPanel, gameName;

    public void MusicButton()
    {
        BGPanel.SetActive(true);
        ExitPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        GuidePanel.SetActive(false);
        OptionsMenu_1.SetActive(false);
        OptionsMenu_2.SetActive(false);
        MusicPanel.SetActive(true);
        gameName.SetActive(false);
    }

    public void GuideButton()
    {
        BGPanel.SetActive(true);
        ExitPanel.SetActive(false);
        GameplayPanel.SetActive(false);
        GuidePanel.SetActive(true);
        OptionsMenu_1.SetActive(false);
        OptionsMenu_2.SetActive(false);
        MusicPanel.SetActive(false);
        gameName.SetActive(false);
    }

    public void GameplayButton()
    {
        BGPanel.SetActive(true);
        ExitPanel.SetActive(false);
        GameplayPanel.SetActive(true);
        GuidePanel.SetActive(false);
        OptionsMenu_1.SetActive(false);
        OptionsMenu_2.SetActive(false);
        MusicPanel.SetActive(false);
        gameName.SetActive(false);
    }

    public void Back()
    {

        BGPanel.SetActive(true);
        ExitPanel.SetActive(true);
        GameplayPanel.SetActive(false);
        GuidePanel.SetActive(false);
        OptionsMenu_1.SetActive(true);
        OptionsMenu_2.SetActive(true);
        MusicPanel.SetActive(false);
        gameName.SetActive(true);
    }
}