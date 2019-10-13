// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection
{
    private InputActionAsset asset;
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gesturing"",
            ""id"": ""c2a53fbf-1ccc-498e-bb11-12bc206ab26e"",
            ""actions"": [
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""e3d63370-0a62-4d76-8ef5-613ad183c572"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Value"",
                    ""id"": ""53a90e85-d328-4fbb-b528-8e488817f00d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1fe27f33-f1c6-4424-bdf5-837d8e0f2468"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d5ea361-bba7-464a-bd44-a742aeab2c25"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""055e8bd3-b381-4ef0-8265-f44b40ddaf3e"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc7eea81-979a-4c6a-b123-99d01b28225b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gesturing
        m_Gesturing = asset.FindActionMap("Gesturing", throwIfNotFound: true);
        m_Gesturing_Press = m_Gesturing.FindAction("Press", throwIfNotFound: true);
        m_Gesturing_Drag = m_Gesturing.FindAction("Drag", throwIfNotFound: true);
    }

    ~Controls()
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

    // Gesturing
    private readonly InputActionMap m_Gesturing;
    private IGesturingActions m_GesturingActionsCallbackInterface;
    private readonly InputAction m_Gesturing_Press;
    private readonly InputAction m_Gesturing_Drag;
    public struct GesturingActions
    {
        private Controls m_Wrapper;
        public GesturingActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Press => m_Wrapper.m_Gesturing_Press;
        public InputAction @Drag => m_Wrapper.m_Gesturing_Drag;
        public InputActionMap Get() { return m_Wrapper.m_Gesturing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GesturingActions set) { return set.Get(); }
        public void SetCallbacks(IGesturingActions instance)
        {
            if (m_Wrapper.m_GesturingActionsCallbackInterface != null)
            {
                Press.started -= m_Wrapper.m_GesturingActionsCallbackInterface.OnPress;
                Press.performed -= m_Wrapper.m_GesturingActionsCallbackInterface.OnPress;
                Press.canceled -= m_Wrapper.m_GesturingActionsCallbackInterface.OnPress;
                Drag.started -= m_Wrapper.m_GesturingActionsCallbackInterface.OnDrag;
                Drag.performed -= m_Wrapper.m_GesturingActionsCallbackInterface.OnDrag;
                Drag.canceled -= m_Wrapper.m_GesturingActionsCallbackInterface.OnDrag;
            }
            m_Wrapper.m_GesturingActionsCallbackInterface = instance;
            if (instance != null)
            {
                Press.started += instance.OnPress;
                Press.performed += instance.OnPress;
                Press.canceled += instance.OnPress;
                Drag.started += instance.OnDrag;
                Drag.performed += instance.OnDrag;
                Drag.canceled += instance.OnDrag;
            }
        }
    }
    public GesturingActions @Gesturing => new GesturingActions(this);
    public interface IGesturingActions
    {
        void OnPress(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
    }
}
