using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChara : MonoBehaviour
{
    public float speed = 10.0f;
        public Rigidbody rb;

        private bool keyboard=false;//操作方法についてキーボードかコントローラか
        //RotateSkyV2 にも同じスクリプトがある
        //MoveChara,moveAimにも同じスクリプトがある

        void Start() 
        {
            rb = GameObject.Find("Main (1)").GetComponent<Rigidbody>();
            //rb = GameObject.Find("Player1").GetComponent<Rigidbody>();
        }
 
        void FixedUpdate() 
        {
            //float x =  Input.GetAxis("Horizontal") * speed;
            //float z = Input.GetAxis("Vertical") * speed;
            //rb.AddForce(transform.forward*20,ForceMode.Force);
            float lsv = Input.GetAxis ("L_Stick_V");//左スティックの傾き　タテ
            /*if(lsv!=0)
            {
               /* Transform myTransform = GameObject.Find("Main (1)").transform;

                Vector3 pos = myTransform.position;
                

                pos.y += 3.0f*lsv;    // y座標へ0.01加算
                
                myTransform.position = pos;  // 座標を設定
                */
                Transform aatransform=GameObject.Find("Player1").transform;
                transform.position+=2*aatransform.forward;
            //}

            //else 
            transform.position += transform.forward;
            if(keyboard==false)
            {
                if (Input.GetKey ("joystick button 0")) 
                {
                transform.position += transform.forward*2;
                }
            }
            else 
            {
                if (Input.GetKey(KeyCode.Space)) 
                {
                    Debug.Log("aaa");
                transform.position += transform.forward*2;
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
