using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{

    [SerializeField] private VariableJoystick _variableJoystick;
    private Animator _playerAnim;
    private Rigidbody rb;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveTork;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        MoveJoystick();
        MoveAnim();
    }
    private void MoveJoystick()
    {
        //Under this function I control the character movement and rotation by rigidbody.
        rb.velocity = new Vector3(_variableJoystick.Horizontal * _moveSpeed, rb.velocity.y, _variableJoystick.Vertical * _moveSpeed);

        if (_variableJoystick.Horizontal != 0 || _variableJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }


    }

    private void MoveAnim()
    {
        //Under this function I control the animation speed by _moveSpeed variable.
        if (Mathf.Abs(_variableJoystick.Direction.x) > 0 || Mathf.Abs(_variableJoystick.Direction.y) > 0)
        {
            _playerAnim.speed = ((Mathf.Abs(_variableJoystick.Direction.x) + Mathf.Abs(_variableJoystick.Direction.y) / 2) * _moveSpeed * Time.deltaTime * _moveTork);
            _playerAnim.SetFloat("Speed", _moveSpeed);
        }
        else
        {
            _playerAnim.SetFloat("Speed", 0);
        }
    }
}