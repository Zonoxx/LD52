using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBirdBehavior : EnemyBehavior
{
    private float homingBirdMovementSpeed = 4f;
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, homingBirdMovementSpeed * Time.deltaTime);
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
