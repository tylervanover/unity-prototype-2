using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenDespawn : MonoBehaviour
{
    [SerializeField]
    private GameObject deathObject;

    [System.Serializable]
    public struct BoundsPlane 
    {
        public bool X;
        public bool Y;
        public bool Z;
        public float lowerLimit;
        public float upperLimit;
    }

    [SerializeField]
    private BoundsPlane bounds;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsOutOfBounds(transform))
        {
            Destroy(deathObject);
        }
    }

    private bool IsOutOfBounds(Transform t) 
    {
        return (bounds.X && NotWithin(t.position.x, bounds.lowerLimit, bounds.upperLimit))
            || (bounds.Y && NotWithin(t.position.y, bounds.lowerLimit, bounds.upperLimit))
            || (bounds.Z && NotWithin(t.position.z, bounds.lowerLimit, bounds.upperLimit));
    }

    private bool NotWithin(float f, float lower, float upper)
    {
        return (f < lower || f > upper);
    }
}
