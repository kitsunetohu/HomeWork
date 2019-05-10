using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private LineRenderer beam;//たま
    // Start is called before the first frame update
    void Start()
    {
        beam=GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Fire1")>0){
            beam.enabled=true;
           // Debug.Log("Fire");
            DrawBeam();
            
        }
        else{
            beam.enabled=false;
        }
    }

    void DrawBeam(){

    }
}
