using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    private string Name;
    protected int Hp;
    public static string Shout = "We are Character";
    public static int counter = 0;

    public static void WeAre()
    {
        Debug.Log(Shout);
    }
    public int HP
    {
        get { return Hp; }
        set { Hp= value; }
    }

    public Character()
    {

    }
    public Character(string name, int hp)
    {
        this.Name = name;
        this.Hp = hp;
    }

    public virtual void Hit(int damage)
    {
        counter++;
        Hp -= damage;
        Debug.Log("Ouch");
    }
    public void Heal(int heal)
    {
        if (isAlive())
        {
            Hp += heal;
        }
    }
    public bool isAlive()
    {
        return Hp > 0;
    }
    public void Eat(Food food)
    {
        if (isAlive())
        {
            Hp += food.Hp;
        }
    }

}
