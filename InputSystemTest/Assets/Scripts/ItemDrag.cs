using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemDrag : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler,IPointerClickHandler
{
    public Canvas UiCanvas = default;
    RectTransform itemRect = default;

    private GameObject sdPlayer = default;
    private bool isDragingOn = false;

    public delegate int MyLogFunc(object message);
    public MyLogFunc myLogFunc = default;

    private System.Action<object,int,int> myAction;
    private delegate void MyAction001(object message, int number1, int number2);

    private System.Func<float,float, int, int,string> myFunc;
    private delegate string MyFunction001(float f1,float f2, int i1, int i2);
    //<>의 마지막 타입이 리턴타입이다.
    //
    private void Awake()
    {
        UiCanvas = Function.GetRootobj("Canvas").GetComponent<Canvas>();
        itemRect = GetComponent<RectTransform>();

      /*  Debug.LogFormat("제대로 찾아오냐??{0}",UiCanvas.gameObject.FindChildobj("ForeImg").name);
        sdPlayer = Function.GetRootobj("Costume_02");
        GameObject yukoLeftEye = sdPlayer.FindChildobj("Mesh_Costume_02_Skin");
        Debug.LogFormat("Yuko is null {0}, Yuko's left eye is null : {1}", sdPlayer == null, yukoLeftEye == null);
        */
        
        isDragingOn = false;

        int number = 100;
        //myLogFunc myLogFunc = Debug.Log;
         myLogFunc = (object obj_) =>  //=> 형태를 람다식, 람다문이라고한다.
        {
            Debug.Log("이 로그가 잘 찍히는지 테스트");
            Debug.Log("넘겨받은 메시지는");
            Debug.Log(obj_);

            Debug.LogFormat("여기서 number 값을 정상적으로 사용할수있을까?{0}", number);

            return number;
        };
        
        myLogFunc("이제부터 이 로그 함수는 제껍니다.");

    }
    // Start is called before the first frame update
    void Start()
    {
        //itemRect.anchoredPosition += new Vector2(100f, 0f);
        itemRect.localPosition += new Vector3(100f, 0f,0f);
        //anchoredPosition은 Vector2 타입이고
        //localPosition은 Vector3 타입이다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("마우스 왼쪽버튼 클릭한 바로 그 순간");
        isDragingOn = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragingOn)
        {
            //itemRect.anchoredPosition += eventData.delta;
            //위코드는 아이콘이 살짝 늦게 따라온다 부드럽지 못하다.
            itemRect.anchoredPosition += (eventData.delta/UiCanvas.scaleFactor);
            //delta는 현재 마우스의 위치백터를 의미한다. 
            //드래그했을때 범위가
            Debug.LogFormat("아이콘을 움직일 준비가 되었음 -> {0}",eventData.delta);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragingOn = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("이거 함수 만든것 뿐인데 정말로 클릭이 될까???");
        //버튼대신 사용할수있다.
    }
    
}
