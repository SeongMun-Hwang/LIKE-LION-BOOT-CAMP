using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : ITurnOnable
{
    public void TurnOn()
    {
        Debug.Log("Å° ²È°í ½Ãµ¿ ÄÑ");   
    }

    public void TurnOff()
    {
        Debug.Log("½Ãµ¿ ²ô°í Å° »©");
    }
}
