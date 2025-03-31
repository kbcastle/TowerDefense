using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterBase
{
    public float bulletTimer = 0f;
    public float timerReset = 1.0f;
    public GameObject projectile;
    public GameObject targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        targetEnemy = GameObject.FindWithTag("Enemy");
    }
    public void Update()
    {
        DisplayHealth();
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= timerReset)
        {
            Instantiate(projectile);
            bulletTimer = 0f;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("collided with enemy");
            health = health - 1;
        }
    }
}

