using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField]
    private float timeToLive = 1.25f;

    [SerializeField]
    private GameObject deathObject = null; // Reference assigned by Unity Editor

    // Start is called before the first frame update
    void Start()
    {
        Destroy(deathObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
