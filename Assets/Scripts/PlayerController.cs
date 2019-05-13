using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Max Vertical Angle
    public float maxAngleV;
    // Min Vertical Angle
    public float minAngleV;
    // Max Horizontal Angle
    public float maxAngleH;
    // Min Horizontal Angle
    public float minAngleH;
    // Rotational Speed
    public float speed;

    // Now Vertical Angle
    private float nowAngleV;
    // Player Position
    private Vector3 PlayerPosition;
    

    void Start() {
        // Initialize
        maxAngleV      = 80;
        minAngleV      = -80;
        maxAngleH      = 280;
        minAngleH      = 80;
        speed          = 50;
        nowAngleV      = 0;
        PlayerPosition = transform.position;
    }

    void Update() {
        float addRot = speed * Time.deltaTime;

        Debug.Log("-----------------------------------------");
        Debug.Log(isPlayerFront());
        
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

    bool isPlayerFront() {
        if(minAngleH < transform.localEulerAngles.y && transform.localEulerAngles.y < maxAngleH)
            return false;
        return true;
    }
}
