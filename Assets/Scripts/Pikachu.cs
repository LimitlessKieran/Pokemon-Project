using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikachu : MonoBehaviour
{
    int health;
    int attack;
    int defense;

    string move1 = "Thunderbolt";
    string move2 = "IronTail";
    string move3 = "QuickAttack";
    string move4 = "Thunder";

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
}
