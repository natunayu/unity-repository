using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider gunslider;//銃の連射できないようにするすらいだー
    private float maxlevel=10;//スライダーの最大値
    private float gunlevel=0.0f;//今どれくらい撃ったのかの判定
    private float gunfire=0.5f;//どのくらい増やすか
    private float gunheal=0.01f;//どのくらい減らすか
    private bool goshoot=true;//連射しすぎてオーバーヒートしているか否か
 
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

        KeyOrMouse();

        trans.transform.LookAt(target.transform);
        trans2.transform.LookAt(target.transform);
        
        if(keyboard==false&&goshoot==true)
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
                gunlevel+=gunfire;
                }
                else if(timer<30)
                {
                    timer++;
                }
                else if(timer>=30) timer=0;

            }
            else if(tri<=0)
            {
              timer=0;
              if(gunlevel>=0)gunlevel-=gunheal;  
            } 
        }
        if(keyboard==true&&goshoot==true)
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
                gunlevel+=gunfire;
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
                else if(timer>=30)timer=0;
            }
            else
            {
                timer=0;
                if(gunlevel>=0)gunlevel-=gunheal;
            }
        }

        if(gunlevel>=maxlevel)//オーバーヒート決定
        {
            goshoot=false;//撃てなくします
        }
        if(goshoot==false)
        {
            gunlevel-=gunheal;
            if(gunlevel<=0)goshoot=true;//銃を撃てるように
        }

        gunslider.value=gunlevel;//とりあえずスライダーの変更		
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
