using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    void Start()
    {
        Car car= new Car();
        car.TurnOn();

        ITurnOnable anObject = car;
        anObject.TurnOff();

        Character.WeAre();
        Debug.Log(Character.Shout);

        Character c1=new Character();
        Character c2=new Character();

        c1.Hit(10);
        c2.Hit(10);

        Debug.Log(Character.counter);
    }

}
