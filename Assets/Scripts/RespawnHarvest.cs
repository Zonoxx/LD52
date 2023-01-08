using System.Collections;
using System.Linq;
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

    private float timer = 2f;
    private void Start()
    {
        respawnHasHappened = false;
    }

    private void Update()
    {

        if (!respawnHasHappened)
        {
            var activeWheat = GameObject.FindGameObjectsWithTag("Wheat");
            if (activeWheat.Count() == 0)
            {
                RespawnWheat();
                EnableHarvestTimeTexts();
                respawnHasHappened = true;
            }

        }
        else if (respawnHasHappened)
        {
            var inactiveWheat = GameObject.FindGameObjectsWithTag("Inactive");

            if (inactiveWheat.Count() == 0)
            {
                Debug.Log("Resetting");
                ResetRespawn();
                HarvestTime();
                DisableHarvestTimeTexts();
            }
        }
    }

    private void RespawnWheat()
    {
        var inactiveWheat = GameObject.FindGameObjectsWithTag("Inactive");
        foreach (var wheat in inactiveWheat)
        {
            wheat.GetComponent<SpriteRenderer>().enabled = true;
            wheat.GetComponent<BoxCollider2D>().enabled = true;
            wheat.tag = "Wheat";
        }
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
