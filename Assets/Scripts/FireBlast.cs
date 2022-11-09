using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
    int uses = 2;
    int power = 120;
    int accuracy = 85;
    GameManager.Type type = GameManager.Type.FIRE;

    public string display()
    {
        return " Fire Blast\n" +
            " Uses: " + uses + "\n\n" +
            " Power: " + power + "\n" +
            " Accuracy: " + accuracy + "\n" +
            " Type: " + type;
    }

    public int getPower()
    {
        return power;
    }

    public int getAccuracy()
    {
        return accuracy;
    }

    public int getUses()
    {
        return uses;
    }

    public GameManager.Type getType()
    {
        return type;
    }
}
