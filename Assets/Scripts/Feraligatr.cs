using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feraligatr : MonoBehaviour
{
    int health;
    int attack;
    int defense;

    string move1 = "Surf";
    string move2 = "MetalClaw";
    string move3 = "IceFang";
    string move4 = "HydroPump";

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
