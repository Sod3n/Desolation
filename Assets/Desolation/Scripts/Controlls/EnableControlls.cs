using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class EnableControlls : IInitializable
{
    private Controlls _controlls;

    public EnableControlls(Controlls controlls)
    {
        _controlls = controlls;
    }

    public void Initialize()
    {
        _controlls.Enable();
    }
}
