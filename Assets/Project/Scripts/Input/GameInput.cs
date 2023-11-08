using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {
    
    public static GameInput Instance { get; private set; }

    public enum Binding {
        Move_Left,
        Move_Right,
        Jump,
        Use,
        Pause,

        Gamepad_Jump,
        Gamepad_Use,
        Gamepad_Pause,
    }

    private GameInputActions gameInputActions;

    public event EventHandler OnJumpAction;
    public event EventHandler OnUseAction;
    public event EventHandler OnPauseAction;

    private void Awake() {
        Instance = this;
        
        gameInputActions = new GameInputActions();
        gameInputActions.Player.Enable();

        gameInputActions.Player.Jump.performed += Jump_performed;
        gameInputActions.Player.Use.performed += Use_performed;
        gameInputActions.Player.Pause.performed += Pause_performed;
    }

    private void OnDestroy() {
        gameInputActions.Player.Jump.performed -= Jump_performed;
        gameInputActions.Player.Use.performed -= Use_performed;
        gameInputActions.Player.Pause.performed -= Pause_performed;

        gameInputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Use_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnUseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnJumpAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector() {
        Vector2 inputVector = gameInputActions.Player.Movement.ReadValue<Vector2>();
        gameInputActions.Player.Movement.ReadValue<Vector2>();
        return inputVector;
    }

    public string GetBindingText(Binding binding) {
        switch (binding) {
            default:
            case Binding.Move_Left:
                return gameInputActions.Player.Movement.bindings[1].ToDisplayString();
            case Binding.Move_Right:
                return gameInputActions.Player.Movement.bindings[2].ToDisplayString();
            case Binding.Use:
                return gameInputActions.Player.Use.bindings[0].ToDisplayString();
            case Binding.Jump:
                return gameInputActions.Player.Jump.bindings[0].ToDisplayString();
            case Binding.Pause:
                return gameInputActions.Player.Pause.bindings[0].ToDisplayString();
            case Binding.Gamepad_Use:
                return gameInputActions.Player.Use.bindings[1].ToDisplayString();
            case Binding.Gamepad_Jump:
                return gameInputActions.Player.Jump.bindings[1].ToDisplayString();
            case Binding.Gamepad_Pause:
                return gameInputActions.Player.Pause.bindings[1].ToDisplayString();

        }
    }

    public void RebindBinding(Binding binding, Action onActionRebound) {
        gameInputActions.Player.Disable();

        InputAction inputAction;
        int bindingIndex;

        switch (binding) {
            default:
            case Binding.Move_Left:
                inputAction = gameInputActions.Player.Movement;
                bindingIndex = 1;
                break;
            case Binding.Move_Right:
                inputAction = gameInputActions.Player.Movement;
                bindingIndex = 2;
                break;
            case Binding.Use:
                inputAction = gameInputActions.Player.Use;
                bindingIndex = 0;
                break;
            case Binding.Jump:
                inputAction = gameInputActions.Player.Jump;
                bindingIndex = 0;
                break;
            case Binding.Pause:
                inputAction = gameInputActions.Player.Pause;
                bindingIndex = 0;
                break;
            case Binding.Gamepad_Use:
                inputAction = gameInputActions.Player.Use;
                bindingIndex = 1;
                break;
            case Binding.Gamepad_Jump:
                inputAction = gameInputActions.Player.Jump;
                bindingIndex = 1;
                break;
            case Binding.Gamepad_Pause:
                inputAction = gameInputActions.Player.Pause;
                bindingIndex = 1;
                break;
        }
        inputAction.PerformInteractiveRebinding(bindingIndex)
        .OnComplete(callback => {
            callback.Dispose();
            gameInputActions.Player.Enable();
            onActionRebound();
        })
        .Start();
    }
}
