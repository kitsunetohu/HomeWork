using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private LineRenderer beam;//たま
    // Start is called before the first frame update
    void Start()
    {
        Physics.queriesHitBackfaces = true;
        beam = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            beam.enabled = true;
            // Debug.Log("Fire");
            DrawBeam();

            

        }
        else
        {
            beam.enabled = false;
        }
    }

    void DrawBeam()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        Physics.queriesHitBackfaces = true;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            Debug.DrawLine(transform.position, hit.point);

        beam.SetPosition(0,transform.position);
        beam.SetPosition(1,hit.point);

         
    }
}
