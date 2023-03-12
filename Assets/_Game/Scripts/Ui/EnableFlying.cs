using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFlying : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void DoMagic()
    {
        Time.timeScale = 1;
    }
}
