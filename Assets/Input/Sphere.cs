using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sphere : MonoBehaviour
{
    private SphereInput _input;
    private Rigidbody _rb;

    private bool _isJumping = false;

    private float _holdTime;
    private float _jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _input = new SphereInput();
        _input.Sphere.Enable();
        _input.Sphere.Jump.canceled += JumpCanceled;
    }

    /*void JumpStarted(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }*/

    void JumpCanceled(InputAction.CallbackContext context)
    {
        var forceEffect = context.duration;

        if(_isJumping == false)
        {
            _rb.AddForce(Vector3.up * (10f * (float)forceEffect), ForceMode.Impulse);
        }
    }

    void JumpPerformed(InputAction.CallbackContext context)
    {
        // Full Jump
        _isJumping = true;
        _rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
    }

}
