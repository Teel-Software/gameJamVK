using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleFactorMenu : MonoBehaviour
{
    // AnesVijay: изменил Start на OnEnable, чтобы время останавливалось не только на первой заставке, но и при возникновении экрана паузы (чтобы игра на фоне не шла)
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void DoScaleFactorMagic()
    {
        Time.timeScale = 1;
    }
}
