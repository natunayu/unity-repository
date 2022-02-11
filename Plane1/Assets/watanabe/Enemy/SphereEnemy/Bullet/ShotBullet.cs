using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    //　弾のプレハブ
    [SerializeField]
    private GameObject bullet;
    //　弾を飛ばす間隔時間
    [SerializeField]
    private float waitTime = 5.0f;
    //　経過時間
    private float elapsedTime = 0f;
    //　砲台の弾が出てくる場所
    private Transform bulletHoleTra;
    //　弾を飛ばす力
    [SerializeField]
    private float power = 0.1f;
    //　弾を消すまでの時間
    [SerializeField]
    private float deleteTime = 10f;
    //　弾を飛ばす位置のオフセット値
    [SerializeField]
    private Vector3 offset = new Vector3(0f, 1f, 0f);
    //　キャラクター操作スクリプト
    private PlayerTransform predictionChara;
 
    private void Start() {
        //　弾を飛ばす位置を取得
        bulletHoleTra = transform.Find("LaunchPoint");
        //　キャラクターの操作スクリプトを取得
        predictionChara = GameObject.FindWithTag("Player").GetComponent<PlayerTransform>();
    }
    
    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime < waitTime) {
            return;
        }
        elapsedTime = 0f;
        Shot();
    }
 
    void Shot() {
        //　キャラクターの位置＋offset
        var charaPoint = predictionChara.GetTransform().position + offset;
        //　弾の到達時間を計算
        var arrivalTime = Vector3.Distance(charaPoint, bulletHoleTra.position) / power;
        //　キャラクターの横の移動予測値
        var predictionPosXZ = predictionChara.GetTransform().forward * predictionChara.GetVelocityXZ().magnitude * arrivalTime;
        //　キャラクターの縦の移動予測値
        var predictionPosY = predictionChara.GetTransform().up * predictionChara.GetVelocityY() * arrivalTime;
        //　キャラクターがそのまま移動した時に弾がキャラクターに当たる位置を計算
        var predictionCharaPoint = charaPoint + predictionPosXZ + predictionPosY;
        //　砲台の向きを一旦キャラクターに向ける
        transform.LookAt(predictionCharaPoint);
        //　砲台とキャラクターの予測移動先の長さ
        var adjacent = Vector3.Distance(bulletHoleTra.position, predictionCharaPoint);

        //　弾をインスタンス化
        var bulletIns = Instantiate(bullet, bulletHoleTra.position, Quaternion.identity);
        var rigid = bulletIns.GetComponent<Rigidbody>();
        //　弾のRigidbodyを使って砲台が向いている方向に力を加える
        rigid.AddForce(bulletHoleTra.forward * power, ForceMode.Impulse);
        //　弾を発射してから指定した時間が経過したら自動で削除
        Destroy(bulletIns, deleteTime);
    
        //　弾の軌跡を表示
        Debug.DrawLine(bulletHoleTra.position, predictionCharaPoint, Color.red, deleteTime);
    }
}
    