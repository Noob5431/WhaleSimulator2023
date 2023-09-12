using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float speed_multiplier = 1,spawn_distance,min_distance;
    public float interval;
    public float spawn_distance_increase;
    public GameObject[] prefabPool;
    float current_time;
    SpawnDifficulty spawnDifficulty;
    [SerializeField]
    bool isShark;
    GameObject enemy;

    private void Start()
    {
        spawnDifficulty = GetComponentInParent<SpawnDifficulty>();
        current_time = 0;
    }

    private void FixedUpdate()
    {
        float current_distance = 0;

        current_time -= Time.deltaTime;
        if(enemy)
            current_distance = (transform.position - enemy.transform.position).magnitude;

        if((current_distance > spawn_distance && current_time < 0)|| !enemy)
        {
            current_time = interval;
            int index = Random.Range(0, prefabPool.Length);
            enemy = Instantiate(prefabPool[index], transform.position, transform.rotation);
            if (enemy.GetComponent<Enemy>())
                enemy.GetComponent<Enemy>().speed *= speed_multiplier;
            else if (enemy.GetComponent<SharkAttack>())
                enemy.GetComponent<SharkAttack>().speed *= speed_multiplier;
        }
        if(spawn_distance > min_distance)
        {
            spawn_distance -= spawn_distance_increase*Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawn_distance);
    }
}
