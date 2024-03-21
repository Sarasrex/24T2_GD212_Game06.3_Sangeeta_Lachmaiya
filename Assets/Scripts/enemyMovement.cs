using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meepleMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        // Ensure the direction is not zero
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // enemy rotation to face player
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, speed * Time.deltaTime);
        }

        // Move towards the player's position
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}