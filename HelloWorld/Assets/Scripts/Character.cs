using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name;
    public int Hp;

    public Character()
    {

    }
    public Character(string name, int hp)
    {
        this.Name = name;
        this.Hp = hp;
    }

    public void Hit(int damage)
    {
        Hp -= damage;
    }
    public void Heal(int heal)
    {
        Hp += heal;
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
