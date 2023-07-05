using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

// ȭ�� ����
public enum FadeState { FadeIn = 0, FadeOut, FadeInOut, FadeLoop };

// �� ��ȯ��, ȭ�� ������ ���� Ŭ����
public class FadeEffect : MonoBehaviour
{
    // �� ��ȯ�� �ɸ��� �ð�
    [SerializeField]
    [Range(0.01f, 10f)]
    private float           fadeTime;
    // �� ��ȯ �׷��� ( �̹����� ������ ��� ��ȭ�� �������� ���� �׷��� )
    [SerializeField]
    private AnimationCurve  fadeCurve;
    // �̹���
    private Image           image;
    // ȭ�� ����
    public FadeState        fadeState;

    // �� ���۽� �۵�
    private void Awake()
    {
        image = GetComponent<Image>();
        OnFade();
    }

    // fadeState�� ���¿� ���� ���� ������ ���� �����ϴ� �Լ�
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

    // ������ ���������� �ϱ����� �Լ�.
    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(1, 0));

            yield return StartCoroutine(Fade(0, 1));

            // 1ȸ�� ����ϴ� ������ �� break;
            if(fadeState == FadeState.FadeInOut)
            {
                break;
            }
        }
    }

    // ���� �Լ�.
    private IEnumerator Fade(float start, float end)
    {
        float currentTime   = 0.0f;
        float percent       = 0.0f;
        
        while(percent < 1)
        {
            currentTime +=      Time.deltaTime;
            percent =           currentTime / fadeTime;

            // start���� end���� fadeTime �ð� ���� ��ȭ��Ų��.
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