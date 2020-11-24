// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerAction"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""7f2fa6e3-5188-4a62-9e86-957a3f46079c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ef45e965-10db-4cb5-b4ab-8c77fcc1b783"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionJoystick"",
                    ""type"": ""Value"",
                    ""id"": ""04da4a04-7593-42d5-83f1-792084add839"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionButton"",
                    ""type"": ""Button"",
                    ""id"": ""b8bf0f03-21ea-4c46-a8f7-adc3c7c39d3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionJoystickRelease"",
                    ""type"": ""Button"",
                    ""id"": ""c6ef2bb3-59f3-48e5-b7cf-36713d46f519"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""fd957333-3ff9-4c3e-8db0-e4e8c928b148"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d1ed3943-b886-41e7-af05-79f51c52188d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fb67af45-696d-464f-9ae3-e927a48632d4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ecde0547-2489-4ce7-bb41-e7a9516d347b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d724d7fa-9460-40eb-baad-e4999e20d661"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c31d4fb2-0e89-4da0-b32e-272c4a12a88d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""ea5a5f6e-8472-488e-a414-fd963c6a8b9b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8ff4a9ae-206a-4908-90e2-ec23047a20c8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2ae8d96c-87b9-4941-8360-43e9a42a0c62"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c240ab6d-3f33-4dc3-be3f-11c9aec6fa9f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ea31e22b-801d-44a7-b44b-61b36a57d3d8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""98e14922-9412-4f34-8800-8af2232cef44"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionJoystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5a38c16-aa47-42eb-85ef-219df1d4b8b9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f352bfb5-e5f6-4413-bf8b-caa1ac657a82"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55e6c36f-2e8a-4349-85a3-c5ad1590c30a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionJoystickRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Move = m_Main.FindAction("Move", throwIfNotFound: true);
        m_Main_ActionJoystick = m_Main.FindAction("ActionJoystick", throwIfNotFound: true);
        m_Main_ActionButton = m_Main.FindAction("ActionButton", throwIfNotFound: true);
        m_Main_ActionJoystickRelease = m_Main.FindAction("ActionJoystickRelease", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Move;
    private readonly InputAction m_Main_ActionJoystick;
    private readonly InputAction m_Main_ActionButton;
    private readonly InputAction m_Main_ActionJoystickRelease;
    public struct MainActions
    {
        private @PlayerAction m_Wrapper;
        public MainActions(@PlayerAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Main_Move;
        public InputAction @ActionJoystick => m_Wrapper.m_Main_ActionJoystick;
        public InputAction @ActionButton => m_Wrapper.m_Main_ActionButton;
        public InputAction @ActionJoystickRelease => m_Wrapper.m_Main_ActionJoystickRelease;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMove;
                @ActionJoystick.started -= m_Wrapper.m_MainActionsCallbackInterface.OnActionJoystick;
                @ActionJoystick.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnActionJoystick;
                @ActionJoystick.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnActionJoystick;
                @ActionButton.started -= m_Wrapper.m_MainActionsCallbackInterface.OnActionButton;
                @ActionButton.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnActionButton;
                @ActionButton.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnActionButton;
                @ActionJoystickRelease.started -= m_Wrapper.m_MainActionsCallbackInterface.OnActionJoystickRelease;
                @ActionJoystickRelease.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnActionJoystickRelease;
                @ActionJoystickRelease.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnActionJoystickRelease;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ActionJoystick.started += instance.OnActionJoystick;
                @ActionJoystick.performed += instance.OnActionJoystick;
                @ActionJoystick.canceled += instance.OnActionJoystick;
                @ActionButton.started += instance.OnActionButton;
                @ActionButton.performed += instance.OnActionButton;
                @ActionButton.canceled += instance.OnActionButton;
                @ActionJoystickRelease.started += instance.OnActionJoystickRelease;
                @ActionJoystickRelease.performed += instance.OnActionJoystickRelease;
                @ActionJoystickRelease.canceled += instance.OnActionJoystickRelease;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnActionJoystick(InputAction.CallbackContext context);
        void OnActionButton(InputAction.CallbackContext context);
        void OnActionJoystickRelease(InputAction.CallbackContext context);
    }
}
