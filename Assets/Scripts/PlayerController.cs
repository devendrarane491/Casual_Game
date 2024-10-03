using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int roadWidth;
    [Header("Manage Controls")]
    [SerializeField] private float sideSpeed; 

    void Update()
    {
        MoveForward();
        ManageControl();
    }

    private void MoveForward()
    {
        // Move forward continuously
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageControl()
    {
        float horizontalInput = 0;

        // Check for key inputs (A and D)
        if (Input.GetKey(KeyCode.A)) // Move left
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyCode.D)) // Move right
        {
            horizontalInput = 1;
        }

        // Update the player's position based on key input
        Vector3 position = transform.position;
        position.x += horizontalInput * sideSpeed * Time.deltaTime;

        // Clamp the player's position within the road width
        position.x = Mathf.Clamp(position.x, -roadWidth / 2, roadWidth / 2);
        transform.position = position;
    }
}
