using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] Transform _direction;

    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(vertical, 0f, horizontal);
        transform.Translate(movement * Time.deltaTime * _speed, _direction);

        _animator.SetBool("Walk", movement.magnitude > 0);
    }
}