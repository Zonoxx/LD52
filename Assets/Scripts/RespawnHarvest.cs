using System.Collections;
using TMPro;
using UnityEngine;

public class RespawnHarvest : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnController;
    [SerializeField]
    private TextMeshProUGUI harvestTimeText;
    [SerializeField]
    private TextMeshProUGUI everythingDoubledText;
    private bool respawnHasHappened;

    private void Start()
    {
        respawnHasHappened = false;
        DisableHarvestTimeTexts();

    }

    private void Update()
    {
        var activeWheat = GameObject.FindGameObjectsWithTag("Wheat");


        if (activeWheat.Length == 0 && !respawnHasHappened)
        {
            StartCoroutine(RespawnWheat());
            EnableHarvestTimeTexts();
        }


        if (respawnHasHappened)
        {
            Debug.Log("Resetting");
            ResetRespawn();
            HarvestTime();
            StartCoroutine(DelayedDisableHarvestTimeTexts());
        }
    }


    private IEnumerator RespawnWheat()
    {
        var inactiveWheat = GameObject.FindGameObjectsWithTag("Inactive");
        foreach (var wheat in inactiveWheat)
        {
            wheat.GetComponent<SpriteRenderer>().enabled = true;
            wheat.GetComponent<BoxCollider2D>().enabled = true;
            wheat.tag = "Wheat";
        }
        respawnHasHappened = true;
        yield return null;
    }

    private void HarvestTime()
    {
        Debug.Log("Harvest Time!");
        DoubleEnemySpawnRate();
        DoublePlayerFireRate();
        DoubleHarvestYield();
    }

    private void DoubleHarvestYield()
    {
        HarvestScore harvestScore = gameObject.GetComponent<HarvestScore>();
        harvestScore.ScorePerWheat = harvestScore.ScorePerWheat * 2;
    }

    private void EnableHarvestTimeTexts()
    {
        harvestTimeText.enabled = true;
        everythingDoubledText.enabled = true;
    }

    private IEnumerator DelayedDisableHarvestTimeTexts()
    {
        yield return new WaitForSeconds(3);
        DisableHarvestTimeTexts();
    }

    private void DisableHarvestTimeTexts()
    {
        harvestTimeText.enabled = false;
        everythingDoubledText.enabled = false;
    }


    private void DoublePlayerFireRate()
    {
        Shooting shooting = gameObject.GetComponentInChildren<Shooting>();
        shooting.timeBetweenShots *= 0.5f;
    }

    private void DoubleEnemySpawnRate()
    {
        EnemySpawnController spawnController = this.spawnController.GetComponent<EnemySpawnController>();
        spawnController.currentSpawnRate = 2f;
        spawnController.timeUntilSpawnRateIncrease *= 0.5f;
    }

    private void ResetRespawn()
    {
        respawnHasHappened = false;
    }
}
