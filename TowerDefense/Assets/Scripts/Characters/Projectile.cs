using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Tower
{
    public float speed = 1f;
    public GameManager manager;
    public GameObject thisObject;
    public Vector3 dir;
    public float lifeTime;
    public float endTime = 3f;

    public void Start()
    {
        targetEnemy = GameObject.FindWithTag("Enemy");
        dir = VectorToEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        manager = FindObjectOfType<GameManager>();
        thisObject.transform.position += dir * speed;
        targetEnemy = GameObject.FindWithTag("Enemy");
        lifeTime += Time.deltaTime;
        if (lifeTime >= endTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            targetEnemy = null;
        }
    }

    Vector3 VectorToEnemy() //function to get the direction to the tower from the current enemy
    {
        Vector3 targetDir;
        targetDir = targetEnemy.transform.position - transform.position; //subtracting the position of the enemy from the posititon of the tower to get the vector for the direction between them

        targetDir = targetDir.normalized; //normalize sets vector magnitude to 1 to clean it up
        return targetDir;//return the direction vector
    }
}
