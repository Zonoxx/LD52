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
    private bool resetInProgress;
    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        resetInProgress = false;
        DisableHarvestTimeTexts();

    }

    private void Update()
    {
        var activeWheat = GameObject.FindGameObjectsWithTag("Wheat");

        if (activeWheat.Length == 0 && !resetInProgress)
        {
            resetInProgress = true;
            EnableHarvestTimeTexts();
            StartCoroutine(HarvestTime());
            StartCoroutine(ResetAndHarvestTime());
            StartCoroutine(RespawnWheat());
        }
    }

    IEnumerator ResetAndHarvestTime()
    {
        yield return new WaitForSeconds(4);
        DisableHarvestTimeTexts();
    }

    private IEnumerator RespawnWheat()
    {
        var inactiveWheat = GameObject.FindGameObjectsWithTag("Inactive");
        yield return new WaitForSeconds(3);
        foreach (var wheat in inactiveWheat)
        {
            wheat.GetComponent<SpriteRenderer>().enabled = true;
            wheat.GetComponent<BoxCollider2D>().enabled = true;
            wheat.tag = "Wheat";
        }
        resetInProgress = false;
    }

    private IEnumerator HarvestTime()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Harvest Time!");
        IncreaseEnemySpawns();
        DoublePlayerFireRate();
        DoubleHarvestYield();
        IncreasePlayerMovementSpeed();
    }

    private void DoubleHarvestYield()
    {
        HarvestScore harvestScore = gameObject.GetComponent<HarvestScore>();
        harvestScore.ScorePerWheat = harvestScore.ScorePerWheat * 2;
    }

    private void EnableHarvestTimeTexts()
    {
        audioSource.Play();
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

    private void IncreaseEnemySpawns()
    {
        EnemySpawnController spawnController = this.spawnController.GetComponent<EnemySpawnController>();
        spawnController.AddAllBirdSpawnersOnce();
        spawnController.AddAllBirdSpawnersOnce();
    }

    private void IncreasePlayerMovementSpeed()
    {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerMovement.speed *= 1.5f;
    }
}
