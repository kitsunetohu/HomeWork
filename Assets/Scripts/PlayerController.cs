using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxAngleV;           // Max Vertical Angle
    public float minAngleV;           // Min Vertical Angle
    public float maxAngleH;           // Max Horizontal Angle
    public float minAngleH;           // Min Horizontal Angle
    public float speed;               // Rotational Speed

    private Vector3 PlayerPosition;   // Player Position

    public float boundary ;

    void Start()
    {
        // Initialize
        maxAngleV = 280;
        minAngleV = 80;
        maxAngleH = 280;
        minAngleH = 80;
        speed = 50;
        PlayerPosition = transform.position;
    }

    void Update()
    {
       
    }

    void LateUpdate(){
         float addRot = speed * Time.deltaTime;

        //Debug.Log("-----------------------------------------");
        //Debug.Log(transform.localEulerAngles.x);

        // Move Up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)||whereMouse().y>0)
            if (minAngleV > transform.localEulerAngles.x - addRot || transform.localEulerAngles.x - addRot > maxAngleV)
                transform.RotateAround(PlayerPosition, transform.right, -addRot);

        // Move Down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)||whereMouse().y<0)
            if (minAngleV > transform.localEulerAngles.x + addRot || transform.localEulerAngles.x + addRot > maxAngleV)
                transform.RotateAround(PlayerPosition, transform.right, addRot);

        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)||whereMouse().x>0)
            transform.RotateAround(PlayerPosition, Vector3.up, addRot);

        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)||whereMouse().x<0)
            transform.RotateAround(PlayerPosition, Vector3.up, -addRot);
    }

    public bool isPlayerFront()
    {
        if (minAngleH < transform.localEulerAngles.y && transform.localEulerAngles.y < maxAngleH)
            return false;
        return true;
    }

    Vector2 whereMouse(){
        Vector2 result=new Vector2(0,0);
        Vector2 pos=Input.mousePosition;
        if(Input.GetAxis("Fire1") > 0){
            if(pos.x<=boundary){
            result.x=-1;
        }
        else if(pos.x>Screen.width-boundary){
            result.x=1;
        }
        if(pos.y<=boundary){
            result.y=-1;
        }
        else if(pos.y>Screen.height-boundary){
            result.y=1;
        }

        
        }
        return result;
    }
    
}
