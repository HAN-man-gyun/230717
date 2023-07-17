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
    {//Wrapping:  메서드를 사용할때 내가 편하기 위해 재정의하거나 추가하는것을 랩핑이라고함.
     //빌드에 로그를 포함시키지 않는법 -> 전처리기의 이름 (디파인 심볼)
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {//Wrapping:  메서드를 사용할때 내가 편하기 위해 재정의하거나 추가하는것을 랩핑이라고함.
     //빌드에 로그를 포함시키지 않는법 -> 전처리기의 이름 (디파인 심볼)
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

    //! GameObject 받아서 Text 컴포넌트 찾아서 text필드값 수정하는 함수

    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if(textComponent ==null || textComponent == default) { return; }
        
        textComponent.text = text;
    }
    //LoadScene 함수를 래핑한다.
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    //!!특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
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
                //내가 찾고싶은 오브젝트를 찾은경우
            }
            else
            {
                searchResult = FindChildobj(searchTarget, objName_);
                //내함수에서 내함수를 부르는 재귀함수.
                if (searchResult == null || searchResult == default) { /*pass*/}
                else { return searchResult; }
                //오브젝트를 못찾은경우
            }
        }// loop: 탐색 타겟 오브젝트의 자식오브젝트갯수만큼 순회하는 루프.
        return searchResult;
    }

    //! 특정 오브젝트의 자식 오브젝트를 서치해서 컴포넌트를 찾아주는 함수

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

    //현재 씬의 이름을 리턴한다.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! 활성화된 현재 씬의 루트오브젝트를 서치해서 찾아주는 함수
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


    //두백터를 더한다.

    public static Vector2 AddVector(this Vector3 origin, Vector2 addvector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addvector;
        return result;
    }

    // 컴포넌트가 존재하는 지 여부를 확인하는 함수
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
    //리스트가 유효한지 여부를 체크하는 함수
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
