using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanding : MonoBehaviour
{
    [SerializeField] private Transform startPos;

    // ������� ���������
    public void OnWin()
    {
        startPos.position = transform.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
    }

    // ������� � ���������
    public void OnLose()
    {
        gameObject.transform.position = startPos.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
    }
}
