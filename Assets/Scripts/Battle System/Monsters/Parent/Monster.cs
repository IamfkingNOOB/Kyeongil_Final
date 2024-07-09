using UnityEngine;

namespace Monster
{
    public class Monster : MonoBehaviour
    {
        #region 변수

        public int HP { get; private set; } = 0; // HP
        
        public bool IsHit { get; private set; } = false; // 피격 여부

        public float ChaseRange { get; private set; } = 0; // 추적 범위

        public float AttackRange { get; private set; } = 0; // 공격 범위

        #endregion 변수

        #region 유니티 충돌 이벤트

        // 플레이어의 공격에 피격(충돌)했을 경우, 피격 상태가 됩니다.
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player Attacker"))
            {
                IsHit = true;
            }
        }

        // 충돌 상태를 벗어날 경우, 피격 상태를 해제합니다.
        private void OnTriggerExit(Collider other)
        {
            IsHit = false;
        }

        #endregion 유니티 충돌 이벤트
    }
}