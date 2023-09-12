using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    int minutes, seconds;
    public TimeKeeper timeKeeper;
  
    private void Update()
    {
        minutes = (int)(timeKeeper.current_time / 60);
        seconds = (int)(timeKeeper.current_time % 60);

        gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
