using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StadiumChoice : MonoBehaviour
{
    public GameObject ForestPanel, NightPanel;
    public bool isStageForest, isStageNight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectStageForest()
    {
        isStageForest = true;
        isStageNight = false;
        ForestPanel.SetActive(true);
        NightPanel.SetActive(false);
    }

    public void selectStageNight()
    {
        isStageForest = false;
        isStageNight = true;
        ForestPanel.SetActive(false);
        NightPanel.SetActive(true);
    }
}
