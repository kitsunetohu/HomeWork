using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveButtons : MonoBehaviour
{
    
    public Button up;
    public Button left;
    public Button right;
    public Button down;    
    bool moveUp=false;
    bool moveLeft=false;
    bool move=false;
    
    // Start is called before the first frame update
    void Start()
    {
        up.onClick.AddListener(()=>{moveUp=true;});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
