using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject infoPanel; 
    public KeyCode openKey;

    private bool isOpen = false;

    
    private void Update()
    {
        if(Input.GetKeyDown(openKey))
        {
            if(isOpen)
            {
                ClosePanel();
            }
            else
            {
                OpenPanel();
            }
        }
    }
    public void OpenPanel()
    {
        SettingPanel.SetActive(true);
        isOpen = true;
        Time.timeScale = 0;
    }
    public void ClosePanel()
    {
        SettingPanel.SetActive(false);
        isOpen = false;
        Time.timeScale = 1;
    }
    public void OpenInfoPanel()
    {
        infoPanel.SetActive(true);
    }
    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
    
}
