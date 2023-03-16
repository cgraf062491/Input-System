using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private Renderer _renderer;

    private bool _isDriving = false;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();

        _input = new PlayerInput();
        _input.Player.Enable();
        _input.Player.RandomColor.performed += RandomColorPerformed;
        _input.Player.ChangeDriver.performed += ChangeDriverPerformed;
    }

    void RandomColorPerformed(InputAction.CallbackContext context)
    {
        if(_renderer != null)
        {
            _renderer.material.color = Random.ColorHSV();
        }
    }

    void Update()
    {
        if(_isDriving == false)
        {
            RotatePerformed();
        }
        else
        {
            Movement();
        }
        
    }

    void ChangeDriverPerformed(InputAction.CallbackContext context)
    {
        _input.Player.Disable();
        _input.Drive.Enable();

        _isDriving = true;
    }

    void RotatePerformed()
    {
        var rotation = _input.Player.Rotate.ReadValue<float>();

        transform.Rotate(Vector3.up * Time.deltaTime * 30f * rotation);
    }

    
    void Movement()
    {
        var move = _input.Drive.Movement.ReadValue<Vector2>();

        transform.Translate(new Vector3(move.x * Time.deltaTime * 5f, 0, move.y * Time.deltaTime * 5f));
    }
}
