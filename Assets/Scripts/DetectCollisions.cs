using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField]
    private GameObject colliderGameObject = null; // Reference assigned by Unity Editor

    private void OnTriggerEnter(Collider other) {
        Destroy(colliderGameObject);
        Destroy(other.gameObject);
    }
}