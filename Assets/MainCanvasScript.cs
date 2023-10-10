using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private GameObject pausePanel;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("destroy") == 1)
        {
            _obj.SetActive(true);
            gameObject.SetActive(false);
            pausePanel.SetActive(true);
            Time.timeScale = 1;
            PlayerPrefs.SetInt("destroy", 0);
        }
    }
}
