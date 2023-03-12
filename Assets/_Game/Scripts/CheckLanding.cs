using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckLanding : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject _losePanel;

    public int ScoreCount { get; private set; }

    // перенос телепорта
    public void OnWin(GameObject collider)
    {
        Debug.Log("win");
        var anch = collider.transform.Find("Anchor");
        Debug.Log(anch);
        if (anch != null)
        {
            Debug.Log("tp to anchor");
            transform.position = anch.position;
        }

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //startPos.position = transform.position;
        gameObject.GetComponent<ForceAdding>().enabled = true;
        Debug.Log(gameObject.GetComponent<FlyControlling>().ToString());
        gameObject.GetComponent<FlyControlling>().enabled = false;
        //if (!collider.Equals(PrevCollider))
        //PlanesGenerator.GenerateNextPanel();
        //PrevCollider = collider;

        MakeScorePlus();
    }

    public void MakeScorePlus()
    {
        ScoreCount++;
        text.text = ScoreCount.ToString();
        Debug.Log(ScoreCount);
    }

    // перенос к телепорту
    public void OnLose(GameObject collider)
    {
        Debug.Log("lose");
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //gameObject.transform.position = startPos.position;
        gameObject.GetComponent<ForceAdding>().enabled = false;
        gameObject.GetComponent<FlyControlling>().enabled = false;
        
        _losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}