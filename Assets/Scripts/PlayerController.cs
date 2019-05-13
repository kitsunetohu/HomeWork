using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Max Vertical Angle
    public float maxAngleV = 80;
    // Min Vertical Angle
    public float minAngleV = -80;
    // Rotational Speed
    public float speed;

    // Now Angle of Y Direction
    private float nowAngleV;
    // Player Position
    private Vector3 PlayerPosition;
    

    void Start() {
        // Initialize
        speed          = 50;
        nowAngleV      = 0;
        PlayerPosition = transform.position;
    }

    void Update() {
        float addRot = speed * Time.deltaTime;

        // Move Up
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            nowAngleV = Mathf.Clamp(nowAngleV - addRot, minAngleV, maxAngleV);
            if(nowAngleV > minAngleV)
                transform.RotateAround(PlayerPosition, transform.right, -addRot);
        }

        // Move Down
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            nowAngleV = Mathf.Clamp(nowAngleV + addRot, minAngleV, maxAngleV);
            if(nowAngleV < maxAngleV)
                transform.RotateAround(PlayerPosition, transform.right, addRot);
        }

        // Move Right
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.RotateAround(PlayerPosition, Vector3.up, addRot);

        // Move Left
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.RotateAround(PlayerPosition, Vector3.up, -addRot);
    }
}
