using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    float Area(float x, float y)
    {
        x += 1;
        return x * y;
    }
    void Start()
    {
        Debug.Log("Hello World!");
        float x = 10f;
        float y = 20f;
        Debug.Log(Area(x, y));

        Character c = new Character("Kim", 10);
        Food f = new Food();
        f.Name = "Protein";
        f.Hp = 5;

        c.Hit(5);
        c.Heal(3);

        c.Eat(f);
        Debug.Log(c.Hp);
        Debug.Log(c.isAlive());

        c.Hit(999);
        c.Eat(f);
        Debug.Log(c.Hp);
        Debug.Log(c.isAlive());

        Wizard wizard = new Wizard("¸¶¹ý»ç",15,20);
        wizard.useMagic();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
