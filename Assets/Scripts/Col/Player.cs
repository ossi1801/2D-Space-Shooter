using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    public static float damage = 0.05f;
    public static float damageBomb = 1.5f;
    //	public GameObject playerSpriteRenderer;
    public GameObject playerBulletPrefab;
    public GameObject playerBombPrefab;
    //	public GameObject explosion;


    public int hp = 20;
    public static int bombAmount = 5;
    public static int pointAmount = 0;
    public static int playerHP = 20;
    private bool rdyToBomb = true;
    private Rigidbody2D rb;


    void Start()
    {
        pointAmount = 0;
        playerHP = hp;
        bombAmount = 5;
        rb = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {


        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        float y = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;
        Vector2 newPosition2 = rb.position + Vector2.up * y;

        newPosition.x = Mathf.Clamp(newPosition.x, -Map.Width, Map.Width);
        newPosition.y = Mathf.Clamp(newPosition2.y, -Map.Height, Map.Height); // limits area

        rb.MovePosition(newPosition);

        if (Input.GetButton("Fire1"))
        {
            Instantiate(playerBulletPrefab, transform.position + new Vector3(0f, 1f), Quaternion.identity);
            FindObjectOfType<audio>().playAudio("pShoot");
        }

        if (Input.GetButton("Fire2") && bombAmount > 0)
        {
            if (rdyToBomb) StartCoroutine(bombTimer());

        }

        if (playerHP <= 0) FindObjectOfType<GameManager>().EndGame();
    }

    IEnumerator bombTimer()
    {
        bombAmount--;
        FindObjectOfType<audio>().playAudio("pShoot");
        Instantiate(playerBombPrefab, transform.position + new Vector3(0f, 1f), Quaternion.identity);
        rdyToBomb = false;
        yield return new WaitForSecondsRealtime(0.5f); //  a small delay between bombs so you dont accidentaly spam them
        rdyToBomb = true;
    }

    void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
