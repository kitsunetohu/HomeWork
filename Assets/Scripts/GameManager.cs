using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MonsterLove.StateMachine;

public class GameManager : Manager<GameManager>
{
    public enum GameState
    {
        Prepare,
        Moving,
        InPoint
    }
    public PlayerController playerController;
    StateMachine<GameState> gameFSM;
    public List<CheckPoint> checkPoints = new List<CheckPoint>();
    public UnityEvent goToNextPoint;
    public bool isMoving
    {
        get { return isMoving; }
        private set { isMoving = value; }
    }

    private int nowCheckPoint = 0;

    // Start is called before the first frame update

    new void Awake()
    {
        base.Awake();
        gameFSM = StateMachine<GameState>.Initialize(this);
        gameFSM.ChangeState(GameState.Prepare);

    }

    void Start()
    {
        nowCheckPoint = 0;
        goToNextPoint = new UnityEvent();
        goToNextPoint.AddListener(MoveController.Instance.MoveToNextPoint);
    }

    // Update is called once per frame

    void Update()
    {

    }

    public void nextCheckPoint()
    {
        //終点じゃなければ
        if (nowCheckPoint < checkPoints.Count - 1)
        {
            gameFSM.ChangeState(GameState.Moving);

        }
        else
        {

            Debug.LogWarning("at finish point!");
        }
    }

    void Moving_Enter()
    {
        nowCheckPoint++;
        // マップ切替
        //MapController.Instance.nextMap();
        //動画再生

        goToNextPoint.Invoke();
    }
    void Moving_Update(){
        if(!playerController.isPlayerFront()){
            MoveController.Instance.PlayerMoveBack();
        }
        else{
            MoveController.Instance.PlayerMoveFront();
        }
    }




    void InPoint_Enter()
    {
        Instantiate(checkPoints[nowCheckPoint], Vector3.zero, Quaternion.identity);
        Debug.Log("enter check point" + nowCheckPoint);
    }
    public void InsCheckPoint()
    {
        gameFSM.ChangeState(GameState.InPoint);
    }
    public int NowCheckPoint()
    {
        return nowCheckPoint;
    }


}
