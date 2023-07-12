using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]


    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    //아래의 코드는 위에서 래핑한 Log 코드와 동일하지만 뒤에 Object context매개변수로
    //글자의 색을 바꿀수 있다
    public static void Log001(object message, Object context)
    {
        Debug.Log(message, context);
    }

    [System.Diagnostics.Conditional("DEBUG_MOD")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }
    

    //! GameObject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textcomponent = target.GetComponent<Text>();
        if (textcomponent == null || textcomponent == default) { return; }

        textcomponent.text = text;
    }


    //! LoadScene 함수 래핑한다.
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! Player 가 방향키로 이동하능하게 한다
    //public static void PlayerMoveHelper()
    //{
    //    float x = Input.GetAxis("Horizontal"); //x축 값만 받아서 사용
    //    float z = Input.GetAxis("Vertical"); //y 라는 변수로 y축이동


    //2D 프로젝트에서 좌우 이동에 사용한 코드
    //float h = UnityEngine.Input.GetAxis("Horizontal");
    //player.transform.Translate(Vector2.right* h * playerSpeed * Time.deltaTime);

    //}




}
