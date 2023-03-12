using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("destroy") == 1)
        {
            _obj.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 1;
            PlayerPrefs.SetInt("destroy", 0);
        }
    }
}
