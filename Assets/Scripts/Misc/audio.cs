using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    [Header("Sfx")]
    public AudioSource Shoot;
    public AudioSource pShoot;
    public AudioSource enemyExplosion;
    public AudioSource enemySpecial;
    public AudioSource enemyDeath;

    [Header ("Music")]
    public AudioSource bossMusic;
    public AudioSource music; 
    public AudioSource victoryMusic;
    // Start is called before the first frame update
    void Start()
    {
        music.Play();
    }

    public void playAudio (string name)
    {
        switch (name)
        {
            default: Debug.LogError(name + "  audio not found, are you sure you have typed it correctly..."); break;
            case "Shoot":
                Shoot.Play();
                break;

            case "pShoot":
                pShoot.Play();
                break;

            case "enemyExplosion":
                enemyExplosion.Play();
                break;

            case "enemySpecial":
                enemySpecial.Play();
                break;
            case "alienDesDeath":
                enemyDeath.Play();
                break;
            case "bossMusic":
                music.Stop();
                bossMusic.Play();
                break;

            case "victoryMusic":
                music.Stop();
                bossMusic.Stop();
                victoryMusic.Play();
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
