using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ProgressBar : MonoBehaviour
{
    private ProgressBarInput _input;
    private Slider _slider;

    //private float _fillValue;
    private bool _isCharging = false;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();

        _input = new ProgressBarInput();
        _input.ProgressBar.Enable();
        _input.ProgressBar.Charge.started += ChargeStarted;
        _input.ProgressBar.Charge.canceled += ChargeCanceled;
    }

    void ChargeStarted(InputAction.CallbackContext context)
    {
        //Debug.Log("It started");
        _isCharging = true;

        StartCoroutine(Charging());
    }


    void ChargeCanceled(InputAction.CallbackContext context)
    {
        _isCharging = false;
    }

    IEnumerator Charging()
    {
        while(_isCharging == true)
        {
            _slider.value += 1.0f * Time.deltaTime;
            yield return null;
        }

        while(_slider.value > 0)
        {
            _slider.value -= 1.0f * Time.deltaTime;
            yield return null;
        }
        
    }
}
