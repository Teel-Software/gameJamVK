using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasCloser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("destroy") == 1)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            PlayerPrefs.SetInt("destroy", 0);
        }
    }
}
