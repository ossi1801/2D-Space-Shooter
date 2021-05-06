using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	private bool rdyToShoot = true;
	public float specialTimer = 3f;
	public static float hp = 30f;
	public static Vector2 pos;
	public GameObject specialAttack;
	// Start is called before the first frame update
	void Start()
	{
		FindObjectOfType<audio>().playAudio("bossMusic");
		hp = 30f;
	}

	// Update is called once per frame
	void Update()
	{
		pos = gameObject.transform.position;
		if (rdyToShoot) StartCoroutine(shootTimer());

	}
	IEnumerator shootTimer()
	{
		rdyToShoot = false;
		yield return new WaitForSecondsRealtime(specialTimer);
		Instantiate(specialAttack, transform.position, Quaternion.identity);
		FindObjectOfType<audio>().playAudio("enemySpecial");
		rdyToShoot = true;
	} 
}
