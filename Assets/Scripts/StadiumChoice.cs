using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadiumChoice : MonoBehaviour
{
    public GameObject ForestPanel, NightPanel;
    public GameObject manager;
    public static StadiumChoice gameManagerInstance;

    void Start()
    {
       manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void selectStageForest()
    {
      
        ForestPanel.SetActive(true);
        NightPanel.SetActive(false);
        manager.GetComponent<GameManager>().selectStageForest();
    }

    public void selectStageNight()
    {
      
        ForestPanel.SetActive(false);
        NightPanel.SetActive(true);
        manager.GetComponent<GameManager>().selectStageNight();
    }
}
