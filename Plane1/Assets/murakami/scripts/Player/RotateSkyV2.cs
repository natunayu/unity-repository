using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyV2 : MonoBehaviour
{
    //　回転スピード
    [SerializeField]
    private float rotateSpeed = 1f;
    //　スカイボックスのマテリアル
    private Material skyboxMaterial;

    Transform myTransform;
    Transform worldtransform;
    Transform xwing;
    Vector3 localAngle;
    Vector3 worldangle;

    float local_angle_x;
    float local_angle_y;
    float local_angle_z;

    float PlaneRotateSpeed=0.1f;

    private bool turnR=false;
    private bool turnL=false;
    private float TURN=0;//2右　1左

    private float easeadd=0.0f;

    private bool keyboard=false;//操作方法についてキーボードかコントローラか
    //Shooting にも同じスクリプトがある
    //MoveChara,moveAimにも同じスクリプトがある

	// Use this for initialization
	void Start () {
        //　Lighting Settingsで指定したスカイボックスのマテリアルを取得
        skyboxMaterial = RenderSettings.skybox;
        myTransform = GameObject.Find("Player1").transform;
        worldtransform=GameObject.Find("Main (1)").transform;
        xwing=GameObject.Find("Main (1)").transform;
        //worldtransform=GameObject.Find("Player1").transform;
    }
	
	// Update is called once per frame
	void Update () {
        KeyOrMouse();

        skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") - rotateSpeed* Time.deltaTime, 360f));

    if(keyboard==false)//コントローサ操作の時
    {
        float lsh = Input.GetAxis ("L_Stick_H");//左スティックの傾き　ヨコ
        float lsv = Input.GetAxis ("L_Stick_V");//左スティックの傾き　タテ

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

        if(local_angle_y>175)localAngle.y-=PlaneRotateSpeed;//回転させる
        if(local_angle_z<190)localAngle.z+=PlaneRotateSpeed*2;

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

        if(local_angle_y<185)localAngle.y+=PlaneRotateSpeed;//回転させる
        if(local_angle_z>170)localAngle.z-=PlaneRotateSpeed*2;
        
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

        if(local_angle_y!=180.0f)
        {
        if(local_angle_y<180.0f)localAngle.y+=PlaneRotateSpeed*3;
        else local_angle_y=180.0f;
        }

        if(local_angle_z!=180.0f)
        {
        if(local_angle_z>180.0f)localAngle.z-=PlaneRotateSpeed*3;
        else local_angle_z=180.0f;
        }

        if(local_angle_z==180.0f&&local_angle_y==180.0f)turnL=false;

        myTransform.localEulerAngles=localAngle;
        }
        else if(turnR==true)
        {
        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y!=180.0f)
        {
        if(local_angle_y>180.0f)localAngle.y-=PlaneRotateSpeed*3;
        else local_angle_y=180.0f;
        }

        if(local_angle_z!=180.0f)
        {
        if(local_angle_z<180)localAngle.z+=PlaneRotateSpeed*3;
        else local_angle_z=180.0f;
        }

        if(local_angle_z==180.0f&&local_angle_y==180.0)turnR=false;

        myTransform.localEulerAngles=localAngle;

        }
        if(lsv>0)//上昇
        {
            Vector3 xwingz=xwing.localEulerAngles;
            xwingz.x-=easeadd;
            if(xwingz.x>275||xwingz.x<265)xwing.localEulerAngles=xwingz;
        }
        else if(lsv<0)//下降
        {
            Vector3 xwingz=xwing.localEulerAngles;
            xwingz.x+=easeadd;
            if(xwingz.x<85||xwingz.x>275)xwing.localEulerAngles=xwingz;
        }
        else easeadd=0;

        //Debug.Log(easeadd);

        if(easeadd<1.2f)easeadd+=0.03f;
        //従来手法の上下
        /*
        if(lsv>0)
        {
        localAngle = myTransform.localEulerAngles;

        local_angle_x = localAngle.x; //角度取得

        if(local_angle_x<30||local_angle_x>330) localAngle.x+=PlaneRotateSpeed*5;

        myTransform.localEulerAngles=localAngle;
        }
        else if(lsv<0)
        {
            localAngle = myTransform.localEulerAngles;

            local_angle_x = localAngle.x; //角度取得

            if(local_angle_x>330||local_angle_x<30) localAngle.x-=PlaneRotateSpeed*5;

            myTransform.localEulerAngles=localAngle;
        }
        else if(lsv==0.0f)
        {
            localAngle = myTransform.localEulerAngles;

            local_angle_x = localAngle.x; //角度取得

            if(local_angle_x>1.0f&&local_angle_x<40)localAngle.x-=PlaneRotateSpeed*5;
            else if(local_angle_x>320)localAngle.x+=PlaneRotateSpeed*5;
            else localAngle.x=0.0f;

            myTransform.localEulerAngles=localAngle;
        }
        */
    }
    else if(keyboard==true)//キーボード操作の時
    {
        if (Input.GetKey(KeyCode.A)&&turnR==false&&turnL==false)//左回転
        {
            TURN=1;
        //skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") - rotateSpeed, 360f));
        worldangle=worldtransform.localEulerAngles;
        worldangle.y-=rotateSpeed;
        worldtransform.localEulerAngles=worldangle;
        
        localAngle = myTransform.localEulerAngles;

        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y>175)localAngle.y-=PlaneRotateSpeed;//回転させる
        if(local_angle_z<190)localAngle.z+=PlaneRotateSpeed*2;

        myTransform.localEulerAngles=localAngle;

        }
        else if (Input.GetKey(KeyCode.D)&&turnR==false&&turnL==false)//右回転
        {
            TURN=2;
        //skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") + rotateSpeed, 360f));
        worldangle=worldtransform.localEulerAngles;
        worldangle.y+=rotateSpeed;
        worldtransform.localEulerAngles=worldangle;
        
        localAngle = myTransform.localEulerAngles;

        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y<185)localAngle.y+=PlaneRotateSpeed;//回転させる
        if(local_angle_z>170)localAngle.z-=PlaneRotateSpeed*2;
        
        myTransform.localEulerAngles=localAngle;

        }
        else if(Input.GetKeyUp(KeyCode.A)&&turnR==false&&turnL==false&&TURN==1){
            turnL=true;
            TURN=0;
        }
        else if(Input.GetKeyUp(KeyCode.D)&&turnR==false&&turnL==false&&TURN==2){
            turnR=true;
            TURN=0;
        }
        else if(turnL==true)
        {
        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y!=180.0f)
        {
        if(local_angle_y<180.0f)localAngle.y+=PlaneRotateSpeed*3;
        else local_angle_y=180.0f;
        }

        if(local_angle_z!=180.0f)
        {
        if(local_angle_z>180.0f)localAngle.z-=PlaneRotateSpeed*3;
        else local_angle_z=180.0f;
        }

        if(local_angle_z==180.0f&&local_angle_y==180.0f)turnL=false;

        myTransform.localEulerAngles=localAngle;
        }
        else if(turnR==true)
        {
        local_angle_y = localAngle.y; //角度取得
        local_angle_z = localAngle.z; 

        if(local_angle_y!=180.0f)
        {
        if(local_angle_y>180.0f)localAngle.y-=PlaneRotateSpeed*3;
        else local_angle_y=180.0f;
        }

        if(local_angle_z!=180.0f)
        {
        if(local_angle_z<180)localAngle.z+=PlaneRotateSpeed*3;
        else local_angle_z=180.0f;
        }

        if(local_angle_z==180.0f&&local_angle_y==180.0)turnR=false;

        myTransform.localEulerAngles=localAngle;

        }
        if(Input.GetKey(KeyCode.S))//上昇
        {
            Vector3 xwingz=xwing.localEulerAngles;
            xwingz.x-=easeadd;
            if(xwingz.x>275||xwingz.x<265)xwing.localEulerAngles=xwingz;
        }
        else if(Input.GetKey(KeyCode.W))//下降
        {
            Vector3 xwingz=xwing.localEulerAngles;
            xwingz.x+=easeadd;
            if(xwingz.x<85||xwingz.x>275)xwing.localEulerAngles=xwingz;
        }
        else easeadd=0;

        if(easeadd<1.2f)easeadd+=0.03f;
    }
    
	}
    public void OnClick()
    {
        if(keyboard==false)keyboard=true;
        else keyboard=false;
    }
    public void KeyOrMouse()//キーボードで操作するかコントローラで操作するかの確認
    {
        Transform myTransform = GameObject.Find("ControllWay").transform;
 
        Vector3 worldPos = myTransform.position;
        float y=worldPos.y;
        if(y>0)keyboard=false;
        else if(y<0) keyboard=true;
    }
}
