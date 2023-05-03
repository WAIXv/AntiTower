using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Net;
using System.IO;
using UnityEngine.EventSystems;

public class CameraControl : ActionBase
{
    //高度
    public float minHeight = 100f;  // The min_height camera can reach
    public float maxHeight = 2000f;  //The max_height camera can reach
    //角度
    public float minAngleX = 0f;   // The min_angle camera can reach
    public float maxAngleX = 90f;  // The max_height camera can reach
    //速度
    public float minSpeed = 80f;   // The min_speed camera can reach
    public float maxSpeed = 300f;  // The max_speed camera can reach
    public float rotateSpeed = 60f;    // The rotate_speed camera can reach

    //控制变量
    private Vector3 viewPos_0;         //鼠标左键初始坐标
    private Vector3 viewPos_1;         //鼠标右键初始坐标

    private Vector3 startCameraPos;           //相机初始位置
    private Vector3 targetCameraPos;          //相机目标位置

    private Vector2 startCameraEuler;         //初始角度
    private Vector2 targetCameraEuler;        //目标角度
    private Vector3 axisRight;                //旋转轴

    //相机控制
    private Camera mainCamera;       //定义一个相机变量

    private bool isCameraCtrl = false;           //相机是否可控制

    //相机操作有效性判断
    private bool isClickUI = false;    


    public override void Init()
    {
        mainCamera = transform.Find("MainCamera").GetComponent<Camera>();
        targetCameraPos = transform.position;
        targetCameraEuler = transform.eulerAngles;
    }

    public override void RegisterAction()
    {
        GameEvent.StartCameraControl += StartCameraControl;
        GameEvent.StopCameraControl += StopCameraControl;
    }

    public override void RemoveAction()
    {
        GameEvent.StartCameraControl -= StartCameraControl;
        GameEvent.StopCameraControl -= StopCameraControl;
    }

    void Update()
    {
        //Debug.Log(transform.position.ToString() + "update");
        //相机控制
        if (isCameraCtrl)
        {
            //操作有效性判断
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                isClickUI = EventSystem.current.IsPointerOverGameObject();
            }
            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
            {
                isClickUI = false;
            }
            if (!isClickUI)
            {
                //平移控制
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(2))
                {
                    //自由视角
                    viewPos_0 = mainCamera.ScreenToViewportPoint(Input.mousePosition);
                    startCameraPos = transform.position;
                    startCameraEuler = transform.eulerAngles;
                }
                if (Input.GetMouseButton(0) || Input.GetMouseButton(2))
                {
                    float moveSpeed = GetMoveSpeed();
                    Vector3 dis = (mainCamera.ScreenToViewportPoint(Input.mousePosition) - viewPos_0) * moveSpeed;
                    dis = new Vector3(-dis.x * 3f, 0f, -dis.y);
                    dis = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * dis;
                    targetCameraPos = startCameraPos + dis;
                }
                //旋转控制
                if (Input.GetMouseButtonDown(1))
                {
                    viewPos_1 = mainCamera.ScreenToViewportPoint(Input.mousePosition);
                    startCameraPos = transform.position;
                    startCameraEuler = transform.eulerAngles;
                }
                if (Input.GetMouseButton(1))
                {
                    Vector2 angle = (mainCamera.ScreenToViewportPoint(Input.mousePosition) - viewPos_1) * rotateSpeed;
                    angle = new Vector3(-angle.y, angle.x);
                    targetCameraEuler = startCameraEuler + angle;
                }
                //缩进控制
                if (Input.mouseScrollDelta != Vector2.zero)
                {
                    float moveSpeed = GetMoveSpeed() * 0.1f;
                    targetCameraPos += transform.forward * moveSpeed * Input.mouseScrollDelta.y;
                }
                //键盘控制
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    float speedArgs = 0.3f;
                    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                    {
                        speedArgs = 1f;
                    }
                    float moveSpeed = GetMoveSpeed();
                    targetCameraPos += (transform.forward * moveSpeed * speedArgs * Input.GetAxis("Vertical") * Time.deltaTime + transform.right * moveSpeed * speedArgs * Input.GetAxis("Horizontal") * Time.deltaTime);
                }

                //相机运动
                LimitCamera();
                //控制相机运动
                if (Vector3.Distance(transform.position, targetCameraPos) > 0.1f)
                {
                    transform.position = Vector3.Lerp(transform.position, targetCameraPos, 0.1f);
                }
                //控制相机旋转
                if (Quaternion.Angle(transform.rotation, Quaternion.Euler(targetCameraEuler)) > 0.1f)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetCameraEuler), 0.1f);
                }
            }
        }
    }

    //开启相机控制
    void StartCameraControl()
    {
        
        isCameraCtrl = true;
        viewPos_0 = mainCamera.ScreenToViewportPoint(Input.mousePosition); //设置鼠标左键初始坐标
        viewPos_1 = mainCamera.ScreenToViewportPoint(Input.mousePosition); //设置鼠标右键初始坐标
        startCameraPos = transform.position;
        startCameraEuler = transform.eulerAngles;
        targetCameraPos = transform.position;
        targetCameraEuler = transform.eulerAngles;
    }

    //停止相机控制
    void StopCameraControl()
    {
        isCameraCtrl = false;
    }
    

    //获取相机移动速度
    float GetMoveSpeed()
    {
        float rate = (transform.position.y - minHeight) / (maxHeight - minHeight);
        return minSpeed + (maxSpeed - minSpeed) * rate;
    }

    //限制相机位置，角度
    void LimitCamera()
    {
        
        //位置限制
        //if (targetCameraPos.y < minHeight) { targetCameraPos.y = minHeight; }
        //targetCameraPos.x = Mathf.Clamp(targetCameraPos.x, minX, maxX);
        targetCameraPos.y = Mathf.Clamp(targetCameraPos.y, minHeight, maxHeight);
        //targetCameraPos.z = Mathf.Clamp(targetCameraPos.z, minZ, maxZ);
        //角度限制
        if (targetCameraEuler.x > 180) { targetCameraEuler.x -= 360f; }
        if (targetCameraEuler.x < -180) { targetCameraEuler.x += 360; }
        if (targetCameraEuler.y > 180) { targetCameraEuler.y -= 360f; }
        if (targetCameraEuler.y < -180) { targetCameraEuler.y += 360; }
        targetCameraEuler.x = Mathf.Clamp(targetCameraEuler.x, minAngleX, maxAngleX);
    }

    
}
