using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed;
    private CharacterController characterController;
    private GameObject player;
    private Vector3 playerVelocity;
    private Vector3 move;
    public float jumpHeight;
    public float gravityValue = -10;

    private void Start()
    {
        player = gameObject;
        characterController = gameObject.GetComponent<CharacterController>();
    }
    void FixedUpdate()
    {
        if (characterController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * speed * Time.deltaTime);

        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                //characterController.Move(new Vector3(0, 3f * jumpHeigth, 0));
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        print(playerVelocity.y);
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
