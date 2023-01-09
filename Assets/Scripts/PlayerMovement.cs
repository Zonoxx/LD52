using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    private Animator animator;

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        SetSpriteDirection(moveHorizontal);
        SetAnimation(moveHorizontal, moveVertical);
        Move(moveHorizontal, moveVertical);
    }

    private void SetSpriteDirection(float moveHorizontal)
    {
        if (moveHorizontal < 0)
        {
            playerSpriteRenderer.flipX = false;
        }
        else if (moveHorizontal > 0)
        {
            playerSpriteRenderer.flipX = true;
        }
    }

    private void SetAnimation(float moveHorizontal, float moveVertical)
    {
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Move(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.position += movement * speed * Time.deltaTime;
    }



    // if (Input.GetKeyDown(KeyCode.R))
    // {
    //     var allWheats = GameObject.FindGameObjectsWithTag("Wheat");
    //     foreach (var wheat in allWheats)
    //     {
    //         wheat.GetComponent<SpriteRenderer>().enabled = false;
    //         wheat.GetComponent<BoxCollider2D>().enabled = false;
    //         wheat.tag = "Inactive";
    //     }
    // }
}
