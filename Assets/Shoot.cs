using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 1000f;


    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerShootsAndShoot();
    }

    private void CheckIfPlayerShootsAndShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootOnion();
        }
    }

    private void ShootOnion()
    {
        bulletPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        Rigidbody2D rb = bulletPrefab.GetComponent<Rigidbody2D>();

        Vector3 shootDirection = GetShootDirection();
        rb.velocity = new Vector2(shootDirection.x * bulletSpeed, shootDirection.y * bulletSpeed);

    }

    private Vector3 GetShootDirection()
    {
        Vector3 shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        return shootDirection;
    }
}
