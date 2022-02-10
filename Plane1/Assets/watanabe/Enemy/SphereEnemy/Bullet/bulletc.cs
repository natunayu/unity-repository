using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletc : MonoBehaviour
 {
    //　弾のプレハブ
    [SerializeField] private GameObject bullet;
 
    //　弾を飛ばす間隔時間
    [SerializeField]
    private float waitTime = 0.1f;
    //　経過時間
    private float elapsedTime = 0f;
 
    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime < waitTime) {
            return;
        }
        //　発射地点を指定
        Vector3 LPoint = GameObject.Find("LaunchPoint").transform.position;

        Instantiate(bullet, LPoint, Quaternion.identity);
        elapsedTime = 0f;
    }
}