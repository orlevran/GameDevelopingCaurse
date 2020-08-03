using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraBehaviourScript : MonoBehaviour
{
    private float moveSpeed;
    private float angularSpeed;
    private float rotationAngle;
    private CharacterController characterController;
    void Start()
    {
        this.moveSpeed = 10.0f;
        this.angularSpeed = 1.0f;
        this.rotationAngle = 0f;
        this.characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        

        if (Input.GetKey(KeyCode.W))
            moveSpeed += 0.05f;
        else if (Input.GetKey(KeyCode.S))
            moveSpeed -= 0.05f;
     
        float mouse_x = Input.GetAxis("Mouse X");
        rotationAngle += mouse_x * angularSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, rotationAngle, 0));
        
        Vector3 direction = transform.TransformDirection(Vector3.forward * Time.deltaTime * moveSpeed);
        this.characterController.Move(direction);
    }
}