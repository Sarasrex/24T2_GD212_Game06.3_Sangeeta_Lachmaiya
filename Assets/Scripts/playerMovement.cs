using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 1000f;
    public float jumpForce = 5f;

    private Transform playerBody;
    private Transform cameraTransform;
    private float xRotation = 0f;
    private bool isGrounded; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform;
        cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        //Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 move = new Vector3 (moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        playerBody.Translate(move);

        // Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Check if the player is grounded
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.7f)
            {
                isGrounded = true;
            }
        }
    }



}