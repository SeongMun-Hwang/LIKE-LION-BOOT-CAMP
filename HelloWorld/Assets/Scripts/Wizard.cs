using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    public int Mp;

    public Wizard(string name, int hp) : base(name, hp)
    {

    }

    public Wizard(string name,int hp,int mp)
    {
        //this.Name = name;
        //this.Hp = hp;
        //this.Mp = mp;
    }
    public void useMagic()
    {
        if (Mp >= 5 && isAlive())
        {
            Mp = -5;
            Debug.Log("¸¶¹ý");
        }
    }
}
