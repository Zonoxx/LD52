using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpriteManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float[] rotationValues = new float[] { 0.0f, 90.0f, 180.0f, 270.0f };
        int idx = UnityEngine.Random.Range(0, 4);
        GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, rotationValues[idx]);
    }
}
