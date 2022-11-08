using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    //First angle of the square
    Vector3 squareAngel1 = new Vector3(0f, 0f, 0f);

    //Second angle of the square
    Vector3 squareAngel2 = new Vector3(0f, 7f, 0f);

    //Third angle of the square
    Vector3 squareAngel3 = new Vector3(7f, 7f, 0f);

    //Fourth angle of the square
    Vector3 squareAngel4 = new Vector3(7f, 0f, 0f);

    // list of coordinates
    public List<Vector3> angels = new List<Vector3>();

    
    private int nextPointIndex = 0;

    // speed of the object 
    public float speed = 10f;

    void Start()
    {
        // Populated the list with the four angles to make a square
        angels.Add(squareAngel1);
        angels.Add(squareAngel2);
        angels.Add(squareAngel3);
        angels.Add(squareAngel4);

    }

    
    void Update()
    {
        // created a variable and set it to the next angle  
        var next = transform.position == angels[nextPointIndex];

        // check to see the next angle
        if (next)
        {
            //increment to the next angle
            nextPointIndex++;
            if (nextPointIndex >= angels.Count)
            {
                // reset the index to avoid outofbounds exception 
                nextPointIndex = 0;
            }
        }
        //Changes the position of the sphere
        transform.position = Vector3.MoveTowards(transform.position, angels[nextPointIndex], speed * Time.deltaTime);
    }
}
