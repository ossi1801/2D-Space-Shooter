using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBulletScript : MonoBehaviour
{
    public GameObject explosionSmall;
    public bool isBomb = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
          if (isBomb)  Instantiate(explosionSmall, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject); //destroy bullet
        }
    }

    void Update()
    {
        if (transform.position.y > 7f)
        {

            Destroy(gameObject);
        }
    }
}
