using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int cameraDistance = -30;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cameraDistance);
    }
}
