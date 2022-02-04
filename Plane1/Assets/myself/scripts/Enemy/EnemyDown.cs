using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDown : MonoBehaviour
{
    [SerializeField] private float _life = 10;

    [SerializeField]
    GameObject explosionPrefab = null;   // ★追加

    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnCollisionEnter(Collision collision)
    {
      //Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得
      if(collision.gameObject.name=="Bullet(Clone)")
      {
          _life-=1;
      }

      if(_life<0){
      Instantiate(explosionPrefab, transform.position, Quaternion.identity);
      Destroy(gameObject);
      }
    }
}
