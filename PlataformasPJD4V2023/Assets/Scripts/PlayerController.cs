using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private GameControls _controls;
    private Vector2 _moveInput;
    private bool _isShooting;

    private void OnEnable()
    {
        _playerInput.onActionTriggered += OnAction;
    }

    private void OnDisable()
    {
        _playerInput.onActionTriggered -= OnAction;
    }

    // Start is called before the first frame update
    void Awake()
    {
        _controls = new GameControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnAction(InputAction.CallbackContext playerAct)
    {
        if (playerAct.action.name == _controls.Gameplay.Shoot.name)
        {
            // Fazer o jogador atirar
            // Input antigo
            // KeyDown (no momento que o jogador aperta),
            // Key (enquanto o jogador está apertando),
            // KeyUp (no momento que o jogador solta)
            // Input System
            // playerAct.started (no momento que o jogador aperta)
            // playerAct.performed (parece mais o started, n mto usado em gameplay)
            // playerAct.canceled (no momento que o jogador solta)
            
            // pra atirar:
            // Esquema 1: Atira uma vez a cada apertada de botao
            // Esquema 2: Atira enquanto o botão estiver sendo pressionado
            
            // Implementando esquema 2:
            if(playerAct.started)
                _isShooting = true;
            else if(playerAct.canceled)
                _isShooting = false;
        }

        if (playerAct.action.name == _controls.Gameplay.Movement.name)
        {
            _moveInput = playerAct.ReadValue<Vector2>();
        }
    }
}
