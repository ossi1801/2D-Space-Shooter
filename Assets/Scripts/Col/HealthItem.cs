using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int hpBoost = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Player.playerHP<=20) Player.playerHP += hpBoost;
            Debug.Log("Hit player, hp: " + Player.playerHP);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
