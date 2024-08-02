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
}
