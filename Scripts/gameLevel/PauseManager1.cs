using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager1 : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;
    public void OnEnable()
    {
       Time.timeScale=0f;
    }

    public void OnDisable()
    {
       Time.timeScale=1f;
    }
    
    public void devamEt()
    {
      pausePanel.SetActive(false);
    }

    public void menuyeDon()
    {
       SceneManager.LoadScene("menuLevel");
    }

    public void cikis()
    {
        Application.Quit();
    }
    
}
