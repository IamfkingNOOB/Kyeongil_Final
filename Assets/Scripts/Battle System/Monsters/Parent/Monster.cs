using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    /// <summary>
    /// 몬스터가 가지는 속성 값을 정의하는 클래스입니다.
    /// </summary>
    public class MonsterData
    {
        public int HP { get; set; } // 체력
        public float ChaseRange { get; set; } // 추적 범위
        public int AttackCount { get; set; } // 공격 모션의 개수
        public float AttackRange { get; set; } // 공격 범위
        public bool IsSuperArmor { get; set; } // 슈퍼 아머 여부
        public bool IsHit { get; set; } // 피격 여부
    }

    /// <summary>
    /// 몬스터의 기본 행동 및 이벤트를 정의하는 클래스입니다.
    /// </summary>
    public class Monster : MonoBehaviour
    {
        #region 변수

        // 몬스터의 속성 값 데이터
        private MonsterData _data;

        // 애니메이터 조정을 위한 컴포넌트
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        #endregion 변수

        #region 프로퍼티

        public MonsterData Data
        {
            get { return _data; }
            protected set { _data = value; }
        }

        #endregion 프로퍼티

        #region 유니티 생명 주기 함수

        // Awake
        private void Awake()
        {
            TryGetComponent(out _animator);
            if (TryGetComponent(out _navMeshAgent))
            {
                // 애니메이터의 루트 모션을 사용하여 움직일 것이므로, 내비게이션으로의 위치 동기화를 거부합니다.
                _navMeshAgent.updatePosition = false;
            }
        }

        // Update
        private void Update()
        {

        }

        #endregion 유니티 생명 주기 함수

        #region 유니티 이벤트 함수

        // 충돌 이벤트 (트리거)
        private void OnTriggerEnter(Collider other)
        {
            // 플레이어의 공격에 충돌했을 때,
            if (other.CompareTag("Player Attacker"))
            {
                // 피격 상태가 됩니다.
                _data.IsHit = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // 플레이어의 공격이 끝났을 때,
            if (other.CompareTag("Player Attacker"))
            {
                // 피격 상태를 해제합니다.
                _data.IsHit = false;
            }
        }

        // 애니메이터의 루트 모션(Root Motion)과 내비게이션(NavMesh)을 동기화하기 위한 이벤트 함수
        private void OnAnimatorMove()
        {
            // NavMeshAgent의 위치를 Animator의 Root Position에 동기화시킨다.
            Vector3 position = _animator.rootPosition;
            position.y = _navMeshAgent.nextPosition.y;
            transform.position = position;
            _navMeshAgent.nextPosition = transform.position;
        }

        #endregion 유니티 이벤트 함수

        #region 커스텀 함수

        #endregion 커스텀 함수
    }
}
