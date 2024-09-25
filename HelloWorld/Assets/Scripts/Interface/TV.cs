using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : ITurnOnable
{
    public void TurnOn()
    {
        Debug.Log("리모컨으로 TV켜");
    }

    public void TurnOff()
    {
        Debug.Log("리모컨으로 TV꺼");
    }
}
