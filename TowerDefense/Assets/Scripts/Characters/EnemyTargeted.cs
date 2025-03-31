using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeted : Enemy
{
    // Start is called before the first frame update
    public GameObject targetTower;

    void Start()
    {
        targetTower = GameObject.FindWithTag("Tower");
        speed = Random.Range(xSpeed, ySpeed);  //randomize spawn speed
    }

    // Update is called once per frame
    void Update()
    {
        manager = FindObjectOfType<GameManager>();
        thisObject.transform.position += VectorToTower() * speed;
        DisplayHealth();
        if (health <= 0)
        {
            manager.money = manager.money + moneyValue;
            Destroy(gameObject);
        }
    }

    Vector3 VectorToTower() //function to get the direction to the tower from the current enemy
    {
        Vector3 targetDir;
        targetDir = targetTower.transform.position - transform.position; //subtracting the position of the enemy from the posititon of the tower to get the vector for the direction between them

        targetDir = targetDir.normalized; //normalize sets vector magnitude to 1 to clean it up
        return targetDir;//return the direction vector
    }
}
