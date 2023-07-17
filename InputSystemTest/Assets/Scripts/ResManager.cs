using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResManager : MonoBehaviour
{
    public ItemDrag itemDrag = default;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ResManager는 Assets 폴더 하위에서 리소스를 모두 찾아오는 역할.");
        Debug.Log("1번째로 Call해야함.");
        //itemDrag.myLogFunc("ResManager에서 로그찍는중...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
