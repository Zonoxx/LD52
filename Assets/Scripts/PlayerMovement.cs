using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    void Update()
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
    }
}
