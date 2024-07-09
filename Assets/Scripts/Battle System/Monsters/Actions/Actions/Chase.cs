using BehaviourTree;
using UnityEngine;
using UnityEngine.AI;

namespace Monster
{
    public class Chase : Node
    {
        #region 변수

        private readonly Monster _monster; // 몬스터(Monster) 클래스

        private readonly Animator _animator; // 애니메이터
        private readonly int _chase_AnimatorHash = Animator.StringToHash("Chase"); // 사용할 애니메이터의 매개변수
        private readonly int _attack_AnimatorHash = Animator.StringToHash("Attack");

        private readonly NavMeshAgent _navMeshAgent; // 내비게이션

        private readonly Transform _playerTransform; // 플레이어의 위치 값

        #endregion 변수

        // 생성자
        public Chase(Monster monster)
        {
            _monster = monster;

            // GetComponent 함수는 비용이 크므로, 매 프레임마다 호출되는 평가 함수에서 호출하지 않도록 합니다.
            monster.TryGetComponent(out _animator);
            monster.TryGetComponent(out _navMeshAgent);

            // 플레이어는 생성자의 호출 시점에서 FindAnyObjectByType 함수를 사용하여 찾습니다. (FindAnyObjectByType이 Find 함수 중 성능이 가장 뛰어납니다.)
            _playerTransform = Object.FindAnyObjectByType<BasePlayerController>().transform;
        }

        // 평가 함수
        public override NodeState Evaluate()
        {
            Debug.Log("Chase!");

            // 플레이어를 추적합니다.
            DoChase();

            // 성공 상태를 반환합니다.
            return NodeState.SUCCESS;
        }

        #region 커스텀 함수

        // 몬스터의 추적을 구현합니다.
        private void DoChase()
        {
            // 현재 공격 애니메이션이 종료되지 않았을 경우, 추적 행동을 하지 않는다. (후 딜레이 적용)
            if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                return;

            // 추적 애니메이션을 재생합니다.
            _animator.SetBool(_attack_AnimatorHash, false);
            _animator.SetBool(_chase_AnimatorHash, true);

            // 내비게이션을 활성화하여, 플레이어를 추적합니다.
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_playerTransform.position);
        }

        #endregion 커스텀 함수
    }
}

