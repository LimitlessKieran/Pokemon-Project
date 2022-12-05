using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// purpose of this script is to kill objects when they are not needed
public class DestroyTheme : MonoBehaviour
{
    public string objectName;
    void Start()
    {
        Destroy(GameObject.Find(objectName));
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
