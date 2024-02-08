//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Desolation/Scripts/Controlls/Controlls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controlls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controlls"",
    ""maps"": [
        {
            ""name"": ""GameMap"",
            ""id"": ""f7b04bd8-ed3a-4238-9a31-d70b6c9e48a0"",
            ""actions"": [
                {
                    ""name"": ""BasicAttack"",
                    ""type"": ""Button"",
                    ""id"": ""f5170612-8fa7-4427-94b8-d0b567042cf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SkillOne"",
                    ""type"": ""Button"",
                    ""id"": ""a43de607-671b-4613-906a-1ab1b44893da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkillTwo"",
                    ""type"": ""Button"",
                    ""id"": ""e9bea372-9db8-45b4-92c1-81f07781c975"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SkillThree"",
                    ""type"": ""Button"",
                    ""id"": ""59599d4f-2521-4543-8c30-319dce080a31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AimPoint"",
                    ""type"": ""Value"",
                    ""id"": ""8159618b-7a5d-427a-9e90-bc1937a84597"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveVector"",
                    ""type"": ""Value"",
                    ""id"": ""9c82b41e-13e5-4fd4-9ff2-ad6e87213733"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0ecf7a0b-8e3a-4543-8d3d-552327949113"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BasicAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdc6495f-e454-4ad3-ba37-29ade21a457d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""SkillOne"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4e5a79b-f40f-4731-a90d-ce6005e7ce46"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillTwo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""469d2bbd-528b-4c7c-9503-26ca4a0d955d"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SkillThree"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a59d4c5c-06ea-41f0-ab9d-eb532f251de0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimPoint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f652512e-f219-4e58-8401-9b4ae379006f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVector"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8748a086-b170-43d9-81ab-a4922ccd391a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5ab61923-2695-42ba-b335-3ffd97ebf1fa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0a86952f-8393-4b17-a53b-217a4bae10e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""53ba622d-7bf6-47e5-bec6-5c706340030c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveVector"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameMap
        m_GameMap = asset.FindActionMap("GameMap", throwIfNotFound: true);
        m_GameMap_BasicAttack = m_GameMap.FindAction("BasicAttack", throwIfNotFound: true);
        m_GameMap_SkillOne = m_GameMap.FindAction("SkillOne", throwIfNotFound: true);
        m_GameMap_SkillTwo = m_GameMap.FindAction("SkillTwo", throwIfNotFound: true);
        m_GameMap_SkillThree = m_GameMap.FindAction("SkillThree", throwIfNotFound: true);
        m_GameMap_AimPoint = m_GameMap.FindAction("AimPoint", throwIfNotFound: true);
        m_GameMap_MoveVector = m_GameMap.FindAction("MoveVector", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GameMap
    private readonly InputActionMap m_GameMap;
    private List<IGameMapActions> m_GameMapActionsCallbackInterfaces = new List<IGameMapActions>();
    private readonly InputAction m_GameMap_BasicAttack;
    private readonly InputAction m_GameMap_SkillOne;
    private readonly InputAction m_GameMap_SkillTwo;
    private readonly InputAction m_GameMap_SkillThree;
    private readonly InputAction m_GameMap_AimPoint;
    private readonly InputAction m_GameMap_MoveVector;
    public struct GameMapActions
    {
        private @Controlls m_Wrapper;
        public GameMapActions(@Controlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @BasicAttack => m_Wrapper.m_GameMap_BasicAttack;
        public InputAction @SkillOne => m_Wrapper.m_GameMap_SkillOne;
        public InputAction @SkillTwo => m_Wrapper.m_GameMap_SkillTwo;
        public InputAction @SkillThree => m_Wrapper.m_GameMap_SkillThree;
        public InputAction @AimPoint => m_Wrapper.m_GameMap_AimPoint;
        public InputAction @MoveVector => m_Wrapper.m_GameMap_MoveVector;
        public InputActionMap Get() { return m_Wrapper.m_GameMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameMapActions set) { return set.Get(); }
        public void AddCallbacks(IGameMapActions instance)
        {
            if (instance == null || m_Wrapper.m_GameMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameMapActionsCallbackInterfaces.Add(instance);
            @BasicAttack.started += instance.OnBasicAttack;
            @BasicAttack.performed += instance.OnBasicAttack;
            @BasicAttack.canceled += instance.OnBasicAttack;
            @SkillOne.started += instance.OnSkillOne;
            @SkillOne.performed += instance.OnSkillOne;
            @SkillOne.canceled += instance.OnSkillOne;
            @SkillTwo.started += instance.OnSkillTwo;
            @SkillTwo.performed += instance.OnSkillTwo;
            @SkillTwo.canceled += instance.OnSkillTwo;
            @SkillThree.started += instance.OnSkillThree;
            @SkillThree.performed += instance.OnSkillThree;
            @SkillThree.canceled += instance.OnSkillThree;
            @AimPoint.started += instance.OnAimPoint;
            @AimPoint.performed += instance.OnAimPoint;
            @AimPoint.canceled += instance.OnAimPoint;
            @MoveVector.started += instance.OnMoveVector;
            @MoveVector.performed += instance.OnMoveVector;
            @MoveVector.canceled += instance.OnMoveVector;
        }

        private void UnregisterCallbacks(IGameMapActions instance)
        {
            @BasicAttack.started -= instance.OnBasicAttack;
            @BasicAttack.performed -= instance.OnBasicAttack;
            @BasicAttack.canceled -= instance.OnBasicAttack;
            @SkillOne.started -= instance.OnSkillOne;
            @SkillOne.performed -= instance.OnSkillOne;
            @SkillOne.canceled -= instance.OnSkillOne;
            @SkillTwo.started -= instance.OnSkillTwo;
            @SkillTwo.performed -= instance.OnSkillTwo;
            @SkillTwo.canceled -= instance.OnSkillTwo;
            @SkillThree.started -= instance.OnSkillThree;
            @SkillThree.performed -= instance.OnSkillThree;
            @SkillThree.canceled -= instance.OnSkillThree;
            @AimPoint.started -= instance.OnAimPoint;
            @AimPoint.performed -= instance.OnAimPoint;
            @AimPoint.canceled -= instance.OnAimPoint;
            @MoveVector.started -= instance.OnMoveVector;
            @MoveVector.performed -= instance.OnMoveVector;
            @MoveVector.canceled -= instance.OnMoveVector;
        }

        public void RemoveCallbacks(IGameMapActions instance)
        {
            if (m_Wrapper.m_GameMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameMapActions instance)
        {
            foreach (var item in m_Wrapper.m_GameMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameMapActions @GameMap => new GameMapActions(this);
    public interface IGameMapActions
    {
        void OnBasicAttack(InputAction.CallbackContext context);
        void OnSkillOne(InputAction.CallbackContext context);
        void OnSkillTwo(InputAction.CallbackContext context);
        void OnSkillThree(InputAction.CallbackContext context);
        void OnAimPoint(InputAction.CallbackContext context);
        void OnMoveVector(InputAction.CallbackContext context);
    }
}
