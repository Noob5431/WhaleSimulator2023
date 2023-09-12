using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        float max_health = player.GetComponent<Player>().max_oxygen;
        float current_health = player.GetComponent<Player>().current_oxygen;
        GetComponent<Image>().fillAmount = current_health / max_health;
    }
}
