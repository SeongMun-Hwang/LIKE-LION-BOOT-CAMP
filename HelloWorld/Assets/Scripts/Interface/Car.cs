using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : ITurnOnable
{
    public void TurnOn()
    {
        Debug.Log("Ű �Ȱ� �õ� ��");   
    }

    public void TurnOff()
    {
        Debug.Log("�õ� ���� Ű ��");
    }
}
