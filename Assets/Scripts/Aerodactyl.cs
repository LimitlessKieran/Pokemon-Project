using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerodactyl : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;

    public string move1 = "";
    public string move2 = "";
    public string move3 = "";
    public string move4 = "";

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
}
