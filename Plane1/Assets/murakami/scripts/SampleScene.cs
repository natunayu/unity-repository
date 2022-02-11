using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleScene : MonoBehaviour
{
    private string scenename;
    //このスクリプトでどのシーンを開いているかを保存しておく
    void Start () {
        scenename=SceneManager.GetActiveScene().name;
		Data.Instance.referer = scenename;
	}
}
