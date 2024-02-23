using UnityEngine;
using System;

public class InputDeer : MonoBehaviour
{
    public static event Action OnTargetAppear = () => { };
    public static event Action OnTargetLost = () => { };
    public static event Action OnTargetChange = () => { };


    public static void InvokeOnTargetAppear()
    {
        OnTargetAppear?.Invoke();
    }
    public static void InvokeOnTargetLost()
    {
        OnTargetLost?.Invoke();
    }
    public static void InvokeOnTargetChange()
    {
        OnTargetChange?.Invoke();
    }
}
