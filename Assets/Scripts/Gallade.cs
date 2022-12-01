using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallade : MonoBehaviour
{
    int health;
    int attack;
    int defense;

    string move1 = "BrickBreak";
    string move2 = "RockSmash";
    string move3 = "FalseSwipe";
    string move4 = "CloseCombat";

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
