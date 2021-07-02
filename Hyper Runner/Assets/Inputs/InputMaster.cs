// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Platformer"",
            ""id"": ""22f5051d-fd71-4012-b249-920c105eb816"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8ddda6ed-cb3c-40c2-bd75-133ba3008deb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FloorDown"",
                    ""type"": ""Button"",
                    ""id"": ""92636550-eaad-49fc-83ae-4d641b28e354"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FloorUp"",
                    ""type"": ""Button"",
                    ""id"": ""64afec85-3f8a-44ea-92bc-3ba5b2e31749"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4168ad15-e0e3-41d8-bda5-dffd3837f3f5"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bdde47d-8887-474a-b116-6ee8ba4fd457"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""FloorDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01c454f2-7e2d-49b6-9fb1-df64ada081ff"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""FloorUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dancer"",
            ""id"": ""a4ed752d-8478-4fca-a144-1973bc585256"",
            ""actions"": [
                {
                    ""name"": ""UpDanceKeyPress"",
                    ""type"": ""Button"",
                    ""id"": ""163e3bc8-38e7-4bc2-9960-cac3c857ccb3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpDanceKeyRelease"",
                    ""type"": ""Button"",
                    ""id"": ""aaf918d7-51b2-48ff-bf71-5a9fd6a8b0b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownDanceKeyPress"",
                    ""type"": ""Button"",
                    ""id"": ""4596c6a7-b2cb-4e69-8414-6987309753c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DownDanceKeyRelease"",
                    ""type"": ""Button"",
                    ""id"": ""f889207c-b3f6-4fd8-b789-175820196179"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AnyDanceKeyPress"",
                    ""type"": ""Button"",
                    ""id"": ""1e0c36ad-9a79-4dba-a304-08c537101030"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""23e7114e-7de7-464c-8a8b-c9cfd9df80e9"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""UpDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e47e8428-c532-42b4-b16e-e4b16a0b230e"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""UpDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bf3ed89-49ca-4bfe-975d-d943e72524a9"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""DownDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d913bab6-6f2d-4941-9c40-885293d3a808"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""DownDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7be2d889-4c08-48d3-906c-4e287251d1c3"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e182aade-7697-47d7-a508-52d0ce61438a"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox Control Scheme"",
            ""bindingGroup"": ""Xbox Control Scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Platformer
        m_Platformer = asset.FindActionMap("Platformer", throwIfNotFound: true);
        m_Platformer_Jump = m_Platformer.FindAction("Jump", throwIfNotFound: true);
        m_Platformer_FloorDown = m_Platformer.FindAction("FloorDown", throwIfNotFound: true);
        m_Platformer_FloorUp = m_Platformer.FindAction("FloorUp", throwIfNotFound: true);
        // Dancer
        m_Dancer = asset.FindActionMap("Dancer", throwIfNotFound: true);
        m_Dancer_UpDanceKeyPress = m_Dancer.FindAction("UpDanceKeyPress", throwIfNotFound: true);
        m_Dancer_UpDanceKeyRelease = m_Dancer.FindAction("UpDanceKeyRelease", throwIfNotFound: true);
        m_Dancer_DownDanceKeyPress = m_Dancer.FindAction("DownDanceKeyPress", throwIfNotFound: true);
        m_Dancer_DownDanceKeyRelease = m_Dancer.FindAction("DownDanceKeyRelease", throwIfNotFound: true);
        m_Dancer_AnyDanceKeyPress = m_Dancer.FindAction("AnyDanceKeyPress", throwIfNotFound: true);
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

    // Platformer
    private readonly InputActionMap m_Platformer;
    private IPlatformerActions m_PlatformerActionsCallbackInterface;
    private readonly InputAction m_Platformer_Jump;
    private readonly InputAction m_Platformer_FloorDown;
    private readonly InputAction m_Platformer_FloorUp;
    public struct PlatformerActions
    {
        private @InputMaster m_Wrapper;
        public PlatformerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Platformer_Jump;
        public InputAction @FloorDown => m_Wrapper.m_Platformer_FloorDown;
        public InputAction @FloorUp => m_Wrapper.m_Platformer_FloorUp;
        public InputActionMap Get() { return m_Wrapper.m_Platformer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlatformerActions set) { return set.Get(); }
        public void SetCallbacks(IPlatformerActions instance)
        {
            if (m_Wrapper.m_PlatformerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnJump;
                @FloorDown.started -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFloorDown;
                @FloorDown.performed -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFloorDown;
                @FloorDown.canceled -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFloorDown;
                @FloorUp.started -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFloorUp;
                @FloorUp.performed -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFloorUp;
                @FloorUp.canceled -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFloorUp;
            }
            m_Wrapper.m_PlatformerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @FloorDown.started += instance.OnFloorDown;
                @FloorDown.performed += instance.OnFloorDown;
                @FloorDown.canceled += instance.OnFloorDown;
                @FloorUp.started += instance.OnFloorUp;
                @FloorUp.performed += instance.OnFloorUp;
                @FloorUp.canceled += instance.OnFloorUp;
            }
        }
    }
    public PlatformerActions @Platformer => new PlatformerActions(this);

    // Dancer
    private readonly InputActionMap m_Dancer;
    private IDancerActions m_DancerActionsCallbackInterface;
    private readonly InputAction m_Dancer_UpDanceKeyPress;
    private readonly InputAction m_Dancer_UpDanceKeyRelease;
    private readonly InputAction m_Dancer_DownDanceKeyPress;
    private readonly InputAction m_Dancer_DownDanceKeyRelease;
    private readonly InputAction m_Dancer_AnyDanceKeyPress;
    public struct DancerActions
    {
        private @InputMaster m_Wrapper;
        public DancerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpDanceKeyPress => m_Wrapper.m_Dancer_UpDanceKeyPress;
        public InputAction @UpDanceKeyRelease => m_Wrapper.m_Dancer_UpDanceKeyRelease;
        public InputAction @DownDanceKeyPress => m_Wrapper.m_Dancer_DownDanceKeyPress;
        public InputAction @DownDanceKeyRelease => m_Wrapper.m_Dancer_DownDanceKeyRelease;
        public InputAction @AnyDanceKeyPress => m_Wrapper.m_Dancer_AnyDanceKeyPress;
        public InputActionMap Get() { return m_Wrapper.m_Dancer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DancerActions set) { return set.Get(); }
        public void SetCallbacks(IDancerActions instance)
        {
            if (m_Wrapper.m_DancerActionsCallbackInterface != null)
            {
                @UpDanceKeyPress.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnUpDanceKeyPress;
                @UpDanceKeyPress.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnUpDanceKeyPress;
                @UpDanceKeyPress.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnUpDanceKeyPress;
                @UpDanceKeyRelease.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnUpDanceKeyRelease;
                @UpDanceKeyRelease.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnUpDanceKeyRelease;
                @UpDanceKeyRelease.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnUpDanceKeyRelease;
                @DownDanceKeyPress.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnDownDanceKeyPress;
                @DownDanceKeyPress.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnDownDanceKeyPress;
                @DownDanceKeyPress.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnDownDanceKeyPress;
                @DownDanceKeyRelease.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnDownDanceKeyRelease;
                @DownDanceKeyRelease.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnDownDanceKeyRelease;
                @DownDanceKeyRelease.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnDownDanceKeyRelease;
                @AnyDanceKeyPress.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnAnyDanceKeyPress;
                @AnyDanceKeyPress.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnAnyDanceKeyPress;
                @AnyDanceKeyPress.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnAnyDanceKeyPress;
            }
            m_Wrapper.m_DancerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpDanceKeyPress.started += instance.OnUpDanceKeyPress;
                @UpDanceKeyPress.performed += instance.OnUpDanceKeyPress;
                @UpDanceKeyPress.canceled += instance.OnUpDanceKeyPress;
                @UpDanceKeyRelease.started += instance.OnUpDanceKeyRelease;
                @UpDanceKeyRelease.performed += instance.OnUpDanceKeyRelease;
                @UpDanceKeyRelease.canceled += instance.OnUpDanceKeyRelease;
                @DownDanceKeyPress.started += instance.OnDownDanceKeyPress;
                @DownDanceKeyPress.performed += instance.OnDownDanceKeyPress;
                @DownDanceKeyPress.canceled += instance.OnDownDanceKeyPress;
                @DownDanceKeyRelease.started += instance.OnDownDanceKeyRelease;
                @DownDanceKeyRelease.performed += instance.OnDownDanceKeyRelease;
                @DownDanceKeyRelease.canceled += instance.OnDownDanceKeyRelease;
                @AnyDanceKeyPress.started += instance.OnAnyDanceKeyPress;
                @AnyDanceKeyPress.performed += instance.OnAnyDanceKeyPress;
                @AnyDanceKeyPress.canceled += instance.OnAnyDanceKeyPress;
            }
        }
    }
    public DancerActions @Dancer => new DancerActions(this);
    private int m_XboxControlSchemeSchemeIndex = -1;
    public InputControlScheme XboxControlSchemeScheme
    {
        get
        {
            if (m_XboxControlSchemeSchemeIndex == -1) m_XboxControlSchemeSchemeIndex = asset.FindControlSchemeIndex("Xbox Control Scheme");
            return asset.controlSchemes[m_XboxControlSchemeSchemeIndex];
        }
    }
    public interface IPlatformerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnFloorDown(InputAction.CallbackContext context);
        void OnFloorUp(InputAction.CallbackContext context);
    }
    public interface IDancerActions
    {
        void OnUpDanceKeyPress(InputAction.CallbackContext context);
        void OnUpDanceKeyRelease(InputAction.CallbackContext context);
        void OnDownDanceKeyPress(InputAction.CallbackContext context);
        void OnDownDanceKeyRelease(InputAction.CallbackContext context);
        void OnAnyDanceKeyPress(InputAction.CallbackContext context);
    }
}
