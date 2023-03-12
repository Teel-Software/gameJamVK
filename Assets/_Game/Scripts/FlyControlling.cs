using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControlling : MonoBehaviour
{
    private Rigidbody physics;
    [SerializeField] TMP_Text text;

    private void Start()
    {
        physics = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool phonePress = Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary);
        text.text = ((phonePress || Input.GetMouseButton(0)) && physics.velocity.y <= 0).ToString();

        if ((phonePress || Input.GetMouseButton(0)) && physics.velocity.y <= 0)
        {
            text.text = "entered";
            physics.AddForce(new Vector3(0,0.34f,0f), ForceMode.Impulse);
        }
    }

    public void OnRightClick()
    {
        if (gameObject.GetComponent<ForceAdding>().enabled == false)
            physics.AddForce(GetVector(-1), ForceMode.Force);
    }

    public void OnLeftClick()
    {
        if (gameObject.GetComponent<ForceAdding>().enabled == false)
        {
            physics.AddForce(GetVector(1), ForceMode.Force);
        }
    }

    private Vector3 GetVector(float force)
    {
        var localPOS = gameObject.transform.localPosition;
        return new Vector3(20 * localPOS.x * force,0,0);
    }
}
