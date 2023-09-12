using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed,rotation_speed;

    private void FixedUpdate()
    {
        //movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 input_direction = new Vector2(x, y);
        input_direction.Normalize();

        gameObject.GetComponent<CharacterController>().Move(input_direction * speed * Time.deltaTime);

        //sprite rotation
        if (input_direction != Vector2.zero)
        {
            GetComponentInChildren<Animator>().SetFloat("SwimSpeed",2);

            Quaternion new_rotation = Quaternion.LookRotation(Vector3.forward, input_direction);
            gameObject.GetComponent<Transform>().rotation = Quaternion.Slerp(gameObject.GetComponent<Transform>().rotation, 
                                                                               new_rotation, rotation_speed * Time.deltaTime);
            if (x < 0)
                GetComponentInChildren<SpriteRenderer>().flipY = true;
            else GetComponentInChildren<SpriteRenderer>().flipY = false;
        }
        else
        {
            GetComponentInChildren<Animator>().SetFloat("SwimSpeed", 0.5f);
        }
    }

}
