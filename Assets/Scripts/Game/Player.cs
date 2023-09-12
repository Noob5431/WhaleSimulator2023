using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float current_food, max_food,food_decay,current_oxygen,max_oxygen,oxygen_decay,oxygen_regen;
    public bool isAboveWater = false;
    GameMaster gameMaster;

    void Start()
    {
        current_food = max_food;
        current_oxygen = max_oxygen;
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        current_food -= food_decay * Time.deltaTime;
        if (!isAboveWater)
        {
            current_oxygen -= oxygen_decay * Time.deltaTime;
        }
        else if (current_oxygen < max_oxygen) current_oxygen += oxygen_regen * Time.deltaTime;
        if(current_food < 0 || current_oxygen < 0)
        {
            gameMaster.EndGame();
        }
    }

    public void AddFood(float amount)
    {
        GetComponent<AudioSource>().Play();
        current_food += amount;
        if (current_food > max_food)
            current_food = max_food;
    }
    
    public void AddOxygen(float amount)
    {
        current_oxygen += amount;
        if (current_oxygen > max_oxygen)
            current_oxygen = max_oxygen;
    }
}
