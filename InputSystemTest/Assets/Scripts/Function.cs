using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.Rendering;

public static partial class Function
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {//Wrapping:  �޼��带 ����Ҷ� ���� ���ϱ� ���� �������ϰų� �߰��ϴ°��� �����̶����.
     //���忡 �α׸� ���Խ�Ű�� �ʴ¹� -> ��ó������ �̸� (������ �ɺ�)
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {//Wrapping:  �޼��带 ����Ҷ� ���� ���ϱ� ���� �������ϰų� �߰��ϴ°��� �����̶����.
     //���忡 �α׸� ���Խ�Ű�� �ʴ¹� -> ��ó������ �̸� (������ �ɺ�)
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject �޾Ƽ� Text ������Ʈ ã�Ƽ� text�ʵ尪 �����ϴ� �Լ�

    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if(textComponent ==null || textComponent == default) { return; }
        
        textComponent.text = text;
    }
    //LoadScene �Լ��� �����Ѵ�.
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    //!!Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    public static GameObject FindChildobj(this GameObject targetobj_, string objName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for(int i = 0; i< targetobj_.transform.childCount; i++)
        {
            searchTarget = targetobj_.transform.GetChild(i).gameObject;
            if(searchTarget.name.Equals(objName_))
            {
                searchResult = searchTarget;
                return searchResult;
                //���� ã����� ������Ʈ�� ã�����
            }
            else
            {
                searchResult = FindChildobj(searchTarget, objName_);
                //���Լ����� ���Լ��� �θ��� ����Լ�.
                if (searchResult == null || searchResult == default) { /*pass*/}
                else { return searchResult; }
                //������Ʈ�� ��ã�����
            }
        }// loop: Ž�� Ÿ�� ������Ʈ�� �ڽĿ�����Ʈ������ŭ ��ȸ�ϴ� ����.
        return searchResult;
    }

    //! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ������Ʈ�� ã���ִ� �Լ�

    public static T FindchildComponent<T>(this GameObject targetobj_, string objName_) where T : Component
    {
        T searchResultComponent = default(T);
        GameObject searchResultobj = default(GameObject);

        searchResultobj = targetobj_.FindChildobj(objName_);
        if(searchResultobj != null || searchResultobj!= default)
        {
            searchResultComponent = searchResultobj.GetComponent<T>();
        }
        return searchResultComponent;
    }

    //���� ���� �̸��� �����Ѵ�.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! Ȱ��ȭ�� ���� ���� ��Ʈ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    public static GameObject GetRootobj(string objName_)
    {
        Scene activescene = SceneManager.GetActiveScene();
        GameObject[] rootObjs_ = activescene.GetRootGameObjects();
        GameObject targetobj_ = default;
        foreach(GameObject rootobj_ in rootObjs_)
        {
            if (rootobj_.name.Equals(objName_))
            {
                targetobj_ = rootobj_;
                return targetobj_;
            }
            else { continue; }
        }
        return targetobj_;
    }


    //�ι��͸� ���Ѵ�.

    public static Vector2 AddVector(this Vector3 origin, Vector2 addvector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addvector;
        return result;
    }

    // ������Ʈ�� �����ϴ� �� ���θ� Ȯ���ϴ� �Լ�
    public static bool IsValid<T>(this T target ) where  T : Component
    {
        if(target == null || target == default)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //����Ʈ�� ��ȿ���� ���θ� üũ�ϴ� �Լ�
    public static bool IsValid<T>(this List<T> target) 
    {
        bool isInvalid = (target == null || target == default);
        isInvalid = isInvalid || target.Count == 0;

        if (isInvalid == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
