using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TMP_Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;

                float minutes = Mathf.FloorToInt(TimeLeft / 60);
                float seconds = Mathf.FloorToInt(TimeLeft % 60);

                TimerText.text = string.Format("Timer: {0:00} : {1:00}", minutes, seconds);
            }
            else if (TimeLeft < 0)
            {                
                TimerOn = false;
                SceneManager.LoadScene("Defeat");
            }
        }
    }
}
