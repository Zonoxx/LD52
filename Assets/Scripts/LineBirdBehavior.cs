using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBirdBehavior : EnemyBehavior
{

    private Vector3 targetDirection;

    private float movementSpeed = 5f;

    protected override void Start()
    {
        base.Start();


        Vector3 target;

        // x < -18 -> links, y > 19 -> oben  x > 38 -> rechts, y > -21 -> unten
        Vector3 myPosition = transform.position;
        if (myPosition.x < -18f)
        {
            target = new Vector3(200f, myPosition.y, 0f);
        }
        else if (myPosition.x > 38f)
        {
            target = new Vector3(-200f, myPosition.y, 0f);
        }
        else if (myPosition.y > 19f)
        {
            target = new Vector3(myPosition.x, -200f, 0f);
        }
        else
        {
            target = new Vector3(myPosition.x, 200f, 0f);
        }
        targetDirection = target - transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetDirection, movementSpeed * Time.deltaTime);
    }
}
