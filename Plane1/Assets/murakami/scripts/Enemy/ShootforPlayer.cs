using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootforPlayer : MonoBehaviour
{

    // https://futabazemi.net/notes/unity-enemy_shot3d/
    
    public GameObject player;
    public GameObject ball;
    public float ballSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player.transform);
        StartCoroutine("BallShot"); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }

    IEnumerator BallShot()
    {
        while (true) {
        var shot = Instantiate(ball, transform.position, Quaternion.identity);
        shot.GetComponent<Rigidbody>().velocity = transform.forward.normalized * ballSpeed;
        yield return new WaitForSeconds(1.0f);
        }
    }
}
