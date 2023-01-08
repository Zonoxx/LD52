using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSpriteController : MonoBehaviour
{

    private Sprite[] wheatSprites;

    void Start()
    {
        this.wheatSprites = Resources.LoadAll<Sprite>("WheatVariants");
        int idx = UnityEngine.Random.Range(0, this.wheatSprites.Length);
        GetComponent<SpriteRenderer>().sprite = this.wheatSprites[idx];
    }
}
