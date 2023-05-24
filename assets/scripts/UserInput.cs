using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public GameObject player;

    //Script variables
    PlayerMovement playerMovement;
    PlayerInteractions playerInteractions;

    PlayerControls controls;

    void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerInteractions = player.GetComponent<PlayerInteractions>();
        controls = new PlayerControls();

        //Move left
        controls.Gameplay.MoveLeft.started += ctx => { playerMovement.Move(-1); };
        controls.Gameplay.MoveLeft.canceled += ctx => { playerMovement.Move(1); };

        //Move right
        controls.Gameplay.MoveRight.started += ctx => { playerMovement.Move(1); };
        controls.Gameplay.MoveRight.canceled += ctx => { playerMovement.Move(-1); };

        //Jump
        controls.Gameplay.Jump.started += ctx => { playerMovement.Jump(); };
        //controls.Gameplay.Jump.canceled += ctx => { playerMovement.isJumping = false; };

        //Dash
        controls.Gameplay.Dash.started += ctx => { playerMovement.Dash(); };

        //Interact
        controls.Gameplay.Interact.started += ctx => { playerInteractions.Interact(); };

        //Drop
        controls.Gameplay.Drop.started += ctx => { playerInteractions.DropItem(); };

        //Left click
        controls.Gameplay.LeftClick.started += ctx => { playerInteractions.MainAttack(); };

        //Scroll
        controls.Gameplay.Scroll.started += ctx => { playerInteractions.ChangeItemSelection(shift: true, moveForward: ((int)ctx.ReadValue<Vector2>().y / 120) == 1); };

        //Number row
        controls.Gameplay.PrimaryMeleeSelection.started += ctx => { playerInteractions.ChangeItemSelection(shift: false, position: 0); };
        controls.Gameplay.PrimaryRangedSelection.started += ctx => { playerInteractions.ChangeItemSelection(shift: false, position: 1); };

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
