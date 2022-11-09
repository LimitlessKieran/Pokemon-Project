using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    int uses = 3;
    int power = 90;
    int accuracy = 100;
    GameManager.Type type = GameManager.Type.FIRE;

    public string display()
    {
        return " Flamethrower \n" +
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
