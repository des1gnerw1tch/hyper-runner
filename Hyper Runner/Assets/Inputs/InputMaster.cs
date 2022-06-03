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
                },
                {
                    ""name"": ""FastFowardStart"",
                    ""type"": ""Button"",
                    ""id"": ""2ca580a0-a8ce-4856-abac-b4acdc9457c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""04ff4765-a800-4512-ab9e-f3ab33d4bc3b"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""2414359a-a175-456f-96b4-fe4880b023d6"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""FastFowardStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5472834-6b81-4cc7-81e6-c12e567d53c6"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e010cf5e-0d3d-4028-b15b-2b40eb6987f9"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""PauseGame"",
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
                    ""name"": ""LeftDanceKeyPress"",
                    ""type"": ""Button"",
                    ""id"": ""f45c7248-1235-474a-82ee-73a3e9b9c7de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftDanceKeyRelease"",
                    ""type"": ""Button"",
                    ""id"": ""908ec07a-b98e-4857-9cf0-c60fc1f3810e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightDanceKeyPress"",
                    ""type"": ""Button"",
                    ""id"": ""644359ec-a7ab-4f74-b40e-40464d5287af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightDanceKeyRelease"",
                    ""type"": ""Button"",
                    ""id"": ""9779c74c-f565-4b80-bdca-5791c5a5908d"",
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
                },
                {
                    ""name"": ""FastFowardStart"",
                    ""type"": ""Button"",
                    ""id"": ""f7994f71-2ab6-4562-8686-4b0a7d73dcbf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""d90c9bfb-f7df-4d61-a312-5b699486c171"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""dc2634e5-4a6f-47a9-a2fd-bd42c16b75cc"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""FastFowardStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b70ddb0-9f97-4677-bf6f-bffe84e19d9d"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""LeftDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58793332-5c0e-4c44-8625-cef51ba5e88a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""LeftDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2353fea9-b8fa-4194-a62e-d7961db8d94c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""LeftDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43b7c420-02ad-4dfc-9914-65847b6eee9c"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""LeftDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96fe84a1-319b-46b1-9203-10f3ba017bd3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""LeftDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c74265c7-e8f9-4943-b85b-d9903d2b0f11"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""LeftDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f9aaf8f-103d-4be6-9203-f902a40ac661"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""RightDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b14572cd-0594-4f83-ba79-3820d4c49901"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""RightDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd6f2470-9b7a-4a87-b847-2b05c042a67e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""RightDanceKeyRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27d391bf-470c-4f68-a2b4-a485aebdeeca"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""RightDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fb3dac7-0a10-4484-b8ef-b24e77b13c44"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""RightDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9f50b2b-62ec-47bd-8543-b50f917ae421"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""RightDanceKeyPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cafd875-9faa-4de8-a0ef-41a2f8e00212"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bce0ede6-64e7-420c-a332-fde1177aede1"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""PauseGame"",
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
                    ""type"": ""Value"",
                    ""id"": ""2f06be00-3656-41a9-9adb-3a660e3c7d4a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""64f4a115-e413-4405-a7e4-18870ec0b57d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""AxisDeadzone"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5c21af16-f2a5-4fb9-a004-cd83fa2ac40a"",
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
                    ""id"": ""1ab0a873-a2ba-43d3-b634-efc8ca6a5713"",
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
                    ""id"": ""34c7fdf1-f30c-4bdd-9754-ca63abe24c23"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Walk Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""181f7a99-9c5e-43b1-a541-a2e147f9c54b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
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
                    ""id"": ""52abbe52-50c9-4544-99b5-cffd92406df9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""39b994cb-f6df-461d-8ceb-ef25331c6a6e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Walk Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5640610d-8729-44b9-a5a9-6c1803fd578a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
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
                    ""name"": """",
                    ""id"": ""ab24a392-a05d-4357-aaf7-aac0a5ef2991"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": ""Invert,Scale(factor=0.5)"",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Look Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9931d91-8ff8-4a6a-b4e4-90a694dadb85"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=1.5)"",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Look Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""eda29d67-a5ca-4e4b-bd2e-dbcd25a9a2ee"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""050ea1e0-8655-4de6-a0e6-0838d8128247"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3da6ad9b-ca25-4c72-8480-3a7092204191"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Look Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""233a04b1-84bb-4729-bd99-d7dd5f8bf8de"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25dc27be-4499-47d5-bff0-4eea18a7cc0e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""2de05b09-2637-4e27-9d70-80764ddda516"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""496fc090-348e-4cc5-9377-a145146447fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""4c7f5601-6240-45cf-a9a6-710b66602e15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""e7bef0e3-7ca3-4b1b-9afb-d53a81d0dbc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""43ef0b62-b476-445d-b940-ae8cdf210a31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""c70d7263-a1fd-42b3-8653-280c1e1e37da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PauseGame"",
                    ""type"": ""Button"",
                    ""id"": ""cf27eab8-e7bf-4b20-9d09-ec6401dec2e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""9cb710d7-5cf9-4f40-b61d-9ba67817962d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e8ae6fd1-5b63-4163-b3b2-3f44a1eff506"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae731393-8b2e-4efe-a483-74773affc6f7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77a75b16-638e-42c7-b99f-295721f99643"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""280ab0d2-ff73-4acd-9630-b5326ef7655e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""511c1e92-5f2f-4fd0-9efa-b992e535756a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""009f46e0-b258-4688-8008-6755410f5919"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75fc479a-d720-4e40-8011-bad9e3a9f9a6"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fd028fb-3d9c-4714-b998-237efe43e315"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0772df92-5397-4bec-86d3-8ce4b6fdc193"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dd2da07-9f9a-4b7a-855c-97e691380d6f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""PauseGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6e6a208-52ef-49b0-88e0-8391029f4d5f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""680442d8-fda3-4c05-9cc3-5ea4009a6856"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard Control Scheme"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cefae018-02c4-4eb9-845a-1bb03ebb8a6a"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Control Scheme"",
                    ""action"": ""Back"",
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
        },
        {
            ""name"": ""Keyboard Control Scheme"",
            ""bindingGroup"": ""Keyboard Control Scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
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
        m_Platformer_FastFowardStart = m_Platformer.FindAction("FastFowardStart", throwIfNotFound: true);
        m_Platformer_PauseGame = m_Platformer.FindAction("PauseGame", throwIfNotFound: true);
        // Dancer
        m_Dancer = asset.FindActionMap("Dancer", throwIfNotFound: true);
        m_Dancer_UpDanceKeyPress = m_Dancer.FindAction("UpDanceKeyPress", throwIfNotFound: true);
        m_Dancer_UpDanceKeyRelease = m_Dancer.FindAction("UpDanceKeyRelease", throwIfNotFound: true);
        m_Dancer_DownDanceKeyPress = m_Dancer.FindAction("DownDanceKeyPress", throwIfNotFound: true);
        m_Dancer_DownDanceKeyRelease = m_Dancer.FindAction("DownDanceKeyRelease", throwIfNotFound: true);
        m_Dancer_LeftDanceKeyPress = m_Dancer.FindAction("LeftDanceKeyPress", throwIfNotFound: true);
        m_Dancer_LeftDanceKeyRelease = m_Dancer.FindAction("LeftDanceKeyRelease", throwIfNotFound: true);
        m_Dancer_RightDanceKeyPress = m_Dancer.FindAction("RightDanceKeyPress", throwIfNotFound: true);
        m_Dancer_RightDanceKeyRelease = m_Dancer.FindAction("RightDanceKeyRelease", throwIfNotFound: true);
        m_Dancer_AnyDanceKeyPress = m_Dancer.FindAction("AnyDanceKeyPress", throwIfNotFound: true);
        m_Dancer_FastFowardStart = m_Dancer.FindAction("FastFowardStart", throwIfNotFound: true);
        m_Dancer_PauseGame = m_Dancer.FindAction("PauseGame", throwIfNotFound: true);
        // 3D
        m__3D = asset.FindActionMap("3D", throwIfNotFound: true);
        m__3D_WalkVertical = m__3D.FindAction("Walk Vertical", throwIfNotFound: true);
        m__3D_WalkHorizontal = m__3D.FindAction("Walk Horizontal", throwIfNotFound: true);
        m__3D_LookVertical = m__3D.FindAction("Look Vertical", throwIfNotFound: true);
        m__3D_LookHorizontal = m__3D.FindAction("Look Horizontal", throwIfNotFound: true);
        m__3D_Interact = m__3D.FindAction("Interact", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Up = m_UI.FindAction("Up", throwIfNotFound: true);
        m_UI_Down = m_UI.FindAction("Down", throwIfNotFound: true);
        m_UI_Left = m_UI.FindAction("Left", throwIfNotFound: true);
        m_UI_Right = m_UI.FindAction("Right", throwIfNotFound: true);
        m_UI_Select = m_UI.FindAction("Select", throwIfNotFound: true);
        m_UI_PauseGame = m_UI.FindAction("PauseGame", throwIfNotFound: true);
        m_UI_Back = m_UI.FindAction("Back", throwIfNotFound: true);
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
    private readonly InputAction m_Platformer_FastFowardStart;
    private readonly InputAction m_Platformer_PauseGame;
    public struct PlatformerActions
    {
        private @InputMaster m_Wrapper;
        public PlatformerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Platformer_Jump;
        public InputAction @FloorDown => m_Wrapper.m_Platformer_FloorDown;
        public InputAction @FloorUp => m_Wrapper.m_Platformer_FloorUp;
        public InputAction @FastFowardStart => m_Wrapper.m_Platformer_FastFowardStart;
        public InputAction @PauseGame => m_Wrapper.m_Platformer_PauseGame;
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
                @FastFowardStart.started -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFastFowardStart;
                @FastFowardStart.performed -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFastFowardStart;
                @FastFowardStart.canceled -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnFastFowardStart;
                @PauseGame.started -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_PlatformerActionsCallbackInterface.OnPauseGame;
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
                @FastFowardStart.started += instance.OnFastFowardStart;
                @FastFowardStart.performed += instance.OnFastFowardStart;
                @FastFowardStart.canceled += instance.OnFastFowardStart;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
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
    private readonly InputAction m_Dancer_LeftDanceKeyPress;
    private readonly InputAction m_Dancer_LeftDanceKeyRelease;
    private readonly InputAction m_Dancer_RightDanceKeyPress;
    private readonly InputAction m_Dancer_RightDanceKeyRelease;
    private readonly InputAction m_Dancer_AnyDanceKeyPress;
    private readonly InputAction m_Dancer_FastFowardStart;
    private readonly InputAction m_Dancer_PauseGame;
    public struct DancerActions
    {
        private @InputMaster m_Wrapper;
        public DancerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpDanceKeyPress => m_Wrapper.m_Dancer_UpDanceKeyPress;
        public InputAction @UpDanceKeyRelease => m_Wrapper.m_Dancer_UpDanceKeyRelease;
        public InputAction @DownDanceKeyPress => m_Wrapper.m_Dancer_DownDanceKeyPress;
        public InputAction @DownDanceKeyRelease => m_Wrapper.m_Dancer_DownDanceKeyRelease;
        public InputAction @LeftDanceKeyPress => m_Wrapper.m_Dancer_LeftDanceKeyPress;
        public InputAction @LeftDanceKeyRelease => m_Wrapper.m_Dancer_LeftDanceKeyRelease;
        public InputAction @RightDanceKeyPress => m_Wrapper.m_Dancer_RightDanceKeyPress;
        public InputAction @RightDanceKeyRelease => m_Wrapper.m_Dancer_RightDanceKeyRelease;
        public InputAction @AnyDanceKeyPress => m_Wrapper.m_Dancer_AnyDanceKeyPress;
        public InputAction @FastFowardStart => m_Wrapper.m_Dancer_FastFowardStart;
        public InputAction @PauseGame => m_Wrapper.m_Dancer_PauseGame;
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
                @LeftDanceKeyPress.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnLeftDanceKeyPress;
                @LeftDanceKeyPress.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnLeftDanceKeyPress;
                @LeftDanceKeyPress.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnLeftDanceKeyPress;
                @LeftDanceKeyRelease.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnLeftDanceKeyRelease;
                @LeftDanceKeyRelease.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnLeftDanceKeyRelease;
                @LeftDanceKeyRelease.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnLeftDanceKeyRelease;
                @RightDanceKeyPress.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnRightDanceKeyPress;
                @RightDanceKeyPress.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnRightDanceKeyPress;
                @RightDanceKeyPress.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnRightDanceKeyPress;
                @RightDanceKeyRelease.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnRightDanceKeyRelease;
                @RightDanceKeyRelease.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnRightDanceKeyRelease;
                @RightDanceKeyRelease.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnRightDanceKeyRelease;
                @AnyDanceKeyPress.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnAnyDanceKeyPress;
                @AnyDanceKeyPress.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnAnyDanceKeyPress;
                @AnyDanceKeyPress.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnAnyDanceKeyPress;
                @FastFowardStart.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnFastFowardStart;
                @FastFowardStart.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnFastFowardStart;
                @FastFowardStart.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnFastFowardStart;
                @PauseGame.started -= m_Wrapper.m_DancerActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_DancerActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_DancerActionsCallbackInterface.OnPauseGame;
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
                @LeftDanceKeyPress.started += instance.OnLeftDanceKeyPress;
                @LeftDanceKeyPress.performed += instance.OnLeftDanceKeyPress;
                @LeftDanceKeyPress.canceled += instance.OnLeftDanceKeyPress;
                @LeftDanceKeyRelease.started += instance.OnLeftDanceKeyRelease;
                @LeftDanceKeyRelease.performed += instance.OnLeftDanceKeyRelease;
                @LeftDanceKeyRelease.canceled += instance.OnLeftDanceKeyRelease;
                @RightDanceKeyPress.started += instance.OnRightDanceKeyPress;
                @RightDanceKeyPress.performed += instance.OnRightDanceKeyPress;
                @RightDanceKeyPress.canceled += instance.OnRightDanceKeyPress;
                @RightDanceKeyRelease.started += instance.OnRightDanceKeyRelease;
                @RightDanceKeyRelease.performed += instance.OnRightDanceKeyRelease;
                @RightDanceKeyRelease.canceled += instance.OnRightDanceKeyRelease;
                @AnyDanceKeyPress.started += instance.OnAnyDanceKeyPress;
                @AnyDanceKeyPress.performed += instance.OnAnyDanceKeyPress;
                @AnyDanceKeyPress.canceled += instance.OnAnyDanceKeyPress;
                @FastFowardStart.started += instance.OnFastFowardStart;
                @FastFowardStart.performed += instance.OnFastFowardStart;
                @FastFowardStart.canceled += instance.OnFastFowardStart;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
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
    private readonly InputAction m__3D_Interact;
    public struct _3DActions
    {
        private @InputMaster m_Wrapper;
        public _3DActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @WalkVertical => m_Wrapper.m__3D_WalkVertical;
        public InputAction @WalkHorizontal => m_Wrapper.m__3D_WalkHorizontal;
        public InputAction @LookVertical => m_Wrapper.m__3D_LookVertical;
        public InputAction @LookHorizontal => m_Wrapper.m__3D_LookHorizontal;
        public InputAction @Interact => m_Wrapper.m__3D_Interact;
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
                @Interact.started -= m_Wrapper.m__3DActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m__3DActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m__3DActionsCallbackInterface.OnInteract;
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
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public _3DActions @_3D => new _3DActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Up;
    private readonly InputAction m_UI_Down;
    private readonly InputAction m_UI_Left;
    private readonly InputAction m_UI_Right;
    private readonly InputAction m_UI_Select;
    private readonly InputAction m_UI_PauseGame;
    private readonly InputAction m_UI_Back;
    public struct UIActions
    {
        private @InputMaster m_Wrapper;
        public UIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_UI_Up;
        public InputAction @Down => m_Wrapper.m_UI_Down;
        public InputAction @Left => m_Wrapper.m_UI_Left;
        public InputAction @Right => m_Wrapper.m_UI_Right;
        public InputAction @Select => m_Wrapper.m_UI_Select;
        public InputAction @PauseGame => m_Wrapper.m_UI_PauseGame;
        public InputAction @Back => m_Wrapper.m_UI_Back;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRight;
                @Select.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSelect;
                @PauseGame.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseGame;
                @Back.started -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
        void OnFastFowardStart(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface IDancerActions
    {
        void OnUpDanceKeyPress(InputAction.CallbackContext context);
        void OnUpDanceKeyRelease(InputAction.CallbackContext context);
        void OnDownDanceKeyPress(InputAction.CallbackContext context);
        void OnDownDanceKeyRelease(InputAction.CallbackContext context);
        void OnLeftDanceKeyPress(InputAction.CallbackContext context);
        void OnLeftDanceKeyRelease(InputAction.CallbackContext context);
        void OnRightDanceKeyPress(InputAction.CallbackContext context);
        void OnRightDanceKeyRelease(InputAction.CallbackContext context);
        void OnAnyDanceKeyPress(InputAction.CallbackContext context);
        void OnFastFowardStart(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface I_3DActions
    {
        void OnWalkVertical(InputAction.CallbackContext context);
        void OnWalkHorizontal(InputAction.CallbackContext context);
        void OnLookVertical(InputAction.CallbackContext context);
        void OnLookHorizontal(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnPauseGame(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
