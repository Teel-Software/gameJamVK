using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyControlling : MonoBehaviour
{
    private Rigidbody physics;
    public bool isDoubleJumpPressed;

    private float startTime;
    private const float MAX_TIME = 5;

    private bool pausePressed;

    private void Start()
    {
        physics = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        
        isDoubleJumpPressed = false;
    }

    // AnesVijay: ChangePauseButtonToPressed и ChangePauseButtonToUnpressed нужны для того, чтобы не срабатывал двойной прыжок при нажатии на паузу,
    // переменная pausePressed служит для этого флагом
    public void ChangePauseButtonToPressed()
    {
        pausePressed = true;
    }

    public void ChangePauseButtonToUnpressed()
    {
        pausePressed = false;
    }

    void Update()
    {
        //bool phonePress = Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary);
        //if ((phonePress || Input.GetMouseButton(0)) && physics.velocity.y <= 0)
        //{
        //    physics.AddForce(new Vector3(0,0.34f,0f), ForceMode.Impulse);
        //}

        bool phonePress = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        if ((phonePress || Input.GetMouseButtonDown(0)) && !isDoubleJumpPressed && !pausePressed)
        {
            if(physics.velocity.y < 0)
                physics.velocity = new Vector3(physics.velocity.x, 0f, physics.velocity.z);
            physics.AddForce(new Vector3(0, 10f, 0f), ForceMode.Impulse);
            isDoubleJumpPressed = true;
        }

        bool phoneReleased = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
        if ((phoneReleased || Input.GetMouseButtonUp(0)) && isDoubleJumpPressed && physics.velocity.y > 0)
        {
            physics.velocity = new Vector3(physics.velocity.x, physics.velocity.y / 2f, physics.velocity.z);
            Debug.Log("cut the jump");
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
