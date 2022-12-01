using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafStorm : MonoBehaviour
{
    int uses = 2;
    int power = 120;
    int accuracy = 85;
    GameManager.Type type = GameManager.Type.GRASS;

    public string display()
    {
        return " Leaf Storm \n" +
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

    public void setUses(int n)
    {
        uses = n;
    }

    public GameManager.Type getType()
    {
        return type;
    }
}
