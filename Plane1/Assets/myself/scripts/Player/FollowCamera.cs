using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Transform camera;
    Transform myTransform;
	// Use this for initialization
	void Start () {
        myTransform = GameObject.Find("CameraPos").transform;
        camera=GameObject.Find("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
        // ワールド座標を基準に、座標を取得
        Vector3 worldPos = myTransform.position;
        Vector3 camerapos=camera.position;

        Vector3 worldAngle = myTransform.eulerAngles;
        Vector3 cameraangle=camera.eulerAngles;

        cameraangle.x= worldAngle.x; // ワールド座標を基準にした、x軸を軸にした回転角度
        cameraangle.y= worldAngle.y; // ワールド座標を基準にした、y軸を軸にした回転角度
        cameraangle.z= worldAngle.z; // ワールド座標を基準にした、z軸を軸にした回転角度

        camerapos.x = worldPos.x;    // ワールド座標を基準にした、x座標が入っている変数
        camerapos.y = worldPos.y;    // ワールド座標を基準にした、y座標が入っている変数
        camerapos.z = worldPos.z;    // ワールド座標を基準にした、z座標が入っている変数

        camera.eulerAngles=cameraangle;
        camera.position=camerapos;
	}
}
