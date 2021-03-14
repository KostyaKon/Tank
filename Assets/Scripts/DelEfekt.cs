using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelEfekt : MonoBehaviour
{
    public float timeLife = 5f; 
    void Start()
    {
        Destroy(gameObject, timeLife);
    }
}
