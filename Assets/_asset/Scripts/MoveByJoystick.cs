using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByJoystick : MonoBehaviour
{
    public CharacterController characterController;
    public float movingSpeed;
    public Joystick joystick;

    private void OnValidate()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        float hInput = joystick.Horizontal;
        float vInput = joystick.Vertical;
        Vector3 direction = transform.right * hInput + transform.forward * vInput;
        characterController.SimpleMove(direction * movingSpeed);
        
    }
}
