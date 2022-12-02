using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
