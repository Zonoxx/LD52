using System.Linq;
using UnityEngine;

public class RespawnHarvest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var activeWheat = GameObject.FindGameObjectsWithTag("Wheat").FirstOrDefault(wheat => wheat.activeSelf);

        if (!activeWheat || activeWheat is null)
        {
            RespawnWheat();
        }
    }

    private static void RespawnWheat()
    {
        var inactiveWheat = GameObject.FindGameObjectsWithTag("Wheat");
        foreach (var wheat in inactiveWheat)
        {
            wheat.SetActive(true);
        }
    }
}
