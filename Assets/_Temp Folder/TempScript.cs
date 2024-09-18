using UnityEngine;

public class TempScript : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0.00001f; // 0으로 설정할 경우, 영향을 받지 않는 설정을 하기 매우 어려워진다.
            animator.speed = (Time.timeScale == 0.0f) ? 1.0f : (1.0f / Time.timeScale);

            Debug.Log($"Time.unscaledDeltaTime = {Time.unscaledDeltaTime}");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1.0f;
            animator.speed = (1.0f / Time.timeScale);
        }
    }
}
