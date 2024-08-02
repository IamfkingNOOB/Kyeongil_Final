using UnityEngine;

/// <summary>
/// 발키리의 공격에 대한 충돌 이벤트를 정의하는 클래스입니다.
/// </summary>
public class ValkyrieAttacker : MonoBehaviour
{
    // 컨트롤러를 가진 플레이어 객체
    private BasePlayerController _player;

    // 시작하기 전,
    private void Awake()
    {
        // 플레이어 객체를 부모로부터 찾습니다.
        _player = GetComponentInParent<BasePlayerController>();
    }

    // 충돌 이벤트를 정의합니다. 물리적인 효과를 고려하지 않으므로, 트리거(Trigger)를 사용합니다.
    private void OnTriggerEnter(Collider other)
    {
        // 만약 충돌한 대상이 몬스터일 경우,
        if (other.CompareTag("Monster"))
        {
            // SP를 회복한다.
            // _player.SP += 1;
        }
    }

    private void SetDamage()
    {
        // 대미지 계산 공식!
        // 스킬 대미지: 공격력 * 스킬 계수
        // 물리 대미지 증가 공식: 공격력 * 스킬 계수 * ( 1 + 댐증 + 댐증 + 댐증 + ... )
        // 크리 대미지: 200%
        // 방어력: 방어력 / 방어력 + 1000
        // 상성: +-30%
        // 회심: 회심 / 75 + (레벨 * 5)

        float critialPercentage = (_player._valkyrieData.CRT / 75) + (_player._valkyrieData.Level * 5);
        bool isCritical = (Random.value < critialPercentage) ? true : false;

        int totalDamage = _player._valkyrieData.ATK;
    }
}
