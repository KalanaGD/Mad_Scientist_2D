using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed")]
    [SerializeField] private float _moveSpeed = 5.5f;
    private Vector3 _tempPosition;
    private float _xAxis, _yAxis;

    private string _horizontalInput = "Horizontal";
    private string _verticalInput = "Vertical";

    private Animator _anim;



    void Start()
    {
        _anim = GetComponent<Animator>();
    }//Start


    void Update()
    {
        PlayerMove();
        PlayerAnimation();

    }//Update

    private void PlayerMove()
    {
        _xAxis = Input.GetAxis(_horizontalInput);
        _yAxis = Input.GetAxis(_verticalInput);

        _tempPosition = transform.position;

        _tempPosition.x += _xAxis * Time.deltaTime * _moveSpeed;
        _tempPosition.y += _yAxis * Time.deltaTime * _moveSpeed;

        transform.position = _tempPosition;

    }//PlayerMove


    private void PlayerAnimation()
    {
        bool isWalking = _xAxis != 0 || _yAxis != 0;
        _anim.SetBool("is_walking",isWalking);

        if(_xAxis < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if(_xAxis > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }//PlayerAnimation

}//Class


