using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody2D rb;
    [SerializeField]
    private float bulletSpeed = 10f;
    // Start is called before the first frame update

    private float timeAlive = 0f;
    private float timeToLive = 3f;
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        Vector3 rotation = transform.position - mousePosition;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        // float bulletRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0, 0, bulletRotation + 90);
    }

    // Update is called once per frame
    void Update()
    {
        DeleteBullet();
    }

    private void DeleteBullet()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive >= timeToLive)
        {
            Destroy(gameObject);
        }
    }
}
