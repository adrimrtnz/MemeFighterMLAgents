// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls1.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls1 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls1"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""78eeedd9-dccb-47a0-8795-742752fa350a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b7896190-4a19-4b9a-9b98-247b1b97f873"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d5488bde-04d8-435c-921d-a6ade044608e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""1e8717e3-398f-4552-9e57-0f666d813a66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""b2425c5d-3a0e-472e-a1f2-5f7dc9df5d39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PunchF"",
                    ""type"": ""Button"",
                    ""id"": ""c1638709-0c03-4bfe-8614-2d6a06bc448d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PunchE"",
                    ""type"": ""Button"",
                    ""id"": ""790c5728-a314-4b46-b915-426d8f18cb2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""DPad"",
                    ""id"": ""3e1866e1-7c4b-4f19-9222-c052bb5afcdf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d369b7ca-eea3-48ec-852e-229e58e0d747"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d8490f26-6017-4fb4-b435-f3a0b2a7d7de"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystickk"",
                    ""id"": ""47fc4a9e-ad45-43bf-868f-33a3bffd214b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6ab4cd42-9926-471b-b428-48db64167e47"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2184d489-961e-47f7-9669-eedfcd82394d"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""8e1534d6-d96c-4a8b-b7e0-4dcdef0409b3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ce6d9ca6-2402-4fac-a06c-e1a5de692095"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bb9e75a8-af38-45dd-a6e7-a78d95da9182"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Fechas"",
                    ""id"": ""1bb65554-b794-4ce9-ae32-4fcb0ed8dcdd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""85e211d6-6119-4c5e-9f0e-d537ecd1d3be"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""43ab3fd7-9c46-4652-93a1-f71623f2852a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""61175dee-9b6c-47a5-a231-e6be4ac9956b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7aed8bf5-f355-46b6-b786-94a574edbd30"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e9aa805-a205-4aec-a53e-242af38f210f"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87a3f2b1-615f-4b2f-a0ed-b3d9866329f5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2342ad41-e10f-4a87-b2ec-f5430dd862c1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fc69d24-5ac6-4cd9-91dc-6db99be94137"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c76aa90c-67ac-4ef1-8614-0603e7136d66"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87a2a6f8-2490-482f-8e10-c5d03a919da0"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b4336e3-d237-4149-9acb-b05434c1dab7"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1acfcdb-a6da-4862-81d2-4542ef3562ca"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c41fb9dc-1e93-453d-a6db-0d9e568ddb96"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5404f8f-c5ed-476a-b334-352ac1139710"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a49f4b0-9f33-408b-85bc-eb8fc1c13d71"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0bf4809-4dcd-4639-8bea-2d429db998a0"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f135f043-32ee-4536-9d81-7e1b093a7cbd"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PunchF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2d23aa8-81c0-4917-891e-967da1981ab0"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""PunchF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afd1f925-6821-44a6-823a-5f9f604f09e7"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""PunchF"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""867fe054-fe60-4199-b667-d318ff1a1ed0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""PunchE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9955974-c597-4494-a387-0eaa8c26d6d6"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard1"",
                    ""action"": ""PunchE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8a22131-22fe-45b7-ab15-17402b08aeb5"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard2"",
                    ""action"": ""PunchE"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard1"",
            ""bindingGroup"": ""Keyboard1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard2"",
            ""bindingGroup"": ""Keyboard2"",
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
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_Move = m_Player1.FindAction("Move", throwIfNotFound: true);
        m_Player1_Jump = m_Player1.FindAction("Jump", throwIfNotFound: true);
        m_Player1_Crouch = m_Player1.FindAction("Crouch", throwIfNotFound: true);
        m_Player1_Punch = m_Player1.FindAction("Punch", throwIfNotFound: true);
        m_Player1_PunchF = m_Player1.FindAction("PunchF", throwIfNotFound: true);
        m_Player1_PunchE = m_Player1.FindAction("PunchE", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_Move;
    private readonly InputAction m_Player1_Jump;
    private readonly InputAction m_Player1_Crouch;
    private readonly InputAction m_Player1_Punch;
    private readonly InputAction m_Player1_PunchF;
    private readonly InputAction m_Player1_PunchE;
    public struct Player1Actions
    {
        private @Controls1 m_Wrapper;
        public Player1Actions(@Controls1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player1_Move;
        public InputAction @Jump => m_Wrapper.m_Player1_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player1_Crouch;
        public InputAction @Punch => m_Wrapper.m_Player1_Punch;
        public InputAction @PunchF => m_Wrapper.m_Player1_PunchF;
        public InputAction @PunchE => m_Wrapper.m_Player1_PunchE;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCrouch;
                @Punch.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunch;
                @PunchF.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunchF;
                @PunchF.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunchF;
                @PunchF.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunchF;
                @PunchE.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunchE;
                @PunchE.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunchE;
                @PunchE.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPunchE;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @PunchF.started += instance.OnPunchF;
                @PunchF.performed += instance.OnPunchF;
                @PunchF.canceled += instance.OnPunchF;
                @PunchE.started += instance.OnPunchE;
                @PunchE.performed += instance.OnPunchE;
                @PunchE.canceled += instance.OnPunchE;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_Keyboard1SchemeIndex = -1;
    public InputControlScheme Keyboard1Scheme
    {
        get
        {
            if (m_Keyboard1SchemeIndex == -1) m_Keyboard1SchemeIndex = asset.FindControlSchemeIndex("Keyboard1");
            return asset.controlSchemes[m_Keyboard1SchemeIndex];
        }
    }
    private int m_Keyboard2SchemeIndex = -1;
    public InputControlScheme Keyboard2Scheme
    {
        get
        {
            if (m_Keyboard2SchemeIndex == -1) m_Keyboard2SchemeIndex = asset.FindControlSchemeIndex("Keyboard2");
            return asset.controlSchemes[m_Keyboard2SchemeIndex];
        }
    }
    public interface IPlayer1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnPunch(InputAction.CallbackContext context);
        void OnPunchF(InputAction.CallbackContext context);
        void OnPunchE(InputAction.CallbackContext context);
    }
}
