using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _rb.isKinematic = true;
        _animator.enabled = true;
    }

    public void SetGravity()
    {
        _animator.enabled = false;
        _rb.isKinematic = false;
    }
}
