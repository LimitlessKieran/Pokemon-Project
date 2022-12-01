using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charizard : MonoBehaviour
{
    int health;
    int attack;
    int defense;

    string move1 = "Flamethrower";
    string move2 = "WingAttack";
    string move3 = "Bite";
    string move4 = "FireBlast";

    GameManager.Type type = GameManager.Type.FIRE;

    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        attack = 100;
        defense = 100;
    }

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public int getAttack()
    {
        return attack;
    }

    public int getDefense()
    {
        return defense;
    }

    public string getMove1()
    {
        return move1;
    }

    public string getMove2()
    {
        return move2;
    }

    public string getMove3()
    {
        return move3;
    }

    public string getMove4()
    {
        return move4;
    }

    public GameManager.Type getType()
    {
        return type;
    }
}
