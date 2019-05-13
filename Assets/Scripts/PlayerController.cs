using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Max Angle
    public float maxAngle = 80;
    // Min Angle
    public float minAngle = -80;
    // Rotational Speed
    public float speed;

    // Now Angle of Y Direction
    private float nowAngleY;
    // Player Position
    private Vector3 PlayerPosition;
    

    void Start() {
        // Initialize
        speed          = 50;
        nowAngleY      = 0;
        PlayerPosition = transform.position;
    }

    void Update() {
        float addRot = speed * Time.deltaTime;

        // Move Up
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            nowAngleY = Mathf.Clamp(nowAngleY - addRot, minAngle, maxAngle);
            if(nowAngleY > minAngle)
                transform.RotateAround(PlayerPosition, transform.right, -addRot);
        }

        // Move Down
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            nowAngleY = Mathf.Clamp(nowAngleY + addRot, minAngle, maxAngle);
            if(nowAngleY < maxAngle)
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
