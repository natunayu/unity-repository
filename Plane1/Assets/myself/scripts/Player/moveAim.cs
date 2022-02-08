using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAim : MonoBehaviour
{
    //右スティックでエイムするコードです
    // Start is called before the first frame update

    float rsh;
    float rsv;
    
    float addx=1.0f;
    float addy=1.5f;

    private float tempx=0;
    private float tempy=0;

    Transform myTransform;

    private bool keyboard=false;//操作方法についてキーボードかコントローラか
        //RotateSkyV2 にも同じスクリプトがある
        //MoveChara,moveAimにも同じスクリプトがある

    void Start()
    {
        myTransform = GameObject.Find("Aim").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rsh = Input.GetAxis ("R_Stick_H");
        rsv = Input.GetAxis ("R_Stick_V");

        //Debug.Log(rsh);

        float addx=rsh*1.0f;
        float addy=rsv*-1.0f;

        Vector3 localPos = myTransform.localPosition;

        if(keyboard==false)
        {
            if(rsh==0&&rsv==0)//戻す
            {
                //if(localPos.x>0)localPos.x+=addy;
                //if(localPos.x<0)localPos.x-=addy;
            }
            else 
            {
            //localPos.x = 1.0f;    // 奥行
            localPos.x +=addx;    // 左右　←＋　→-
            localPos.y +=addy;    // 上下　↑+　↓-
            if(localPos.x>80||localPos.x<-80)localPos.x-=addx;
            if(localPos.y>60||localPos.y<-40)localPos.y-=addy;
            }
            myTransform.localPosition = localPos; // ローカル座標での座標を設定
        }
        else
        {
            Vector3 position=Input.mousePosition;
            if(Input.GetMouseButton(0))
            {
                float distx=position.x-tempx;
                float disty=position.y-tempy;

                localPos.x +=distx;    // 左右　←＋　→-
                localPos.y +=disty;    // 上下　↑+　↓-
                if(localPos.x>80||localPos.x<-80)localPos.x-=distx;
                if(localPos.y>60||localPos.y<-40)localPos.y-=disty;

                myTransform.localPosition = localPos; // ローカル座標での座標を設定

                tempx=position.x;
                tempy=position.y;
            }
            else
            {
                tempx=position.x;
                tempy=position.y;
            }

        }
            if(Input.GetKey(KeyCode.P))//きーぼど操作ORコントローラ操作
            //shootingにも同じスクリプトあるからそこも書き換えること
            //MoveChara,moveAimにも同じスクリプトがある
            {
                if(keyboard==false)keyboard=true;
                else keyboard=false;
            }
    }
}
