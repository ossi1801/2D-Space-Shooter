using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDecendant : MonoBehaviour
{
    // Start is called before the first frame update
    public int bulletDamage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.playerHP -= bulletDamage;
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
