using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += OnInputAction;
    }

    private void OnInputAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        switch (context.action.name)
        {
            case "FireAction":
                OnFireButton();
                break;
            
            case "SkillAction":
                OnSkillButton();
                break;
            
            case "Horizontal":
                OnHorizontalAxis(context.action.ReadValue<float>());
                break;
        }
    }

    private void OnHorizontalAxis(float readValue)
    {
        Debug.Log($"Horizontal {readValue}");
    }

    private void OnFireButton()
    {
        Debug.Log("FIRE!");
    }
    
    private void OnSkillButton()
    {
        Debug.Log("SKILL!");
    }
}
