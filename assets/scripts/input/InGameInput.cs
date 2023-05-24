using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InGameInput : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerInteractions playerInteractions;

    PlayerControls controls;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInteractions = GetComponent<PlayerInteractions>();
        controls = new PlayerControls();

        //Move left
        controls.Gameplay.MoveLeft.started += ctx => 
        { 
            playerMovement.Move(-1);
            playerInteractions.ChangeAimDirection(PlayerInteractions.AimDirection.left);
        };
        controls.Gameplay.MoveLeft.canceled += ctx => { playerMovement.Move(1); };

        //Move right
        controls.Gameplay.MoveRight.started += ctx => 
        { 
            playerMovement.Move(1);
            playerInteractions.ChangeAimDirection(PlayerInteractions.AimDirection.right);
        };
        controls.Gameplay.MoveRight.canceled += ctx => { playerMovement.Move(-1); };

        //Jump
        controls.Gameplay.Jump.started += ctx => { playerMovement.Jump(); };
        controls.Gameplay.Jump.canceled += ctx => { playerMovement.CancelJump(); };

        //Dash
        controls.Gameplay.Dash.started += ctx => { playerInteractions.Dash(); };

        //DropThruPlatform
        controls.Gameplay.DropThruPlatform.started += ctx => { playerMovement.Drop(); };
        controls.Gameplay.DropThruPlatform.canceled += ctx => { playerMovement.CancelDrop(); };

        //Interact
        controls.Gameplay.Interact.started += ctx => { playerInteractions.Interact(); };

        //Drop
        controls.Gameplay.Drop.started += ctx => { playerInteractions.DropItem(); };

        //Left click
        controls.Gameplay.LeftClick.started += ctx => { playerInteractions.MainAttack(); };

        //Right click
        controls.Gameplay.RightClick.started += ctx => { playerInteractions.SecondaryAttack(); };

        //Scroll
        controls.Gameplay.Scroll.started += ctx => { playerInteractions.ChangeItemSelection(shift: true, moveForward: ((int)ctx.ReadValue<Vector2>().y / 120) == 1); };

        //Number row
        controls.Gameplay.PrimaryMeleeSelection.started += ctx => { playerInteractions.ChangeItemSelection(shift: false, position: 0); };
        controls.Gameplay.PrimaryRangedSelection.started += ctx => { playerInteractions.ChangeItemSelection(shift: false, position: 1); };

        //AimUp
        controls.Gameplay.AimUp.started += ctx => { playerInteractions.ChangeAimDirection(PlayerInteractions.AimDirection.up); };

        //AimDown
        controls.Gameplay.AimDown.started += ctx => { playerInteractions.ChangeAimDirection(PlayerInteractions.AimDirection.down); };
    }


    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
