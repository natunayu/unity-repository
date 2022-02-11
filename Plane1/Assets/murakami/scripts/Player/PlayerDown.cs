using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDown : MonoBehaviour
{
    public static int HP=5;
    private int maxHP=5;
   [SerializeField] private float p_life = 10;

    [SerializeField]
    GameObject explosionPrefab = null;   // ★追加

    private float maxlife=10;

    public Slider lifeslider;

    //残りのライフアイコン
    public GameObject life5;
    public GameObject life4;
    public GameObject life3;
    public GameObject life2;
    public GameObject life1;
    

    void Start()
    {
        maxlife=p_life;
        lifeslider.value=maxlife;
        lifeIcon();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.name=="EnemyBullet(Clone)"||collision.gameObject.name=="bullet(Clone)")
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
      
        if(HP>0)
        {
            FadeManager.Instance.LoadScene ("SampleScene", 2.0f);
              HP-=1;
        }
        else {
            FadeManager.Instance.LoadScene ("GameOver", 2.0f);
              HP=maxHP;
        }
      }
    }
    void lifeIcon()//HPの数値に応じてライフのアイコン数を変更します
    {
        if(HP<=4)life5.SetActive(false);
        if(HP<=3)life4.SetActive(false);
        if(HP<=2)life3.SetActive(false);
        if(HP<=1)life2.SetActive(false);
        if(HP<=0)life1.SetActive(false);
    }
}
