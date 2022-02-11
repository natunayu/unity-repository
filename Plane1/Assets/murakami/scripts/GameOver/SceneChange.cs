using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()//さっきの画面へ
    {
        if (Data.Instance.referer == "SampleScene") {
    		FadeManager.Instance.LoadScene ("SampleScene", 2.0f);	
		}    
    }
    public void Home()//ホーム画面へ
    {
        FadeManager.Instance.LoadScene ("SampleScene", 2.0f);
    }
    public void Setting()//設定画面へ
    {
        FadeManager.Instance.LoadScene ("SampleScene", 2.0f);
    }
}
