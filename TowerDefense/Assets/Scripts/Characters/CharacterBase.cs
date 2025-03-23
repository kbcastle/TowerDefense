using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public string characterName;
    public int health;
    public TextMeshProUGUI displayHealth;

    private void Update()
    {
        DisplayHealth();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DisplayHealth()
    {
        displayHealth.text = "Health: " + health;
    }

}


