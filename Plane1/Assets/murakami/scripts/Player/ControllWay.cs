using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllWay : MonoBehaviour
{
    //このスクリプトでは空オブジェクトの座標を切り替えマス
    //その空オブジェクトの座標に応じてコントローラ操作、キーボード操作を切り替えようというものです
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.O)))
        {
        Transform myTransform = this.transform;
 
        Vector3 worldPos = myTransform.position;
        float y=worldPos.y;
        if(y>0)worldPos.y=-1;
        else if(y<0) worldPos.y=1;
        myTransform.position = worldPos;  // ワールド座標での座標を設定
        }
    }
}
