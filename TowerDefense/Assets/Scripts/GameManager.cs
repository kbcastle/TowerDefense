using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money = 500;
    public int bombCost = 20;

    public float enemyTimer = 0f;
    public float spawnInterval = 1f;

    public float enemyTimer2 = 0f;
    public float spawnInterval2 = 3f;

    public Vector2 xBounds;
    public Vector2 yBounds;

    public GameObject bomb;
    public GameObject enemy;
    public GameObject enemyTargeted;

    public TextMeshProUGUI moneyDisplay;

    public GameObject tower;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer += Time.deltaTime;
        enemyTimer2 += Time.deltaTime;

        Vector3 targetPos = new Vector3(Random.Range(xBounds.x, xBounds.y), Random.Range(yBounds.x, yBounds.y), 0);
        if (money > 50 && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomb, targetPos, Quaternion.identity);
            money = money - bombCost;
        }

        if (enemyTimer > spawnInterval)
        {
            enemyTimer = 0f;
            Instantiate(enemy, targetPos, Quaternion.identity);
        }

        if (enemyTimer2 > spawnInterval2)
        {
            enemyTimer2 = 0f;
            Instantiate(enemyTargeted, targetPos, Quaternion.identity);
        }

        moneyDisplay.text = "Money: " + money;

        tower = GameObject.FindWithTag("Tower");
        if (tower == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
