using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsScript : MonoBehaviour
{
    public GameObject keys;
    public GameObject play;
    public GameObject options;
    public GameObject back;
    public GameObject quit;
    // Start is called before the first frame update
    void Start()
    {
        keys.SetActive(false);
        back.SetActive(false);
        play.SetActive(true);
        options.SetActive(true);
        quit.SetActive(true);
    }
    public void buttonOptions() 
    {
        keys.SetActive(true);
        back.SetActive(true);
        play.SetActive(false);
        options.SetActive(false);
        quit.SetActive(false);
    }

    public void buttonBack()
    {
        keys.SetActive(false);
        back.SetActive(false);
        play.SetActive(true);
        options.SetActive(true);
        quit.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
