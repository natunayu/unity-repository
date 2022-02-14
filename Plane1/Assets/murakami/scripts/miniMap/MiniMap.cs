using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] Transform enemy2;
    [SerializeField] Transform player;
    [SerializeField] Image center;
    [SerializeField] Image target;
    [SerializeField] Image target2;
    [SerializeField] float radarLength = 30f;
 
    RectTransform rt;
    Vector2 offset;
    float r = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rt = target.GetComponent<RectTransform>();
        offset = center.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy!=null) getEnemyPos(enemy,target);
        else enemyafterDead(enemy,target);

        if(enemy2!=null) getEnemyPos(enemy2,target2);
        else enemyafterDead(enemy2,target2);
    }
    void getEnemyPos(Transform enemy,Image target)
    {
        rt = target.GetComponent<RectTransform>();
        Vector3 enemyDir = enemy.position;
        enemyDir.y = player.position.y; // プレイヤーと敵の高さを合わせる
        enemyDir = enemy.position - player.position;
 
        enemyDir = Quaternion.Inverse(player.rotation) * enemyDir; // ベクトルをプレイヤーに合わせて回転
        enemyDir = Vector3.ClampMagnitude(enemyDir, radarLength); // ベクトルの長さを制限
 
        rt.anchoredPosition = new Vector2(enemyDir.x * r + offset.x, enemyDir.z * r + offset.y);
    }
    void enemyafterDead(Transform enemy,Image target)
    {
            rt = target.GetComponent<RectTransform>();
            Vector3 PlayerDir=player.position;
            PlayerDir.y=player.position.y;
            PlayerDir=player.position;

            rt.anchoredPosition = new Vector2(PlayerDir.x + offset.x, PlayerDir.z * r + offset.y);
    }
}
