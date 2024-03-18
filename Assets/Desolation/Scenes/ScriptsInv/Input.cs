using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Input : MonoBehaviour
{
    public static event Action OnAddItem = () => { };
    public static event Action OnRemoveItem = () => { };



    public static void OnAddItemOnSlot()
    {
        OnAddItem?.Invoke();

    }
    public static void OnRemoveItemOnSlot()
    {
        OnRemoveItem?.Invoke();

    }
}
