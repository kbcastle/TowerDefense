using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterBase
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collided with enemy");
            health = health - 1;
        }
    }
}

