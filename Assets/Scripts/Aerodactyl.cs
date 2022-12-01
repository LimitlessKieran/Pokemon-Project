using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerodactyl : MonoBehaviour
{
    int health;
    int attack;
    int defense;

    string move1 = "AerialAce";
    string move2 = "Pursuit";
    string move3 = "RockTomb";
    string move4 = "SkyDrop";

    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        attack = 100;
        defense = 175;
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
}
