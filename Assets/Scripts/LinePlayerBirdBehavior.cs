using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePlayerBirdBehavior : EnemyBehavior
{
    private Vector3 playerDirectionOnStart;

    public float movementSpeed = 5f;

    protected override void Start()
    {
        base.Start();
        playerDirectionOnStart = player.transform.position - transform.position;
        playerDirectionOnStart *= 100;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerDirectionOnStart, movementSpeed * Time.deltaTime);
    }
}
