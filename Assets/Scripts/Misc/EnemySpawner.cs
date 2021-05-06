using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Health")]
    public GameObject healthprefab;
    public GameObject[] healthspawn;
    public float healthSpawnRate = 8.3f;

    [Header("Boss enemy")]
    public GameObject bossEnemy;
    public GameObject bossSpawn;

    [Header ("Non-boss enemys")]
    public GameObject normalEnemy;
    public GameObject normalSpawn;

    public GameObject[] spinnerEnemy;
    public GameObject spinnerSpawn;

    public int normalEnemyAmount = 2; 
    private int swndEnemyAmount;
    private bool isRdyToSpwn = true;

    public int spinnerEnemyAmount = 2;
    private bool isRdyToSpwn2 = true;
    private int swndEnemyAmount2;

    public static bool bossIsSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnHealth", 2.0f, healthSpawnRate);
    }

    public void SpawnHealth()
    {
        var nro = Random.Range(0, healthspawn.Length);
        Instantiate(healthprefab, healthspawn[nro].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.enemyKillCount >= 13 && !bossIsSpawned)
        {

            Instantiate(bossEnemy, bossSpawn.transform.position, Quaternion.identity);
            bossIsSpawned = true;

        }

        if (!bossIsSpawned|| GameManager.enemyKillCount < 12)
        {
            if (isRdyToSpwn) StartCoroutine(spawnTimer(5f));
            if (isRdyToSpwn2) StartCoroutine(spawnTimer2(7f));

        }
      
    }

    IEnumerator spawnTimer(float time)
    {

        Instantiate(normalEnemy, normalSpawn.transform.position, Quaternion.identity);
        swndEnemyAmount++;
        isRdyToSpwn = false;
        yield return new WaitForSecondsRealtime(time);
       
        if (normalEnemyAmount> swndEnemyAmount) isRdyToSpwn = true;

    }

    IEnumerator spawnTimer2(float time)
    {


        swndEnemyAmount2++;
        isRdyToSpwn2 = false;
        yield return new WaitForSecondsRealtime(time);
        //var offset = new Vector3(0, 0);
        
        foreach (var item in spinnerEnemy)
        {
            var offset = new Vector3(Random.Range(-2.0f, 2.0f),Random.Range(-2.0f, 2.0f));
            Instantiate(item, spinnerSpawn.transform.position+offset, Quaternion.identity);
         //   offset.x++;
         //   offset.y++;
        }
       
        if (spinnerEnemyAmount > swndEnemyAmount2) isRdyToSpwn2 = true;

    }
}
