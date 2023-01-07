using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHierarchySorter : MonoBehaviour
{


    private SpriteRenderer[] childRenderers;

    private void Awake()
    {
        childRenderers = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < childRenderers.Length; i++)
        {
            childRenderers[i].sortingOrder = Mathf.RoundToInt(-childRenderers[i].transform.position.y);
        }
    }
}
