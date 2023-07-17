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
    //<>�� ������ Ÿ���� ����Ÿ���̴�.
    //
    private void Awake()
    {
        UiCanvas = Function.GetRootobj("Canvas").GetComponent<Canvas>();
        itemRect = GetComponent<RectTransform>();

      /*  Debug.LogFormat("����� ã�ƿ���??{0}",UiCanvas.gameObject.FindChildobj("ForeImg").name);
        sdPlayer = Function.GetRootobj("Costume_02");
        GameObject yukoLeftEye = sdPlayer.FindChildobj("Mesh_Costume_02_Skin");
        Debug.LogFormat("Yuko is null {0}, Yuko's left eye is null : {1}", sdPlayer == null, yukoLeftEye == null);
        */
        
        isDragingOn = false;

        int number = 100;
        //myLogFunc myLogFunc = Debug.Log;
         myLogFunc = (object obj_) =>  //=> ���¸� ���ٽ�, ���ٹ��̶���Ѵ�.
        {
            Debug.Log("�� �αװ� �� �������� �׽�Ʈ");
            Debug.Log("�Ѱܹ��� �޽�����");
            Debug.Log(obj_);

            Debug.LogFormat("���⼭ number ���� ���������� ����Ҽ�������?{0}", number);

            return number;
        };
        
        myLogFunc("�������� �� �α� �Լ��� �����ϴ�.");

    }
    // Start is called before the first frame update
    void Start()
    {
        //itemRect.anchoredPosition += new Vector2(100f, 0f);
        itemRect.localPosition += new Vector3(100f, 0f,0f);
        //anchoredPosition�� Vector2 Ÿ���̰�
        //localPosition�� Vector3 Ÿ���̴�.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("���콺 ���ʹ�ư Ŭ���� �ٷ� �� ����");
        isDragingOn = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragingOn)
        {
            //itemRect.anchoredPosition += eventData.delta;
            //���ڵ�� �������� ��¦ �ʰ� ����´� �ε巴�� ���ϴ�.
            itemRect.anchoredPosition += (eventData.delta/UiCanvas.scaleFactor);
            //delta�� ���� ���콺�� ��ġ���͸� �ǹ��Ѵ�. 
            //�巡�������� ������
            Debug.LogFormat("�������� ������ �غ� �Ǿ��� -> {0}",eventData.delta);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragingOn = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�̰� �Լ� ����� ���ε� ������ Ŭ���� �ɱ�???");
        //��ư��� ����Ҽ��ִ�.
    }
    
}
