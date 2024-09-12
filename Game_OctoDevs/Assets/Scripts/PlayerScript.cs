using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationLerp;
    [SerializeField] private GameObject interactField;

    private CharacterController charControl;
    private Vector2 movement;
    private float interact;

    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    public void SetMovement(InputAction.CallbackContext e)
    {
        movement = e.ReadValue<Vector2>();
    }

    public void SetInteract(InputAction.CallbackContext e)
    {
        interact = e.ReadValue<float>();
        if(interact != 0)
            interactField.SetActive(true);
        else interactField.SetActive(false);
    }

    public void SetRun(InputAction.CallbackContext e)
    {
        speed *= 1.5f;
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(movement.x, 0f, movement.y).normalized;

        charControl.Move(move * Time.deltaTime * speed);
        //transform.Translate(move * Time.deltaTime * speed, Space.World);
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
    }
}


