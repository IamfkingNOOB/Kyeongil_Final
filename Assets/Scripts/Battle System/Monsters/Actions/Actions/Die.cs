using BehaviourTree;
using UnityEngine;
using UnityEngine.AI;

namespace Monster
{
    /// <summary>
    /// 몬스터의 죽음을 구현하는 클래스입니다.
    /// </summary>
    public class Die : Node
    {
        #region 변수

        private readonly Monster _monster; // 몬스터(Monster) 클래스

        private readonly Animator _animator; // 애니메이터
        private readonly int _die_AnimatorHash = Animator.StringToHash("Die"); // 사용할 애니메이터의 매개변수

        private readonly NavMeshAgent _navMeshAgent; // 내비게이션

        #endregion 변수

        // 생성자
        public Die(Monster monster)
        {
            _monster = monster;

            // GetComponent 함수는 비용이 크므로, 매 프레임마다 호출되는 평가 함수에서 호출하지 않도록 합니다.
            bool a = monster.TryGetComponent(out _animator);
            Debug.Log($"a = {a}");

            monster.TryGetComponent(out _navMeshAgent);
        }

        // 평가 함수
        public override NodeState Evaluate()
        {
            // 몬스터가 죽는 연출을 실행합니다.
            DoDie();

            // 성공 상태를 반환합니다.
            return NodeState.SUCCESS;
        }

        // 몬스터가 죽는 연출을 구현합니다.
        private void DoDie()
        {
            // 내비게이션을 비활성화합니다.
            _navMeshAgent.isStopped = true;

            // 죽음 애니메이션을 재생합니다.
            _animator.SetTrigger(_die_AnimatorHash);
        }
    }
}
