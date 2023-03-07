using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour
{
    public static StarterAssets starterAssets;
    public static event Action ReBindComplete;
    public static event Action RebindCanceled;
    public static event Action<InputAction, int> RebindStarted;

    private void Awake()
    {
        if (starterAssets == null)
            starterAssets = new StarterAssets();

    }

    public static void StartRebind(string ActionName, int BindingIndex, TMP_Text StatusText, bool ExcludeMouse)
    {
        InputAction action = starterAssets.asset.FindAction(ActionName);
        if (action == null || action.bindings.Count <= BindingIndex)
        {
            Debug.Log("Couldn't find action or binding");
            return;
        }

        if (action.bindings[BindingIndex].isComposite)
        {
            int FirstPartIndex = BindingIndex + 1;
            if (FirstPartIndex < action.bindings.Count && action.bindings[FirstPartIndex].isComposite)
                DoRebind(action, BindingIndex, StatusText, true, ExcludeMouse);


        }
        else
            DoRebind(action, BindingIndex, StatusText, false, ExcludeMouse);
    }

    private static void DoRebind(InputAction RebindAction, int BindingIndex, TMP_Text statusText, bool AllCompositeParts, bool ExcludeMouse)
    {
        if (RebindAction == null || BindingIndex < 0)
            return;

        statusText.text = $"Press a {RebindAction.expectedControlType}";

        RebindAction.Disable();

        var Rebind = RebindAction.PerformInteractiveRebinding(BindingIndex);

        Rebind.OnComplete(Operation =>
        {
            RebindAction.Enable();
            Operation.Dispose();

            if (AllCompositeParts)
            {
                int NextBindingIndex = BindingIndex + 1;
                if (NextBindingIndex < RebindAction.bindings.Count && RebindAction.bindings[NextBindingIndex].isPartOfComposite)
                    DoRebind(RebindAction, NextBindingIndex, statusText, AllCompositeParts, ExcludeMouse);
            }

            SaveBindingOveride(RebindAction);
            ReBindComplete?.Invoke();
        });

        Rebind.OnCancel(Operation =>
        {
            RebindAction.Enable();
            Operation.Dispose();

            RebindCanceled?.Invoke();
        });

        Rebind.WithCancelingThrough("<Keyboard>/escape");

        if (ExcludeMouse)
            Rebind.WithControlsExcluding("Mouse");

        RebindStarted?.Invoke(RebindAction, BindingIndex);
        Rebind.Start(); // Starts the rebinding process
    }

    public static string GetBindingName(string ActionName, int Bindingindex)
    {
        if (starterAssets == null)
            starterAssets = new StarterAssets();

        InputAction action = starterAssets.asset.FindAction(ActionName);
        return action.GetBindingDisplayString(Bindingindex);
    }

    private static void SaveBindingOveride(InputAction action)
    {
        for (int i = 0; i < action.bindings.Count; i++)
        {
            PlayerPrefs.SetString(action.actionMap + action.name + i, action.bindings[i].overridePath);
        }
    }

    public static void LoadBindingOveride(string ActionName)
    {
        if (starterAssets == null)
            starterAssets = new StarterAssets();

        InputAction action = starterAssets.asset.FindAction(ActionName);

        for (int i = 0; i < action.bindings.Count; i++)
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString(action.actionMap + action.name + i)))
                action.ApplyBindingOverride(i, PlayerPrefs.GetString(action.actionMap + action.name + i));
        }
    }

    public static void ResetBinding(string ActionName, int BindingIndex)
    {
        InputAction action = starterAssets.asset.FindAction(ActionName);

        if (action == null || action.bindings.Count <= BindingIndex)
        {
            Debug.Log("Couldn't find action or binding");
            return;
        }

        if (action.bindings[BindingIndex].isComposite)
        {
            for (int i = BindingIndex; i < action.bindings.Count && action.bindings[i].isComposite; i++)
            {
                action.RemoveBindingOverride(i);
            }



        }
        else
            action.RemoveBindingOverride(BindingIndex);

        SaveBindingOveride(action);
    }
}