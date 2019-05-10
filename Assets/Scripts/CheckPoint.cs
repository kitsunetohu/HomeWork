using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    Button mahoujin;
    // Start is called before the first frame update
    void Start()
    {
        mahoujin=GetComponentInChildren<Button>();
        mahoujin.onClick.AddListener(()=>debugCheck());
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void debugCheck(){
        
            Debug.Log("Point Clear!");
            GameManager.Instance.nextCheckPoint();
            Destroy(this.gameObject);
        
    }
}
