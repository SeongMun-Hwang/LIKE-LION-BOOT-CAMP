using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : ITurnOnable
{
    public void TurnOn()
    {
        Debug.Log("���������� TV��");
    }

    public void TurnOff()
    {
        Debug.Log("���������� TV��");
    }
}
