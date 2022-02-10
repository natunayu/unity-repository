using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyEnemy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("destroyBullet");
    }
 
    // Update is called once per frame
    void Update()
    {
 
    }
 
    private IEnumerator destroyBullet()
    {   
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
 
    private void OnCollisionEnter(Collision collision)
    {
      //  if(collision.gameObject.tag!="Enemy")Destroy(gameObject);
    }
}
