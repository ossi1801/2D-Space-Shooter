using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiScript : MonoBehaviour
{
    // public static int UIplayerHP;
  
    public GameObject uiHP;
    public GameObject bombText;
    public GameObject pointText;
    public GameObject winText;
    public GameObject winBackground;
    public GameObject lostText;


    public Slider slider;
    public Gradient gradient;
    public Image fill;

    [Header("Boss stuff")]
    public GameObject bossUIHP;
    public Slider sliderBoss;
    public Gradient gradientBoss;
    public Image fillBoss;
    private Vector2 offset = new Vector2(700,500);

    public static bool gameIsWon = false;
    public static bool gameIsLost = false;
    public void setMaxHPslider(int amount)
    {
      
        slider.maxValue = amount;
        slider.value = amount;
        fill.color = gradient.Evaluate(1f);
    }
    public void setHpSlider(int amount)
    {
    
        slider.value = amount;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


    public void setBossFullHP(int amount)
    {

        sliderBoss.maxValue = amount;
        sliderBoss.value = amount;
        fillBoss.color = gradientBoss.Evaluate(1f);
    }
    public void setBossHP(int amount)
    {
        sliderBoss.value = amount;
        fillBoss.color = gradientBoss.Evaluate(sliderBoss.normalizedValue);
    }


    void Start()
    {
        
        setMaxHPslider(Player.playerHP);
        setBossFullHP(Convert.ToInt32(Boss.hp));
        bossUIHP.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        gameIsWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        winText.gameObject.SetActive(gameIsWon); // shows if won game
        winBackground.gameObject.SetActive(gameIsWon); // shows if won game
        lostText.gameObject.SetActive(gameIsLost);
        uiHP.GetComponent<Text>().text = Player.playerHP.ToString();
      //  bossUIHP.GetComponent<Text>().text = Boss.hp.ToString();
        bombText.GetComponent<Text>().text = Player.bombAmount.ToString();
        pointText.GetComponent<Text>().text = Player.pointAmount.ToString();


        setHpSlider(Player.playerHP);

        if (EnemySpawner.bossIsSpawned)
        {
            Debug.Log(Boss.hp);
            bossUIHP.gameObject.SetActive(true);
          //  bossUIHP.gameObject.transform.position =Boss.pos*60+offset;
   
            setBossHP(Convert.ToInt32(Boss.hp));
            // TODO DO THIS SHIT IN TO ANOTHER SCRIPT OR SMOTHETHING!
        }
    }
}
