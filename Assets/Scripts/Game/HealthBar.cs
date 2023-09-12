using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        float max_health = player.GetComponent<Player>().max_food;
        float current_health = player.GetComponent<Player>().current_food;
        GetComponent<Image>().fillAmount = current_health / max_health;
    }
}
