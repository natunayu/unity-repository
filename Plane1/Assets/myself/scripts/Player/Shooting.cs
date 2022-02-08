using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // bullet prefab
    public GameObject bullet;
    public GameObject bullet2;

    public GameObject target;

    private int timer=0;
 
    // 弾丸の速度
    public float speed = 0.1f;

    Transform trans;
    Transform trans2;

    private bool keyboard=false;//操作方法についてキーボードかコントローラか
    //RotateSkyV2 にも同じスクリプトがある
    //MoveChara,moveAimにも同じスクリプトがある
 
	// Use this for initialization
	void Start () {
        trans=GameObject.Find("FireR").transform;
        trans2=GameObject.Find("FireL").transform;

        trans.transform.LookAt(target.transform);
        trans2.transform.LookAt(target.transform);
	}
	
	// Update is called once per frame
	void Update () {
        // z キーが押された時

        trans.transform.LookAt(target.transform);
        trans2.transform.LookAt(target.transform);
        
        if(keyboard==false)
        {
            float tri = Input.GetAxis ("L_R_Trigger");
            if (tri>0){
                if(timer==0)
                {
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;
                GameObject bullets2 = Instantiate(bullet) as GameObject;
 
                Vector3 force;
    
                Vector3 worldPos = trans.position;
                Vector3 worldPos2 = trans2.position;
                //worldPos.x += 6.2f;    // ワールド座標を基準にした、x座標を1に変更
                //worldPos.y -= 4.0f;    // ワールド座標を基準にした、y座標を1に変更
                //worldPos.z += 1.13f;    // ワールド座標を基準にした、z座標を1に変更
                // 弾丸の位置を調整
                bullets.transform.position = worldPos;
                bullets2.transform.position = worldPos2;


               // Rigidbodyに力を加えて発射
                force = GameObject.Find("FireR").gameObject.transform.forward * speed;
                bullets.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
                force = GameObject.Find("FireL").gameObject.transform.forward * speed;
                bullets2.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
                timer++;
                }
                else if(timer<30)
                {
                    timer++;
                }
                else timer=0;

            }
            else if(tri<=0) timer=0;
        }
        if(keyboard==true)
        {
            if (Input.GetMouseButton(0))
            {
                if(timer==0)
                {
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;
                GameObject bullets2 = Instantiate(bullet) as GameObject;
 
                Vector3 force;
    
                Vector3 worldPos = trans.position;
                Vector3 worldPos2 = trans2.position;
                //worldPos.x += 6.2f;    // ワールド座標を基準にした、x座標を1に変更
                //worldPos.y -= 4.0f;    // ワールド座標を基準にした、y座標を1に変更
                //worldPos.z += 1.13f;    // ワールド座標を基準にした、z座標を1に変更
                // 弾丸の位置を調整
                bullets.transform.position = worldPos;
                bullets2.transform.position = worldPos2;


                // Rigidbodyに力を加えて発射
               force = GameObject.Find("FireR").gameObject.transform.forward * speed;
                bullets.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
                force = GameObject.Find("FireL").gameObject.transform.forward * speed;
                bullets2.GetComponent<Rigidbody>().AddForce(force,ForceMode.Impulse);
                timer++;
                }
                else if(timer<30)
                {
                    timer++;
                }
                else timer=0;
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
