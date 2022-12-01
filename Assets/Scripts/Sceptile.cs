using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sceptile : MonoBehaviour
{
    int health;
    int attack;
    int defense;

    string move1 = "LeafBlade";
    string move2 = "Slash";
    string move3 = "XScissor";
    string move4 = "LeafStorm";

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
