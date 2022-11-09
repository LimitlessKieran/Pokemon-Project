using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charizard : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;

    public static string move1 = "Flamethrower";
    string move2 = "Wing Attack";
    string move3 = "Bite";
    string move4 = "Fire Blast";

    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        attack = 100;
        defense = 100;
    }

    // Update is called once per frame
    void Update()
    {

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
