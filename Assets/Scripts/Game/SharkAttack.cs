using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAttack : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    public float speed, attack_speed,attack_distance;
    [SerializeField]
    bool isAttacking = false;
    [SerializeField]
    GameMaster gameMaster;

    Vector3 last_direction;
    [SerializeField]
    float rotation_speed;
 
    private void OnEnable()
    {
            gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
            player = GameObject.FindWithTag("Player");
        }
    private void FixedUpdate()
    {
        Vector3 attackVector;
        if (player)
        {
            attackVector = player.transform.position - transform.position;
            if (!isAttacking)
            {
                GetComponentInChildren<Animator>().SetFloat("SwimSpeed", 2);

                GetComponent<Rigidbody>().velocity = new Vector3(speed * Time.deltaTime, 0, 0);
                if (attackVector.magnitude < attack_distance)
                {
                    isAttacking = true;
                }
            }
            else
            {
                GetComponentInChildren<Animator>().SetFloat("SwimSpeed", 0.5f);
                if (attackVector.magnitude > attack_distance)
                {
                    isAttacking = false;
                }

                attackVector.Normalize();
                GetComponent<Rigidbody>().velocity = attackVector * attack_speed * Time.deltaTime;
            }
        }
        Vector3 movement_direction = GetComponent<Rigidbody>().velocity - last_direction;
        movement_direction.Normalize();
        last_direction = movement_direction;

        Quaternion new_rotation = Quaternion.LookRotation(Vector3.forward, movement_direction);
        gameObject.GetComponent<Transform>().rotation = Quaternion.Slerp(gameObject.GetComponent<Transform>().rotation,
                                                                           new_rotation, rotation_speed * Time.deltaTime);
        if (movement_direction.x < 0)
            GetComponentInChildren<SpriteRenderer>().flipY = true;
        else GetComponentInChildren<SpriteRenderer>().flipY = false;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameMaster.EndGame();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attack_distance);
    }
}
