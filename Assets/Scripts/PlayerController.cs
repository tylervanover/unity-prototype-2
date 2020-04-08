using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float horizontalInput;

    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private GameObject projectilePrefab;  // Reference assigned by Unity Editor;

    [SerializeField]
    private float xBounds = 10.0f;

    [SerializeField]
    private float shotDelay = 0.1f;

    [SerializeField]
    private Vector3 firingOffset = new Vector3 (0, 1.75f, 0.5f);

    private float lastShot = 0.0f;
    private bool burstMode = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Handle bounds checking
        if (System.Math.Abs(transform.position.x) > xBounds) 
        {
            transform.position = new Vector3 (
                System.Math.Sign(transform.position.x) * xBounds
                , transform.position.y
                , transform.position.z
            );
        }
        
        // Update position
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);

        // Detect Trigger
        burstMode = Input.GetAxis("RT") < 0 
                    || Input.GetKey(KeyCode.LeftShift) 
                    || Input.GetKey(KeyCode.RightShift);

        lastShot += Time.deltaTime;
        if ((Input.GetButtonDown("Shoot")) || 
            (Input.GetButton("Shoot") && lastShot > shotDelay && burstMode)) 
        {
            // Fire a shot!
            Instantiate(projectilePrefab, transform.position + firingOffset, projectilePrefab.transform.rotation);
            lastShot = 0.0f;
        }
    }
}
