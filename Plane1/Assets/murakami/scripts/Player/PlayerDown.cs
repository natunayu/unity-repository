using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDown : MonoBehaviour
{
   [SerializeField] private float p_life = 10;

    [SerializeField]
    GameObject explosionPrefab = null;   // ★追加

    private float maxlife=10;

    public Slider lifeslider;

    void Start()
    {
        maxlife=p_life;
        lifeslider.value=maxlife;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.name=="EnemyBullet(Clone)")
      {
          p_life-=1;
      }
      else if(collision.gameObject.name=="HealBox")
      {
          p_life+=5;
          if(p_life>maxlife) p_life=maxlife;
          Destroy(collision.gameObject);
      }
      else//別のオブジェクトに当たったら即死
      {
          p_life-=maxlife;
      }
      lifeslider.value=p_life;

       //Debug.Log(collision.gameObject.name+" "+p_life); // ぶつかった相手の名前を取得

      if(p_life<=0){
      Instantiate(explosionPrefab, transform.position, Quaternion.identity);
      Destroy(gameObject);
      
      FadeManager.Instance.LoadScene ("SampleScene", 2.0f);
      }
    }
}
