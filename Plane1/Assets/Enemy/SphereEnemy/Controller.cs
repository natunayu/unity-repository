using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject target;
	[SerializeField] private float speed;

	private void Update()
	{
		// 対象物と自分自身の座標からベクトルを算出してQuaternion(回転値)を取得
		Vector3 vector3 = target.transform.position - this.transform.position;
		// もし上下方向の回転はしないようにしたければ以下のようにする。
		// vector3.y = 0f;

		// Quaternion(回転値)を取得
		Quaternion quaternion = Quaternion.LookRotation(vector3);
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, Time.deltaTime * speed);
	}	
}