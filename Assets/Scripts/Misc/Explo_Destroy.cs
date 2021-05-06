using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explo_Destroy : MonoBehaviour
{
    public float timer = 3f;
    private void FixedUpdate()
    {
        Destroy(gameObject, timer);
    }
}
