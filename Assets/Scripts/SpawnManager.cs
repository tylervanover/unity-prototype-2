using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnEntities;

    private int spawnEntityIndex;
    private float spawnOffsetX = 0.0f;
    private float spawnOffsetZ = 20.0f;
    private float spawnTimerBase = 2.0f;
    private float spawnTimerDelay = 0.0f;

    private bool isSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        // Not using InvokeRepeating as Reflection penalties
        // Not using Update because this happens every frame
        // Coroutine gives us the best of both worlds without those penalities
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        while (isSpawning)
        {
            spawnEntityIndex = Random.Range(0, spawnEntities.Length);
            spawnOffsetX = (Random.Range(-20, 20) / 2.0f);
            spawnTimerDelay = (Random.Range(-1.25f, 1.25f) + spawnTimerBase);
            GameObject obj = spawnEntities[spawnEntityIndex];
            Instantiate (obj, new Vector3(spawnOffsetX, 0, spawnOffsetZ), obj.transform.rotation);
            yield return new WaitForSeconds(spawnTimerDelay);
        }
    }

    void ToggleSpawn()
    {
        isSpawning = !isSpawning;
    }

    void StopSpawn() 
    {
        isSpawning = false;
    }
}
