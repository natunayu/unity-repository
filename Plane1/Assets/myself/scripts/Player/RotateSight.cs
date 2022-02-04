using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSight : MonoBehaviour
{
        //周りを見渡そうと思います
    float rsh;
    float rsv;
    
    float addx=1.0f;
    float addy=1.5f;

    Transform myTransform;
    Transform myTransform2;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GameObject.Find("rotateY").transform;
        myTransform2 = GameObject.Find("rotateX").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rsh = Input.GetAxis ("R_Stick_H");
        rsv = Input.GetAxis ("R_Stick_V");
        Vector3 worldAngle = myTransform.localEulerAngles;
        Vector3 worldAngle2 = myTransform2.eulerAngles;

        //おしたらずっと回転し続けるver
        /*if(rsv!=0)
        {
            //if(rsv<0.0f)worldAngle.x+=addx;
            //if(rsv>0.0f)worldAngle.x-=addx;
        }
        if(rsh!=0)//右スティックが倒されている
        {
            if(rsh<0.0f)worldAngle.y-=addy;
            if(rsh>0.0f)worldAngle.y+=addy;
        }
        else//右スティックが倒されていない
        {
           //視点をリセットするコード欲しい
        }*/
        
        if(rsh>0&&rsv>0)
        {
            worldAngle.y=270+(rsv*90.0f);//右下
        }
        else if(rsh>0&&rsv<=0)
        {
            worldAngle.y=180+90-(-rsv*90.0f);//右上
        }
        else if(rsh<0&&rsv>=0)
        {
            //左下
            worldAngle.y=90-(rsv*90.0f);
        }
        else if(rsh<=0&&rsv<0)
        {
            //左上
             worldAngle.y=90-(rsv*90.0f);
        }
        else 
        {
            if(worldAngle.y>180&&worldAngle.y<359)worldAngle.y+=1;
            else if(worldAngle.y<=180&&worldAngle.y>1)worldAngle.y-=1;
            else worldAngle.y=0;
        }

        myTransform.localEulerAngles=worldAngle;
        myTransform2.eulerAngles=worldAngle2;
    }
}
