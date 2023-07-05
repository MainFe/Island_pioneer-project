using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

// 화면 상태
public enum FadeState { FadeIn = 0, FadeOut, FadeInOut, FadeLoop };

// 씬 전환시, 화면 연출을 위한 클래스
public class FadeEffect : MonoBehaviour
{
    // 씬 전환시 걸리는 시간
    [SerializeField]
    [Range(0.01f, 10f)]
    private float           fadeTime;
    // 씬 전환 그래프 ( 이미지의 투명도가 어떻게 변화할 것인지에 대한 그래프 )
    [SerializeField]
    private AnimationCurve  fadeCurve;
    // 이미지
    private Image           image;
    // 화면 상태
    public FadeState        fadeState;

    // 씬 시작시 작동
    private void Awake()
    {
        image = GetComponent<Image>();
        OnFade();
    }

    // fadeState의 상태에 따라 무슨 연출을 할지 구분하는 함수
    public void OnFade()
    {

        switch (fadeState) 
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;
            case FadeState.FadeInOut:
            case FadeState.FadeLoop:
                StartCoroutine(FadeInOut());
                break;
        }
    }

    // 연출을 연속적으로 하기위한 함수.
    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));

            yield return StartCoroutine(Fade(0, 1));

            // 1회만 재생하는 상태일 때 break;
            if(fadeState == FadeState.FadeInOut)
            {
                break;
            }
        }
    }

    // 연출 함수.
    private IEnumerator Fade(float start, float end)
    {
        float currentTime   = 0.0f;
        float percent       = 0.0f;
        
        while(percent < 1)
        {
            currentTime +=      Time.deltaTime;
            percent =           currentTime / fadeTime;

            // start부터 end까지 fadeTime 시간 동안 변화시킨다.
            Color color =       image.color;
            color.a =           Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color =       color;

            yield return null;
        }
    }
}

/*[CustomEditor(typeof(FadeEffect))]
public class Edit : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        FadeEffect t = (FadeEffect)target;
        t.fadeState = (FadeState)EditorGUILayout.EnumPopup("type", t.fadeState);
    }
}*/