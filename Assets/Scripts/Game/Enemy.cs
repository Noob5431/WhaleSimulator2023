using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed,food_value,detection_range;
    Vector3 last_direction;
    [SerializeField]
    float rotation_speed;
    [SerializeField]
    GameObject blood, text,timeKeeper;

    private void OnEnable()
    {
        timeKeeper = GameObject.Find("TimeKeeper");
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed * Time.deltaTime, 0, 0);

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
        if(other.CompareTag("Nose"))
        {
            other.gameObject.GetComponentInParent<Player>().AddFood(food_value);
            StartCoroutine(DeathAnimation());
        }
        if(other.CompareTag("WorldLimit"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detection_range);
    }
    
    IEnumerator DeathAnimation()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        blood.GetComponent<ParticleSystem>().Play();
        GameObject new_text = Instantiate(text,transform.position,timeKeeper.transform.rotation);
        yield return new WaitForSeconds(1);
        Destroy(new_text);
        Destroy(gameObject);
    }
}
