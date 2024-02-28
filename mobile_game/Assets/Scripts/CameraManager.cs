using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonManager<CameraManager>
{
    float CurrPosX = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        CurrPosX = CharacterManager.Instance.transform.position.x;
        transform.position = new Vector3(CurrPosX,0,-10);
    }
}
