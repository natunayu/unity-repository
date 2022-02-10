using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    public Rigidbody rb;
    private PlayerTransform characterController;
    private Vector3 velocity;

    void Start() 
    {
        characterController = GetComponent<PlayerTransform>();
    }

    public Vector2 GetVelocityXZ(){
        return new Vector2(characterController.velocity.x, characterController.velocity.z);
    }

    public float GetVelocityY(){
        return characterController.velocity.y;
    }

    public Transform GetTransform(){
        return transform;
    }
}
