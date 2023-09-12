using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public float current_time;

    private void Start()
    {
        current_time = 0;
    }

    void Update()
    {
        current_time += Time.deltaTime;
    }

}
