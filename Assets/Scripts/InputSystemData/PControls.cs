//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/InputSystemData/PControls.inputactions
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

public partial class @PControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b0edce51-7c0c-465b-bbcd-0c96303cbce4"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""43508069-6ab4-412e-bdb1-252a760b97d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""f74efb45-26d0-420d-90b8-d37a56e44696"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""1ff9c2a1-2e20-4800-a7d9-5214d9c0c590"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Silent Walk"",
                    ""type"": ""Button"",
                    ""id"": ""f09ec8af-b36d-42a0-bfcf-41b306e78cd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4dd022e4-1df4-40ce-941d-79c93947174c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""e32c9dc1-67f6-416e-9fa2-a6a264712b5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fda79e14-e0c5-414f-9456-b840ae759b43"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""64d7bea0-f0c9-4913-87f0-d8e24a1fc460"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Lean"",
                    ""type"": ""Button"",
                    ""id"": ""81e37231-ddd5-4b0e-a431-ce838d8f9638"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fea16569-ed17-4ac4-9815-15653beb6b72"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""438b0b3c-a9ed-46c7-b0c5-d0a9b2278c0c"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c0de30c-ea17-4853-9512-a68b559d5ace"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63ed768d-b0eb-4c79-87f2-433444cc2761"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Silent Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6faea686-5120-455d-9afa-53dfcd1b4d24"",
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
                    ""id"": ""38baba89-d580-4eba-a125-581ff5b2075c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3f983b2-5fdc-4a1e-a518-70e2460c55ea"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""b77a1d6b-15b6-4927-a11a-d8c9632b88da"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""820dc964-1b57-4863-9236-03c3f99b7708"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""ff909b2b-9e0c-4991-8dab-a54d758b7149"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""e0f9fa06-8133-4670-8c6c-f0d377e42fa8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""b6d93a70-26f5-4350-9716-6e79db20ea6f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""e1b274e7-a913-42b2-848c-4e578fd21674"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lean"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0cf93873-a5a6-46aa-9e0a-2ecefbb78bb9"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lean"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0417e227-a6e0-4ec3-aee2-6c0c2759e940"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lean"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""d45e1606-2481-4121-abce-bfd631e2aef0"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""0ec801c7-11c8-4ecc-849a-b3c104061da2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d2948ba0-0eff-4cb2-a883-5eeb547e2df8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Abilities"",
            ""id"": ""79a2e96b-85e3-405d-9b7b-5858aa104f9e"",
            ""actions"": [
                {
                    ""name"": ""Flashlight"",
                    ""type"": ""Button"",
                    ""id"": ""0badc05b-b28d-4208-9a99-e423519a4e38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Speen Enhancment / Run Silent"",
                    ""type"": ""Button"",
                    ""id"": ""c6910084-4956-4d99-8b27-2116aaa271ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""250ce44b-f910-4e4b-9464-70fbf3f72b0e"",
                    ""path"": ""<Keyboard>/f12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Flashlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fbec175-0777-4581-a7f3-fc2100c5ac57"",
                    ""path"": ""<Keyboard>/f11"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speen Enhancment / Run Silent"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug Keys"",
            ""id"": ""17d98ca3-aa58-4a04-8073-ba7bbe5e56ba"",
            ""actions"": [
                {
                    ""name"": ""Reset Energy"",
                    ""type"": ""Button"",
                    ""id"": ""e17d99b8-12bd-4497-bf9f-398df1061647"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""02bd8d8c-08b4-4232-b314-22176d0c310e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset Energy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_SilentWalk = m_Player.FindAction("Silent Walk", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Mouse = m_Player.FindAction("Mouse", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Lean = m_Player.FindAction("Lean", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        // Abilities
        m_Abilities = asset.FindActionMap("Abilities", throwIfNotFound: true);
        m_Abilities_Flashlight = m_Abilities.FindAction("Flashlight", throwIfNotFound: true);
        m_Abilities_SpeenEnhancmentRunSilent = m_Abilities.FindAction("Speen Enhancment / Run Silent", throwIfNotFound: true);
        // Debug Keys
        m_DebugKeys = asset.FindActionMap("Debug Keys", throwIfNotFound: true);
        m_DebugKeys_ResetEnergy = m_DebugKeys.FindAction("Reset Energy", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Inventory;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_SilentWalk;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Mouse;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Lean;
    public struct PlayerActions
    {
        private @PControls m_Wrapper;
        public PlayerActions(@PControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @SilentWalk => m_Wrapper.m_Player_SilentWalk;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Mouse => m_Wrapper.m_Player_Mouse;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Lean => m_Wrapper.m_Player_Lean;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Inventory.started += instance.OnInventory;
            @Inventory.performed += instance.OnInventory;
            @Inventory.canceled += instance.OnInventory;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @SilentWalk.started += instance.OnSilentWalk;
            @SilentWalk.performed += instance.OnSilentWalk;
            @SilentWalk.canceled += instance.OnSilentWalk;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Mouse.started += instance.OnMouse;
            @Mouse.performed += instance.OnMouse;
            @Mouse.canceled += instance.OnMouse;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Lean.started += instance.OnLean;
            @Lean.performed += instance.OnLean;
            @Lean.canceled += instance.OnLean;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Inventory.started -= instance.OnInventory;
            @Inventory.performed -= instance.OnInventory;
            @Inventory.canceled -= instance.OnInventory;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @SilentWalk.started -= instance.OnSilentWalk;
            @SilentWalk.performed -= instance.OnSilentWalk;
            @SilentWalk.canceled -= instance.OnSilentWalk;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Mouse.started -= instance.OnMouse;
            @Mouse.performed -= instance.OnMouse;
            @Mouse.canceled -= instance.OnMouse;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Lean.started -= instance.OnLean;
            @Lean.performed -= instance.OnLean;
            @Lean.canceled -= instance.OnLean;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Pause;
    public struct UIActions
    {
        private @PControls m_Wrapper;
        public UIActions(@PControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);

    // Abilities
    private readonly InputActionMap m_Abilities;
    private List<IAbilitiesActions> m_AbilitiesActionsCallbackInterfaces = new List<IAbilitiesActions>();
    private readonly InputAction m_Abilities_Flashlight;
    private readonly InputAction m_Abilities_SpeenEnhancmentRunSilent;
    public struct AbilitiesActions
    {
        private @PControls m_Wrapper;
        public AbilitiesActions(@PControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Flashlight => m_Wrapper.m_Abilities_Flashlight;
        public InputAction @SpeenEnhancmentRunSilent => m_Wrapper.m_Abilities_SpeenEnhancmentRunSilent;
        public InputActionMap Get() { return m_Wrapper.m_Abilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AbilitiesActions set) { return set.Get(); }
        public void AddCallbacks(IAbilitiesActions instance)
        {
            if (instance == null || m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Add(instance);
            @Flashlight.started += instance.OnFlashlight;
            @Flashlight.performed += instance.OnFlashlight;
            @Flashlight.canceled += instance.OnFlashlight;
            @SpeenEnhancmentRunSilent.started += instance.OnSpeenEnhancmentRunSilent;
            @SpeenEnhancmentRunSilent.performed += instance.OnSpeenEnhancmentRunSilent;
            @SpeenEnhancmentRunSilent.canceled += instance.OnSpeenEnhancmentRunSilent;
        }

        private void UnregisterCallbacks(IAbilitiesActions instance)
        {
            @Flashlight.started -= instance.OnFlashlight;
            @Flashlight.performed -= instance.OnFlashlight;
            @Flashlight.canceled -= instance.OnFlashlight;
            @SpeenEnhancmentRunSilent.started -= instance.OnSpeenEnhancmentRunSilent;
            @SpeenEnhancmentRunSilent.performed -= instance.OnSpeenEnhancmentRunSilent;
            @SpeenEnhancmentRunSilent.canceled -= instance.OnSpeenEnhancmentRunSilent;
        }

        public void RemoveCallbacks(IAbilitiesActions instance)
        {
            if (m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAbilitiesActions instance)
        {
            foreach (var item in m_Wrapper.m_AbilitiesActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AbilitiesActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AbilitiesActions @Abilities => new AbilitiesActions(this);

    // Debug Keys
    private readonly InputActionMap m_DebugKeys;
    private List<IDebugKeysActions> m_DebugKeysActionsCallbackInterfaces = new List<IDebugKeysActions>();
    private readonly InputAction m_DebugKeys_ResetEnergy;
    public struct DebugKeysActions
    {
        private @PControls m_Wrapper;
        public DebugKeysActions(@PControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ResetEnergy => m_Wrapper.m_DebugKeys_ResetEnergy;
        public InputActionMap Get() { return m_Wrapper.m_DebugKeys; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugKeysActions set) { return set.Get(); }
        public void AddCallbacks(IDebugKeysActions instance)
        {
            if (instance == null || m_Wrapper.m_DebugKeysActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DebugKeysActionsCallbackInterfaces.Add(instance);
            @ResetEnergy.started += instance.OnResetEnergy;
            @ResetEnergy.performed += instance.OnResetEnergy;
            @ResetEnergy.canceled += instance.OnResetEnergy;
        }

        private void UnregisterCallbacks(IDebugKeysActions instance)
        {
            @ResetEnergy.started -= instance.OnResetEnergy;
            @ResetEnergy.performed -= instance.OnResetEnergy;
            @ResetEnergy.canceled -= instance.OnResetEnergy;
        }

        public void RemoveCallbacks(IDebugKeysActions instance)
        {
            if (m_Wrapper.m_DebugKeysActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDebugKeysActions instance)
        {
            foreach (var item in m_Wrapper.m_DebugKeysActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DebugKeysActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DebugKeysActions @DebugKeys => new DebugKeysActions(this);
    public interface IPlayerActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSilentWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnLean(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IAbilitiesActions
    {
        void OnFlashlight(InputAction.CallbackContext context);
        void OnSpeenEnhancmentRunSilent(InputAction.CallbackContext context);
    }
    public interface IDebugKeysActions
    {
        void OnResetEnergy(InputAction.CallbackContext context);
    }
}
