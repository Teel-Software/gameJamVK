using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleFactorMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void DoScaleFactorMagic()
    {
        Time.timeScale = 1;
    }
}
