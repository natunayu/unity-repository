using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateHealBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update () {
        // transformを取得
        Transform myTransform = this.transform;
 
        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.y += 0.50f; // ワールド座標を基準に、y軸を軸にした回転を10度に変更
        myTransform.eulerAngles = worldAngle; // 回転角度を設定
 
    }
}
