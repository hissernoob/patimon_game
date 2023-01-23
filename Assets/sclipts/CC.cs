using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
public GameObject player;

    private Vector3 offset;
    //カメラの追従
    void Start ()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC : MonoBehaviour
{
    private Vector3 offset;
    private GameObject mainCamera;              //メインカメラ格納用
    public GameObject player;            //回転の中心となるプレイヤー格納用
    public float rotateSpeed = 2.0f;            //回転の速さ

    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとユニティちゃんをそれぞれ取得
        offset = transform.position - player.transform.position;
        mainCamera = Camera.main.gameObject;
        player = GameObject.Find("bo-ru");
    }


    //単位時間ごとに実行される関数
    void Update()
    {
        //rotateCameraの呼び出し
        rotateCamera();
        transform.position = player.transform.position + offset;
    }

    //カメラを回転させる関数
    private void rotateCamera()
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed,Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()をしようしてメインカメラを回転させる
        mainCamera.transform.RotateAround(player.transform.position, Vector3.up, angle.x);
        mainCamera.transform.RotateAround(player.transform.position, transform.right, angle.y);
    }
}*/
