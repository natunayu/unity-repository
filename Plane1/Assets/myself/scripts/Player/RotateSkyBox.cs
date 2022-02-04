using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyBox : MonoBehaviour
{
    
    //　回転スピード
    [SerializeField]
    private float rotateSpeed = 1f;
    //　スカイボックスのマテリアル
    private Material skyboxMaterial;

    Transform myTransform;
    Transform worldtransform;
    Vector3 localAngle;
    Vector3 worldangle;

    float local_angle_y;
    float local_angle_z;

    float PlaneRotateSpeed=0.1f;

    private bool turnR=false;
    private bool turnL=false;
    private float TURN=0;//2右　1左

	// Use this for initialization
	void Start () {
        //　Lighting Settingsで指定したスカイボックスのマテリアルを取得
        skyboxMaterial = RenderSettings.skybox;
        myTransform = GameObject.Find("Player").transform;
        worldtransform=GameObject.Find("Main").transform;
    }
	
	// Update is called once per frame
	void Update () {

        float lsh = Input.GetAxis ("L_Stick_H");//左スティックの傾き
        skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") - rotateSpeed* Time.deltaTime, 360f));

        if (lsh<0&&turnR==false&&turnL==false)//左回転
        {
            TURN=1;
        //skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") - rotateSpeed, 360f));
        worldangle=worldtransform.localEulerAngles;
        worldangle.y-=rotateSpeed;
        worldtransform.localEulerAngles=worldangle;
        
        localAngle = myTransform.localEulerAngles;

        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y>355||local_angle_y<5)localAngle.y-=PlaneRotateSpeed;//回転させる
        if(local_angle_z<10||local_angle_z>350)localAngle.z+=PlaneRotateSpeed*2;

        myTransform.localEulerAngles=localAngle;

        }
        else if (lsh>0&&turnR==false&&turnL==false)//右回転
        {
            TURN=2;
        //skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") + rotateSpeed, 360f));
        worldangle=worldtransform.localEulerAngles;
        worldangle.y+=rotateSpeed;
        worldtransform.localEulerAngles=worldangle;
        
        localAngle = myTransform.localEulerAngles;

        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y<5||local_angle_y>355)localAngle.y+=PlaneRotateSpeed;//回転させる
        if(local_angle_z>350||local_angle_z<10)localAngle.z-=PlaneRotateSpeed*2;
        
        myTransform.localEulerAngles=localAngle;

        }
        else if(lsh>=0&&turnR==false&&turnL==false&&TURN==1){
            turnL=true;
            TURN=0;
        }
        else if(lsh<=0&&turnR==false&&turnL==false&&TURN==2){
            turnR=true;
            TURN=0;
        }
        else if(turnL==true)
        {
        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y!=0)
        {
        if(local_angle_y<360&&local_angle_y>300)localAngle.y+=PlaneRotateSpeed*3;
        else local_angle_y=0;
        }

        if(local_angle_z!=0)
        {
        if(local_angle_z>0)localAngle.z-=PlaneRotateSpeed*3;
        else local_angle_z=0;
        }

        if(local_angle_z==0&&local_angle_y==0)turnL=false;

        myTransform.localEulerAngles=localAngle;
        }
        else if(turnR==true)
        {
        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y!=0)
        {
        if(local_angle_y>0&&local_angle_y<100)localAngle.y-=PlaneRotateSpeed*3;
        else local_angle_y=0;
        }

        if(local_angle_z!=0)
        {
        if(local_angle_z<360&&local_angle_z>310)localAngle.z+=PlaneRotateSpeed*3;
        else local_angle_z=0;
        }

        if(local_angle_z==0&&local_angle_y==0)turnR=false;

        myTransform.localEulerAngles=localAngle;

        }
        else 
        {
            localAngle.y=0;
            localAngle.z=0;
            myTransform.localEulerAngles=localAngle;
        }
	}
}
