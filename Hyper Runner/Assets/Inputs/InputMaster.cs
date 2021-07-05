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
                    ""id"": ""ed0588b3-8918-4d98-8a97-d2e44b6b5c74"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c2b5dee-3a73-44e9-b24f-6eb8815240b6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f74a0936-e47d-4305-8dd4-a085e972505b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
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
                    ""id"": ""8ea6cea3-2c91-4f0d-8cd1-3314ea72de2f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""FloorDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4978dc9b-3dcb-43af-97b6-6d2afacc867e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""03c2e77f-2bc3-4bd3-99c0-7423cb24bfd9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""FloorUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fd72f1a-a09f-45d0-8088-8fe133e8b5d4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
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
                    ""id"": ""a319a9cf-789e-45b1-b83c-cea13206ae35"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""UpDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dec84756-0270-4335-a30e-509bc86cb33f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
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
                    ""id"": ""20bbad5d-172b-42cf-bbf2-c36d14526109"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""UpDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00b80775-ba67-4807-aee0-0865449d89cb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
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
                    ""id"": ""6b9df6b4-aea4-45ca-a1cf-b37ad3d65c1c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""DownDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e0494ef-321b-47a5-b5e1-885a885fe824"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""DownDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb342962-eb50-4b22-b1c2-7129bea0c25f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""DownDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""493dc3fd-d1e8-4f23-9218-8e6321bf8ea7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""DownDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81e9a629-472d-40af-a375-4b9019cc6539"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""AnyDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""3D"",
            ""id"": ""2efcf548-4df8-4cc9-bac5-e430b1d8e68b"",
            ""actions"": [
                {
                    ""name"": ""Walk Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""78ecc4e5-94a8-436b-b96b-a7b57893f56a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""166f2c9a-026d-48e7-8263-987df4aba04e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""2f06be00-3656-41a9-9adb-3a660e3c7d4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""64f4a115-e413-4405-a7e4-18870ec0b57d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""3da5d1c9-7d2d-4e3e-8f73-5a06619ca7d6"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a8d8e0bf-7755-458a-aa69-2893bceb8d19"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Walk Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""02699c84-d1d1-40d6-bf5d-7df10232707f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Walk Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""aa60e4c5-224d-4bcb-9d01-185f6fe46959"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Walk Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""43a4921a-932c-4352-91d9-e659296dd219"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Walk Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""75a8b902-cb3b-4af2-b72e-0e5d552b1a4d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Walk Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c008a98e-a695-43ae-ab93-327e277560de"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b58a8c30-d506-49e3-9d7d-4fe84953f2e2"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e5d30346-c1b7-4bed-81d9-19b335b247f0"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""9478b454-256d-4ad2-97c9-51dd67caf944"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ef4842de-f61d-48ae-8ef7-f69dfd346e70"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d08f7f8e-4f56-4538-806b-6cd6f919249f"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        },
        {
            ""name"": ""Keyboard Control Scheme"",
            ""bindingGroup"": ""Keyboard Control Scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
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
        // 3D
        m__3D = asset.FindActionMap("3D", throwIfNotFound: true);
        m__3D_WalkVertical = m__3D.FindAction("Walk Vertical", throwIfNotFound: true);
        m__3D_WalkHorizontal = m__3D.FindAction("Walk Horizontal", throwIfNotFound: true);
        m__3D_LookVertical = m__3D.FindAction("Look Vertical", throwIfNotFound: true);
        m__3D_LookHorizontal = m__3D.FindAction("Look Horizontal", throwIfNotFound: true);
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

    // 3D
    private readonly InputActionMap m__3D;
    private I_3DActions m__3DActionsCallbackInterface;
    private readonly InputAction m__3D_WalkVertical;
    private readonly InputAction m__3D_WalkHorizontal;
    private readonly InputAction m__3D_LookVertical;
    private readonly InputAction m__3D_LookHorizontal;
    public struct _3DActions
    {
        private @InputMaster m_Wrapper;
        public _3DActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @WalkVertical => m_Wrapper.m__3D_WalkVertical;
        public InputAction @WalkHorizontal => m_Wrapper.m__3D_WalkHorizontal;
        public InputAction @LookVertical => m_Wrapper.m__3D_LookVertical;
        public InputAction @LookHorizontal => m_Wrapper.m__3D_LookHorizontal;
        public InputActionMap Get() { return m_Wrapper.m__3D; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(_3DActions set) { return set.Get(); }
        public void SetCallbacks(I_3DActions instance)
        {
            if (m_Wrapper.m__3DActionsCallbackInterface != null)
            {
                @WalkVertical.started -= m_Wrapper.m__3DActionsCallbackInterface.OnWalkVertical;
                @WalkVertical.performed -= m_Wrapper.m__3DActionsCallbackInterface.OnWalkVertical;
                @WalkVertical.canceled -= m_Wrapper.m__3DActionsCallbackInterface.OnWalkVertical;
                @WalkHorizontal.started -= m_Wrapper.m__3DActionsCallbackInterface.OnWalkHorizontal;
                @WalkHorizontal.performed -= m_Wrapper.m__3DActionsCallbackInterface.OnWalkHorizontal;
                @WalkHorizontal.canceled -= m_Wrapper.m__3DActionsCallbackInterface.OnWalkHorizontal;
                @LookVertical.started -= m_Wrapper.m__3DActionsCallbackInterface.OnLookVertical;
                @LookVertical.performed -= m_Wrapper.m__3DActionsCallbackInterface.OnLookVertical;
                @LookVertical.canceled -= m_Wrapper.m__3DActionsCallbackInterface.OnLookVertical;
                @LookHorizontal.started -= m_Wrapper.m__3DActionsCallbackInterface.OnLookHorizontal;
                @LookHorizontal.performed -= m_Wrapper.m__3DActionsCallbackInterface.OnLookHorizontal;
                @LookHorizontal.canceled -= m_Wrapper.m__3DActionsCallbackInterface.OnLookHorizontal;
            }
            m_Wrapper.m__3DActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WalkVertical.started += instance.OnWalkVertical;
                @WalkVertical.performed += instance.OnWalkVertical;
                @WalkVertical.canceled += instance.OnWalkVertical;
                @WalkHorizontal.started += instance.OnWalkHorizontal;
                @WalkHorizontal.performed += instance.OnWalkHorizontal;
                @WalkHorizontal.canceled += instance.OnWalkHorizontal;
                @LookVertical.started += instance.OnLookVertical;
                @LookVertical.performed += instance.OnLookVertical;
                @LookVertical.canceled += instance.OnLookVertical;
                @LookHorizontal.started += instance.OnLookHorizontal;
                @LookHorizontal.performed += instance.OnLookHorizontal;
                @LookHorizontal.canceled += instance.OnLookHorizontal;
            }
        }
    }
    public _3DActions @_3D => new _3DActions(this);
    private int m_XboxControlSchemeSchemeIndex = -1;
    public InputControlScheme XboxControlSchemeScheme
    {
        get
        {
            if (m_XboxControlSchemeSchemeIndex == -1) m_XboxControlSchemeSchemeIndex = asset.FindControlSchemeIndex("Xbox Control Scheme");
            return asset.controlSchemes[m_XboxControlSchemeSchemeIndex];
        }
    }
    private int m_KeyboardControlSchemeSchemeIndex = -1;
    public InputControlScheme KeyboardControlSchemeScheme
    {
        get
        {
            if (m_KeyboardControlSchemeSchemeIndex == -1) m_KeyboardControlSchemeSchemeIndex = asset.FindControlSchemeIndex("Keyboard Control Scheme");
            return asset.controlSchemes[m_KeyboardControlSchemeSchemeIndex];
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
    public interface I_3DActions
    {
        void OnWalkVertical(InputAction.CallbackContext context);
        void OnWalkHorizontal(InputAction.CallbackContext context);
        void OnLookVertical(InputAction.CallbackContext context);
        void OnLookHorizontal(InputAction.CallbackContext context);
    }
}
