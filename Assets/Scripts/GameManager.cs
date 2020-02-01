using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public Dropdown qualityDropdown;

    // Start is called before the first frame update
    void Start()
    {
        qualityDropdown.value = 4;
        QualitySettings.SetQualityLevel(4);
        qualityDropdown.onValueChanged.AddListener(delegate {
            QualityDropdownHandler(qualityDropdown);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (!settingsPanel.activeSelf && Input.GetKeyUp(KeyCode.Escape))
        {
            MainMenu();
        } else if(settingsPanel.activeSelf && Input.GetKeyUp(KeyCode.Escape))
        {
            SettingsMenu();
        }
    }
    
    public void GameQuit()
    {
        Application.Quit();
    }
    
    public void MainMenu()
    {
        if (mainMenuPanel.activeSelf)
        {
            mainMenuPanel.SetActive(false);
        }
        else
        {
            mainMenuPanel.SetActive(true);
        }
    }
    
    public void SettingsMenu()
    {
        if (!mainMenuPanel.activeSelf && settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
        else if(mainMenuPanel.activeSelf && !settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
    }
    
    private void QualityDropdownHandler(Dropdown target)
    {
        QualitySettings.SetQualityLevel(target.value);
    }
}
