using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Transform player;
	public float enemyDeathZone = 6f;
	public GameObject bulletPrefab;
	public GameObject explosion;
	public float speed = 0.5f;

	public float hp = 6f;
	public float bulletTimer = 0.5f;
	private Rigidbody2D rb;
	private bool rdyToShoot = true;

	public bool isBoss = false;
	public bool isSpinner = false;
	public bool isAlienDes = false;

	private float sinMultiplier = 0.01f;

	private float angle = 0;
	private float radius = 3f;

	[Header ("Points")]
	public int pointsForRegularKill = 1;
	public int pointsForSpinnerKill = 3;
	public int pointsForBossKill = 16;
	public int mult = 17;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		if (isBoss) rb.velocity = new Vector2(30 * speed * Time.deltaTime, 0);
		if (!isBoss) rb.velocity = new Vector2(UnityEngine.Random.Range(-speed, speed), 0);
	}

	// Shoootings
	void Update()
	{
		if (transform.position.y < -enemyDeathZone || hp < 0)
		{	//points
			if (!isBoss && !isSpinner) Player.pointAmount += pointsForRegularKill*mult;
			else if (!isBoss && isSpinner) Player.pointAmount += pointsForSpinnerKill*mult;
			else { Player.pointAmount += pointsForBossKill * mult; }

			if(!isAlienDes)FindObjectOfType<audio>().playAudio("enemyExplosion");
			if (isAlienDes) FindObjectOfType<audio>().playAudio("alienDesDeath");
			Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
			GameManager.enemyKillCount++;
			Destroy(gameObject);
			if (isBoss) FindObjectOfType<GameManager>().gameWin();

		}


		//	timeBetweenbullets += Time.deltaTime;
		//	if (timeBetweenbullets >= 1)
		//	{}

		//shoot
		if (!isAlienDes) if (rdyToShoot)StartCoroutine(shootTimer());
		
	}
	IEnumerator shootTimer()
	{
		rdyToShoot = false;
		yield return new WaitForSecondsRealtime(bulletTimer);
		Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		FindObjectOfType<audio>().playAudio("Shoot");
		rdyToShoot = true;
	}

	public void decreaseHP(float damage)
    {
        hp -= damage;
		if(isBoss) Boss.hp -= damage;
	}





		
	void FixedUpdate()
	{

		if (!isBoss)
		{
			if (isAlienDes) { transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); }
			if (isSpinner)
            {
				float x = 0;
				float y = 0;

				Vector2 direction = Vector2.zero;

				x = radius * Mathf.Cos(angle);
				y = radius * Mathf.Sin(angle);

				rb.velocity = new Vector2(x, y);
				
				angle += 0.1f * Mathf.Rad2Deg * Time.deltaTime; //15
			}

            else { 
				float x = -1 * 5f;
				float y = 10f * Mathf.Sin(sinMultiplier * speed/50);


				if (rb.position.x > Map.Width)
				{
					rb.velocity = new Vector2(x, y);
					sinMultiplier += 0.1f;
				
				}
				else if (rb.position.x < -Map.Width)
				{
					rb.velocity = new Vector2(-x, -y);
					sinMultiplier += 0.1f;
				
				}

				/*	float x = UnityEngine.Random.Range(-1f, 1f) * Time.fixedDeltaTime * speed;
					float y = 0.005f * Time.fixedDeltaTime * speed;

					Vector2 newPosition = rb.position + Vector2.right * x;
					Vector2 newPosition2 = rb.position + Vector2.up * y;

					newPosition.x = Mathf.Clamp(newPosition.x, -Map.Width, Map.Width);
					newPosition.y = Mathf.Clamp(newPosition2.y, -Map.Height, Map.Height); // limits area
					rb.MovePosition(newPosition);
					rb.velocity = newPosition;
				*/
			}
		}
		else
		{
			
			//if (rb.position.x > Map.Width) x = -(float)Math.Cos(rb.position.x / 200) * 2;
			//else if (rb.position.x < -Map.Width) x = -(-(float)Math.Cos(rb.position.x / 200) * 2); 
			//float y = -(float)Math.Cos(rb.position.x / 200) * 2;
			//float x = 2;		

			float x = 10*speed*Time.deltaTime;
				if (rb.position.x > Map.Width)
				{
				rb.velocity = new Vector2(-x, 0);			
				}
				else if (rb.position.x < -Map.Width)
				{
				rb.velocity = new Vector2(x, 0);			
				}

		}
	}







	private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.CompareTag("playerBullet"))
        {
			decreaseHP(Player.damage);
			Debug.Log("Hit enemy");
		}

		if (collision.CompareTag("playerBomb"))
		{
			decreaseHP(Player.damageBomb);
		//	Instantiate(explosionSmall, gameObject.transform.position, Quaternion.identity);
			Debug.Log("Bomb Hit enemy");
		}
	}

}
