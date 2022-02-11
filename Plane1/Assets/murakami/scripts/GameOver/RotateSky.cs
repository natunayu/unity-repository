using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed = 1f;
    //　スカイボックスのマテリアル
    private Material skyboxMaterial;

    // Start is called before the first frame update
    void Start()
    {
        skyboxMaterial = RenderSettings.skybox;
        skyboxMaterial.SetFloat("_Rotation",30.0f);
    }

    // Update is called once per frame
    void Update()
    {
        skyboxMaterial.SetFloat("_Rotation", Mathf.Repeat(skyboxMaterial.GetFloat("_Rotation") - rotateSpeed* Time.deltaTime, 360f));
    }
}
