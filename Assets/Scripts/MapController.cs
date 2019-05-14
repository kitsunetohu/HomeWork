using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapController : Manager<MapController>
{
    public GameObject OutdoorMap;
    public GameObject Floor1Map;
    public GameObject Floor2Map;

    public Animation playerMarkAnima;

    public AnimationClip outdoor;
    public AnimationClip F1;
    public AnimationClip F3;

    AnimationClip currentClip;
    GameObject[] Maps;
    int nowMap;

    void Start()
    {
        Maps = new GameObject[] { OutdoorMap, Floor1Map, Floor2Map };
        playerMarkAnima = GetComponent<Animation>();
        nowMap = 0;
        GameManager.Instance.PlayerMoveFront.AddListener(PlayerMoveFront);
        GameManager.Instance.PlayerMoveBack.AddListener(PlayerMoveBack);
        GameManager.Instance.goToNextPoint.AddListener(GoToNextPoint);
        MoveController.Instance.InsCheckPoint.AddListener(InsCheckPoint);
    }

    void Update()
    {
    }

    public void nextMap()
    {
        if (nowMap >= 2) return;

        Maps[nowMap].SetActive(false);
        nowMap += 1;
        Maps[nowMap].SetActive(true);
        Debug.Log("Map ID" + nowMap);

    }

    void GoToNextPoint(){
        //動画を再生
    }
    void InsCheckPoint(){
        //動画を停止
    }

     void PlayerMoveBack(){
        //動画を再生
    }

     void PlayerMoveFront(){
        //動画を停止
    }
}
