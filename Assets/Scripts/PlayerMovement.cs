using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    private Animator animator;

    private void Update()
    {
        CheckForPlayerInput();
        CheckForIdle();
    }

    private void CheckForIdle()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void CheckForPlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (playerSpriteRenderer.flipX)
            {

                playerSpriteRenderer.flipX = false;
            }
            animator.SetBool("isMoving", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (!playerSpriteRenderer.flipX)
            {
                playerSpriteRenderer.flipX = true;
            }
            animator.SetBool("isMoving", true);
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
}
