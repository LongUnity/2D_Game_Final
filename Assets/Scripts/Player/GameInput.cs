using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler OnAttack;

    private PlayAction playAction;

    private void Awake()
    {
        Instance = this;
        playAction = new PlayAction();
        playAction.Player.Enable();
        playAction.Player.Attack.performed += Attack_performed;
    }

    private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnAttack?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMoveInputNormalized()
    {
        Vector2 moveInput;
        moveInput = playAction.Player.Move.ReadValue<Vector2>();
        return moveInput;
    }
}
