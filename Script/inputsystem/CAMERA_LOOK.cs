//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Script/inputsystem/CAMERA_LOOK.inputactions
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

public partial class @CAMERA_LOOK: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CAMERA_LOOK()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CAMERA_LOOK"",
    ""maps"": [
        {
            ""name"": ""CAMERA"",
            ""id"": ""5ea630d3-69b0-439e-b90f-e4429a52b7b0"",
            ""actions"": [
                {
                    ""name"": ""LOOK"",
                    ""type"": ""Value"",
                    ""id"": ""eb709073-639d-4435-aa7e-5df4d6020c48"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8da5a4cc-1cff-4c49-a5b8-c6d29ca6f706"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LOOK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CAMERA
        m_CAMERA = asset.FindActionMap("CAMERA", throwIfNotFound: true);
        m_CAMERA_LOOK = m_CAMERA.FindAction("LOOK", throwIfNotFound: true);
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

    // CAMERA
    private readonly InputActionMap m_CAMERA;
    private List<ICAMERAActions> m_CAMERAActionsCallbackInterfaces = new List<ICAMERAActions>();
    private readonly InputAction m_CAMERA_LOOK;
    public struct CAMERAActions
    {
        private @CAMERA_LOOK m_Wrapper;
        public CAMERAActions(@CAMERA_LOOK wrapper) { m_Wrapper = wrapper; }
        public InputAction @LOOK => m_Wrapper.m_CAMERA_LOOK;
        public InputActionMap Get() { return m_Wrapper.m_CAMERA; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CAMERAActions set) { return set.Get(); }
        public void AddCallbacks(ICAMERAActions instance)
        {
            if (instance == null || m_Wrapper.m_CAMERAActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CAMERAActionsCallbackInterfaces.Add(instance);
            @LOOK.started += instance.OnLOOK;
            @LOOK.performed += instance.OnLOOK;
            @LOOK.canceled += instance.OnLOOK;
        }

        private void UnregisterCallbacks(ICAMERAActions instance)
        {
            @LOOK.started -= instance.OnLOOK;
            @LOOK.performed -= instance.OnLOOK;
            @LOOK.canceled -= instance.OnLOOK;
        }

        public void RemoveCallbacks(ICAMERAActions instance)
        {
            if (m_Wrapper.m_CAMERAActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICAMERAActions instance)
        {
            foreach (var item in m_Wrapper.m_CAMERAActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CAMERAActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CAMERAActions @CAMERA => new CAMERAActions(this);
    public interface ICAMERAActions
    {
        void OnLOOK(InputAction.CallbackContext context);
    }
}