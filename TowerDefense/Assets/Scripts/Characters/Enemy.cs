using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : CharacterBase
{
    public float speed;
    public float xSpeed;//for determining random spawn speed
    public float ySpeed;//for deter4mining random spawn speed
    public GameObject thisObject;
    public float xDir = 0f;//for determining random spawn direction
    public float yDir = 0f;// for determining random spawn direction

    public int moneyValue;

    public GameManager manager;

    public float reverseTime;
    public float reverseInterval = 3.0f;

    private void Start()
    {
        speed = Random.Range(xSpeed, ySpeed);  //randomize spawn speed
        xDir = Random.Range(-1f, 1f); //randomize spawn direction
        yDir = Random.Range(-1f, 1f);// randomize spawn direction

    }
    private void Update()
    {
        manager = FindObjectOfType<GameManager>();
        thisObject.transform.position += new Vector3(xDir, yDir, 0) * speed; //move in randomized direction
        DisplayHealth();
        reverseTime += Time.deltaTime;
        if(reverseTime > reverseInterval) //reverse direction when timer runs out
        {
            reverseTime = 0;
            xDir = xDir * -1;
            yDir = yDir * -1;
        }
        if (health <= 0) 
        {
            manager.money = manager.money + moneyValue;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bomb")
        {
            health = health - 5;
            Destroy(other.gameObject);
        }

        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }



}
