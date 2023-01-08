using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        CheckForPlayerInput();
    }

    private void CheckForPlayerInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (playerSpriteRenderer.flipX)
            {

                playerSpriteRenderer.flipX = false;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (!playerSpriteRenderer.flipX)
            {

                playerSpriteRenderer.flipX = true;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            var allWheats = GameObject.FindGameObjectsWithTag("Wheat");
            foreach (var wheat in allWheats)
            {
                wheat.GetComponent<SpriteRenderer>().enabled = false;
                wheat.GetComponent<BoxCollider2D>().enabled = false;
                wheat.tag = "Inactive";
            }
        }
    }
}
