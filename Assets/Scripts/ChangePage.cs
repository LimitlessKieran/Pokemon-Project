using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePage : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;

    void Start()
    {
        page2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ChangeScreen()
    {
        if (page1.activeSelf)
        {
            page2.SetActive(true);
            page1.SetActive(false);
        }
        else
        {
            page2.SetActive(false);
            page1.SetActive(true);
        }

        print("IIII");
        print("");
    }
    public void ChangeScene()
    {
        GameObject manager = GameObject.Find("GameManager");

        manager.GetComponent<GameManager>().LoadScene("MainScene");
    }
}
