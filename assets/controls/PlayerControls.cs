// GENERATED AUTOMATICALLY FROM 'Assets/controls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""7664a910-bcb7-4fca-93d9-da2bd74eb93c"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""7c3bd9d8-9355-497f-953e-ed64aaacf1e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""dbb7e486-16e6-4981-833c-f490e3e74489"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ba8c597a-2656-4f83-9fb5-c5a29b6c86d6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1549051d-1abd-4ba7-8d6e-afdb6f0dbb94"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Button"",
                    ""id"": ""9bc5b2b7-efb7-4583-a623-4ffe89133350"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary Melee Selection"",
                    ""type"": ""Button"",
                    ""id"": ""c03f2bf9-898c-4ae4-bcb6-8f3203248dc1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary Ranged Selection"",
                    ""type"": ""Button"",
                    ""id"": ""728cb78c-abb5-4046-8cb8-db2d5e95a375"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""6b638a0e-2b09-4b6b-af45-1e2bf459ea14"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Click"",
                    ""type"": ""Button"",
                    ""id"": ""0a9f67b6-2497-4e16-a08c-5d89e3f5b61c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""de1ab434-1e0a-44d0-9b8b-bfc6fca9e009"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Click"",
                    ""type"": ""Button"",
                    ""id"": ""244da63b-2674-41ce-a28f-a6d4d734b514"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DropThruPlatform"",
                    ""type"": ""Button"",
                    ""id"": ""03073d5c-1de7-4441-89cf-7ba742f3d38b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimUp"",
                    ""type"": ""Button"",
                    ""id"": ""e1e8dc59-427e-4bfa-bc86-823231046d1d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimDown"",
                    ""type"": ""Button"",
                    ""id"": ""152e8264-6012-4185-9e3a-1bab5de27822"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cb1a77b1-3f2e-4cbe-92b2-01340ab9cd84"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8963700a-f4b3-4e3e-ba85-d96cc46351ad"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d05e788-754d-41eb-8ad1-7804f8a5d4e1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da613cce-c947-4fda-9ff4-91033137b1b5"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31c8399c-402a-46b2-b874-e912e1d4469a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e7b12a3-6c64-4c1f-bbfa-3bfb625610f9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dabfd281-b4e0-462b-b854-1fcb5b105f78"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7260fbd5-2d25-4347-b080-f2a3d26beb14"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1326f0b1-be23-4f3d-9bd4-9e715cbef98c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Melee Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4726ab3-66e0-4210-9203-bdb244f8c337"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Ranged Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cddd45ce-81c7-418a-98a5-25f22af303ad"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""035ef371-05e4-4aaa-b83f-ed1d22f9ca86"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87ce2e24-221a-4f17-a262-8c6a2b639906"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdbacd47-a6b6-4cf2-977a-268f65288812"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d5dbb43-256d-489f-91a2-3934b568aa3f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropThruPlatform"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7c9bfb1-9ee5-403b-b215-04fd78b1959e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2064351-2df3-443f-ac91-401cc65a1417"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aaea374-d958-494f-b90a-aa9c7d628b9a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f01a0f46-2305-449f-be9f-da79141dd53b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveLeft = m_Gameplay.FindAction("MoveLeft", throwIfNotFound: true);
        m_Gameplay_MoveRight = m_Gameplay.FindAction("MoveRight", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_Scroll = m_Gameplay.FindAction("Scroll", throwIfNotFound: true);
        m_Gameplay_PrimaryMeleeSelection = m_Gameplay.FindAction("Primary Melee Selection", throwIfNotFound: true);
        m_Gameplay_PrimaryRangedSelection = m_Gameplay.FindAction("Primary Ranged Selection", throwIfNotFound: true);
        m_Gameplay_Drop = m_Gameplay.FindAction("Drop", throwIfNotFound: true);
        m_Gameplay_LeftClick = m_Gameplay.FindAction("Left Click", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_RightClick = m_Gameplay.FindAction("Right Click", throwIfNotFound: true);
        m_Gameplay_DropThruPlatform = m_Gameplay.FindAction("DropThruPlatform", throwIfNotFound: true);
        m_Gameplay_AimUp = m_Gameplay.FindAction("AimUp", throwIfNotFound: true);
        m_Gameplay_AimDown = m_Gameplay.FindAction("AimDown", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_MoveLeft;
    private readonly InputAction m_Gameplay_MoveRight;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Scroll;
    private readonly InputAction m_Gameplay_PrimaryMeleeSelection;
    private readonly InputAction m_Gameplay_PrimaryRangedSelection;
    private readonly InputAction m_Gameplay_Drop;
    private readonly InputAction m_Gameplay_LeftClick;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_RightClick;
    private readonly InputAction m_Gameplay_DropThruPlatform;
    private readonly InputAction m_Gameplay_AimUp;
    private readonly InputAction m_Gameplay_AimDown;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_Gameplay_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_Gameplay_MoveRight;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Scroll => m_Wrapper.m_Gameplay_Scroll;
        public InputAction @PrimaryMeleeSelection => m_Wrapper.m_Gameplay_PrimaryMeleeSelection;
        public InputAction @PrimaryRangedSelection => m_Wrapper.m_Gameplay_PrimaryRangedSelection;
        public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
        public InputAction @LeftClick => m_Wrapper.m_Gameplay_LeftClick;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @RightClick => m_Wrapper.m_Gameplay_RightClick;
        public InputAction @DropThruPlatform => m_Wrapper.m_Gameplay_DropThruPlatform;
        public InputAction @AimUp => m_Wrapper.m_Gameplay_AimUp;
        public InputAction @AimDown => m_Wrapper.m_Gameplay_AimDown;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoveRight;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Scroll.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnScroll;
                @PrimaryMeleeSelection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryMeleeSelection;
                @PrimaryMeleeSelection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryMeleeSelection;
                @PrimaryMeleeSelection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryMeleeSelection;
                @PrimaryRangedSelection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryRangedSelection;
                @PrimaryRangedSelection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryRangedSelection;
                @PrimaryRangedSelection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryRangedSelection;
                @Drop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @LeftClick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeftClick;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @RightClick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRightClick;
                @DropThruPlatform.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDropThruPlatform;
                @DropThruPlatform.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDropThruPlatform;
                @DropThruPlatform.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDropThruPlatform;
                @AimUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimUp;
                @AimUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimUp;
                @AimUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimUp;
                @AimDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimDown;
                @AimDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimDown;
                @AimDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAimDown;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @PrimaryMeleeSelection.started += instance.OnPrimaryMeleeSelection;
                @PrimaryMeleeSelection.performed += instance.OnPrimaryMeleeSelection;
                @PrimaryMeleeSelection.canceled += instance.OnPrimaryMeleeSelection;
                @PrimaryRangedSelection.started += instance.OnPrimaryRangedSelection;
                @PrimaryRangedSelection.performed += instance.OnPrimaryRangedSelection;
                @PrimaryRangedSelection.canceled += instance.OnPrimaryRangedSelection;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @DropThruPlatform.started += instance.OnDropThruPlatform;
                @DropThruPlatform.performed += instance.OnDropThruPlatform;
                @DropThruPlatform.canceled += instance.OnDropThruPlatform;
                @AimUp.started += instance.OnAimUp;
                @AimUp.performed += instance.OnAimUp;
                @AimUp.canceled += instance.OnAimUp;
                @AimDown.started += instance.OnAimDown;
                @AimDown.performed += instance.OnAimDown;
                @AimDown.canceled += instance.OnAimDown;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnPrimaryMeleeSelection(InputAction.CallbackContext context);
        void OnPrimaryRangedSelection(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnDropThruPlatform(InputAction.CallbackContext context);
        void OnAimUp(InputAction.CallbackContext context);
        void OnAimDown(InputAction.CallbackContext context);
    }
}
