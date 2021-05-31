using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerTran;//主角的transform
    public float maxDistanceX = 2;
    public float maxDistanceY = 2;
    public float xSpeed = 4;
    public float ySpeed = 4;
    public Vector2 MinCamXandY;
    public Vector2 MaxCamXandY;
    
    //判断是否需要移动摄像机
    private bool NeedMoveX()
    {
        bool bMove = true;
        if (Mathf.Abs(playerTran.position.x - transform.position.x) > maxDistanceX)
            bMove = true;
        else
            bMove = false;
        return bMove;
    } 
    private bool NeedMoveY()
    {
        bool bMove = true;
        if (Mathf.Abs(playerTran.position.y - transform.position.y) > maxDistanceY)
            bMove = true;
        else
            bMove = false;
        return bMove;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        //playerTran = GameObject.Find("Hero").transform;
       playerTran = GameObject.FindGameObjectWithTag("Player").transform;//类首字母大写，对象首字母小写

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void TrackPlayer()
    {
        float CamNewX = transform.position.x;
        float CamNewY = transform.position.y;

        //计算新摄像机位置
        if (NeedMoveX())
            //float Lerp(float a, float b, float t) ;第3个参数是个比例因数，是0.1时表示0到100这个长度的十分之一，同理，0.2表示十分之二，依此类推。Clamp（夹子，夹住）函数
            CamNewX = Mathf.Lerp(transform.position.x, playerTran.position.x, xSpeed * Time.deltaTime);
        if (NeedMoveY())
            CamNewY = Mathf.Lerp(transform.position.y, playerTran.position.y, ySpeed * Time.deltaTime);


        CamNewX = Mathf.Clamp(CamNewX, MinCamXandY.x, MaxCamXandY.x);
        CamNewY = Mathf.Clamp(CamNewY, MinCamXandY.y, MaxCamXandY.y);
        transform.position = new Vector3(CamNewX, CamNewY, transform.position.z);

    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }
}
