using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    private Valkyrie[] playerValkyries = new Valkyrie[3];
    private List<Valkyrie> playerValkyriesByList = new();

    private void Start()
    {
        playerValkyriesByList[5] = new Valkyrie();
    }
}

public class PlayManager : Singleton<PlayManager>
{
    // 출전하는 발키리 (최소 1명 ~ 최대 3명)
    private List<Valkyrie> _playerValkyrie;

    // 현재 필드 위에 나와 있는 발키리
    private Valkyrie _valkyrieOnField;

    // 출전하고 있는 발키리를 서로 바꿉니다. QTE의 사용 여부에 따라 QTE 스킬을 발동합니다.
    public Valkyrie ChangeValkyrie(Valkyrie outField, bool isQTE)
    {
        (_valkyrieOnField, outField) = (outField, _valkyrieOnField);

        if (isQTE)
        {
            // outField.SpecialATK;
        }

        // 바뀐 발키리는 필드 밖으로 나갑니다.
        return _valkyrieOnField;
    }

    // 시공 단열을 열면, 시간의 흐름을 느리게 합니다.
    private IEnumerator OnTimeMastery(float duration, Animator animator)
    {
        // 전체적인 시간의 흐름이 느려집니다. 단, 플레이어는 영향을 받지 않습니다.
        Time.timeScale = 0.1f;
        animator.speed = (1.0f / Time.timeScale);

        // 일정 시간 동안 유지한 후,
        yield return new WaitForSecondsRealtime(duration);

        // 시간의 흐름을 정상화합니다.
        Time.timeScale = 1.0f;
        animator.speed = Time.timeScale;
    }

    // 필살기를 사용하면, 정체 영역을 활성화합니다.
    private IEnumerator OnUltimate(Animator animator)
    {
        // 정체 영역을 활성화합니다. 단, 플레이어는 영향을 받지 않습니다.
        Time.timeScale = 0.000001f; // 0으로 설정할 경우, 영향을 받지 않는 효과를 줄 수 없습니다.
        animator.speed = (1.0f / Time.timeScale);

        // 필살기 애니메이션을 종료할 때까지 기다립니다.
        yield return new WaitUntil(() =>
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Ultimate"))
            {
                return true;
            }
            else
            {
                return false;
            }
        });

        // 정체 영역을 비활성화합니다.
        Time.timeScale = 1.0f;
        animator.speed = Time.timeScale;
    }
}

public class ValkyrieOutField
{
    private Valkyrie _valkyrieOutField;

    private bool isQTE = false;

    private void OnClick()
    {
        _valkyrieOutField = PlayManager.Instance.ChangeValkyrie(_valkyrieOutField, isQTE);
    }
}
