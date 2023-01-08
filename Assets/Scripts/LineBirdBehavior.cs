using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBirdBehavior : EnemyBehavior
{

    protected override void Start()
    {
        base.Start();

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMovementSpeed * Time.deltaTime);
        if (player.transform.position.x < transform.position.x)
        {
            if (!isFlipped)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                isFlipped = true;
            }
        }
        else
        {
            if (isFlipped)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                isFlipped = false;
            }
        }
    }
}
