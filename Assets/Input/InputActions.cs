//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Input/InputActions.inputactions
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

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Faucet"",
            ""id"": ""4fa5267d-fb10-44ba-9429-049292bb8479"",
            ""actions"": [
                {
                    ""name"": ""SpewWater"",
                    ""type"": ""Button"",
                    ""id"": ""3e6f1efe-c4ec-423f-b0ce-efeaec2227ef"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpewBeer"",
                    ""type"": ""Button"",
                    ""id"": ""66120625-313e-41f8-9eb1-5602b26580b0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpewBubbles"",
                    ""type"": ""Button"",
                    ""id"": ""88e65685-2f13-43bb-a37a-c25c6ca7f240"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""71e777cd-c84b-4212-9b3f-d706b7cab876"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6216e8c3-231a-44fe-a213-1e9ab8c2dd37"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpewWater"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a737119e-c7fa-4380-8f64-756b7c9e48fb"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpewBeer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d2f9a5b-2d4a-46dc-9a4a-22256199ec08"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpewBubbles"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f25b8c0-7187-4bf9-bb87-630a21ba58a9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Faucet
        m_Faucet = asset.FindActionMap("Faucet", throwIfNotFound: true);
        m_Faucet_SpewWater = m_Faucet.FindAction("SpewWater", throwIfNotFound: true);
        m_Faucet_SpewBeer = m_Faucet.FindAction("SpewBeer", throwIfNotFound: true);
        m_Faucet_SpewBubbles = m_Faucet.FindAction("SpewBubbles", throwIfNotFound: true);
        m_Faucet_Pause = m_Faucet.FindAction("Pause", throwIfNotFound: true);
    }

    ~@InputActions()
    {
        UnityEngine.Debug.Assert(!m_Faucet.enabled, "This will cause a leak and performance issues, InputActions.Faucet.Disable() has not been called.");
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

    // Faucet
    private readonly InputActionMap m_Faucet;
    private List<IFaucetActions> m_FaucetActionsCallbackInterfaces = new List<IFaucetActions>();
    private readonly InputAction m_Faucet_SpewWater;
    private readonly InputAction m_Faucet_SpewBeer;
    private readonly InputAction m_Faucet_SpewBubbles;
    private readonly InputAction m_Faucet_Pause;
    public struct FaucetActions
    {
        private @InputActions m_Wrapper;
        public FaucetActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @SpewWater => m_Wrapper.m_Faucet_SpewWater;
        public InputAction @SpewBeer => m_Wrapper.m_Faucet_SpewBeer;
        public InputAction @SpewBubbles => m_Wrapper.m_Faucet_SpewBubbles;
        public InputAction @Pause => m_Wrapper.m_Faucet_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Faucet; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FaucetActions set) { return set.Get(); }
        public void AddCallbacks(IFaucetActions instance)
        {
            if (instance == null || m_Wrapper.m_FaucetActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FaucetActionsCallbackInterfaces.Add(instance);
            @SpewWater.started += instance.OnSpewWater;
            @SpewWater.performed += instance.OnSpewWater;
            @SpewWater.canceled += instance.OnSpewWater;
            @SpewBeer.started += instance.OnSpewBeer;
            @SpewBeer.performed += instance.OnSpewBeer;
            @SpewBeer.canceled += instance.OnSpewBeer;
            @SpewBubbles.started += instance.OnSpewBubbles;
            @SpewBubbles.performed += instance.OnSpewBubbles;
            @SpewBubbles.canceled += instance.OnSpewBubbles;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IFaucetActions instance)
        {
            @SpewWater.started -= instance.OnSpewWater;
            @SpewWater.performed -= instance.OnSpewWater;
            @SpewWater.canceled -= instance.OnSpewWater;
            @SpewBeer.started -= instance.OnSpewBeer;
            @SpewBeer.performed -= instance.OnSpewBeer;
            @SpewBeer.canceled -= instance.OnSpewBeer;
            @SpewBubbles.started -= instance.OnSpewBubbles;
            @SpewBubbles.performed -= instance.OnSpewBubbles;
            @SpewBubbles.canceled -= instance.OnSpewBubbles;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IFaucetActions instance)
        {
            if (m_Wrapper.m_FaucetActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFaucetActions instance)
        {
            foreach (var item in m_Wrapper.m_FaucetActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FaucetActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FaucetActions @Faucet => new FaucetActions(this);
    public interface IFaucetActions
    {
        void OnSpewWater(InputAction.CallbackContext context);
        void OnSpewBeer(InputAction.CallbackContext context);
        void OnSpewBubbles(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
