using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{

    // 中心点
    [SerializeField] private Vector3 _center = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.up;

    // 円運動周期
    [SerializeField] private float _period = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 中心点centerの周りを、軸axisで、period周期で円運動
        transform.RotateAround(
            _center,
            _axis,
            360 / _period * Time.deltaTime
        );
    }
}
