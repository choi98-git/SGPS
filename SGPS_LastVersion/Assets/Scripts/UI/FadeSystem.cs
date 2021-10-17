using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSystem : MonoBehaviour
{
    public string sceneName1 = "GameOver";
    public static bool isFade = false;

    public Image Panel;
    float time = 0f;
    // 0부터 1까지 deltatime을 계속 더하여 지속시간으로 사용

    float F_time = 1f;

    void Update()
    {
        if (StatusHP.currentHP <= 0)
        {
            Fade();
            DeadNext();
        }
    }

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        isFade = true;
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1f) //이미지의 알파값이 1보다 작으면 계속 반복
        {
            time += Time.deltaTime / F_time;
            // 매 프레임마다 deltatime을 F_time으로 나눈 값을 time에 누적시킨다.
            alpha.a = Mathf.Lerp(0, 1, time);
            // Mathf.Lerp를 통해 0부터 1까지 매끄럽게 변환
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }

    public void DeadNext()
    {
        SceneManager.LoadScene(sceneName1);
    }
}
