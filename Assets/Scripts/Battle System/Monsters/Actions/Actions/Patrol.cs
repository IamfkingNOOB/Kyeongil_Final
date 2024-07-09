using BehaviourTree;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Monster
{
    public class Patrol : Node
    {
        #region 변수

        private readonly Monster _monster; // 몬스터(Monster) 클래스

        private readonly Animator _animator; // 애니메이터
        private readonly int _patrol_AnimatorHash = Animator.StringToHash("Patrol"); // 사용할 애니메이터의 매개변수
        private readonly int _chase_AnimatorHash = Animator.StringToHash("Chase");

        private readonly NavMeshAgent _navMeshAgent; // 내비게이션

        private readonly Transform[] _patrolTransforms; // 순찰할 위치들
        private int _patrolIndex; // 순찰할 위치의 인덱스

        private bool _isWaiting = false; // 각 순찰 위치에 도착했을 때, 잠시 대기하기 위한 변수

        #endregion 변수

        // 생성자
        public Patrol(Monster monster)
        {
            _monster = monster;

            // GetComponent 함수는 비용이 크므로, 매 프레임마다 호출되는 평가 함수에서 호출하지 않도록 합니다.
            monster.TryGetComponent(out _animator);
            monster.TryGetComponent(out _navMeshAgent);

            // 순찰할 위치는 생성자의 호출 시점에서 FindAnyObjectByType 함수를 사용하여 찾습니다. (FindAnyObjectByType이 Find 함수 중 성능이 가장 뛰어납니다.)
            _patrolTransforms = Object.FindAnyObjectByType<StageManager>().PatrolTransforms;
        }

        // 평가 함수
        public override NodeState Evaluate()
        {
            Debug.Log("Patrol!");

            // 순찰을 수행합니다.
            DoPatrol();

            // 성공 상태를 반환합니다.
            return NodeState.SUCCESS;
        }

        #region 커스텀 함수

        // 몬스터의 순찰을 구현합니다.
        private void DoPatrol()
        {
            // 순찰하는 애니메이션을 재생합니다.
            _animator.SetBool(_chase_AnimatorHash, true);
            _animator.SetBool(_patrol_AnimatorHash, true);

            // 내비게이션을 활성화하여, 순찰 장소로 이동합니다.
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_patrolTransforms[_patrolIndex].position);

            // 순찰 목적지까지 이동했다면,
            if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_isWaiting)
            {
                // 일정 시간 동안 기다립니다. (약 5초)
                _monster.StartCoroutine(Wait(5));
            }
        }

        // 한 순찰 장소에 도착했을 때, 일정 시간 동안 기다립니다.
        private IEnumerator Wait(float time)
        {
            // 코루틴을 시작합니다.
            _isWaiting = true;

            // 잠시 순찰하는 애니메이션을 정지합니다.
            _animator.SetBool(_patrol_AnimatorHash, false);

            // 일정 시간만큼 대기합니다.
            yield return new WaitForSeconds(time);

            // 다음 순찰 장소를 지정합니다.
            _patrolIndex = ++_patrolIndex % _patrolTransforms.Length;

            // 코루틴을 종료합니다.
            _isWaiting = false;
        }

        #endregion 커스텀 함수
    }
}
