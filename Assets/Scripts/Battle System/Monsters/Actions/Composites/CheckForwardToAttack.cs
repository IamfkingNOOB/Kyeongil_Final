using BehaviourTree;
using UnityEngine;

namespace Monster
{
    /// <summary>
    /// 몬스터가 플레이어를 똑바로 바라보고 있는지를 판별하는 클래스입니다.
    /// </summary>
    public class CheckForwardToAttack : Node
    {
        #region 변수

        private readonly Monster _monster; // 몬스터(Monster) 클래스
        private readonly Animator _animator; // 애니메이터
        private readonly Transform _playerTransform; // 플레이어의 위치 값

        #endregion 변수

        // 생성자
        public CheckForwardToAttack(Monster monster)
        {
            _monster = monster;

            // GetComponent 함수는 비용이 크므로, 매 프레임마다 호출되는 평가 함수에서 호출하지 않도록 합니다.
            monster.TryGetComponent(out _animator);

            // 플레이어는 생성자의 호출 시점에서 FindAnyObjectByType 함수를 사용하여 찾습니다. (FindAnyObjectByType이 Find 함수 중 성능이 가장 뛰어납니다.)
            _playerTransform = Object.FindAnyObjectByType<BasePlayerController>().transform;
        }

        // 평가 함수
        public override NodeState Evaluate()
        {
            // 현재 공격 애니메이션이 재생 중인지를 판별합니다.
            bool isAnimRunning = CheckPlayingAttackAniamtion(_animator);

            // 재생 중이 아니라면,
            if (!isAnimRunning)
            {
                // 몬스터가 캐릭터를 바라보도록 회전합니다.
                state = TurnToPlayer(_monster.transform.position, _playerTransform.position);
            }
            // 재생 중이라면,
            else
            {
                // 공격 상태를 유지합니다.
                state = NodeState.SUCCESS;
            }

            // 상태를 반환합니다.
            return state;
        }

        /// <summary>
        /// 현재 공격 애니메이션이 재생 중인지를 판별합니다.
        /// </summary>
        /// <param name="animator">몬스터의 애니메이터</param>
        /// <returns>공격 애니메이션의 재생 여부</returns>
        private bool CheckPlayingAttackAniamtion(Animator animator)
        {
            bool isAnimRunning = false;

            // 만약 현재 재생 중인 애니메이션의 태그(Tag)가 "Attack"인지의 여부를 반환합니다.
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                isAnimRunning = true;
            }

            return isAnimRunning;
        }

        /// <summary>
        /// 몬스터가 플레이어를 바라보도록 회전합니다.
        /// </summary>
        /// <param name="monster">몬스터의 위치 값</param>
        /// <param name="player">플레이어의 위치 값</param>
        /// <returns>회전에 따른 노드의 상태 값</returns>
        private NodeState TurnToPlayer(Vector3 monster, Vector3 player)
        {
            // 공격을 수행하기 전, 몬스터가 플레이어를 바라보고 있어야 한다.
            Vector3 playerPos = new Vector3(player.x, monster.y, player.z); // 플레이어의 위치; y 값(상하)은 무시합니다.
            Vector3 MonsterPos = monster; // 적의 위치

            // 몬스터와 플레이어 사이의 각도
            float angle = Vector3.Angle(_monster.transform.forward, playerPos - MonsterPos);

            if (angle > 10) // 그 각도가 약 좌우 각 10도 이상일 경우, (바라보고 있지 않다면)
            {
                // 플레이어를 바라보게 회전시킵니다.
                Quaternion turnTo = Quaternion.LookRotation(playerPos - MonsterPos);
                _monster.transform.rotation = Quaternion.Slerp(_monster.transform.rotation, turnTo, 2 * Time.deltaTime);

                // 10도 미만일 때까지 계속합니다. (RUNNING)
                return NodeState.RUNNING;
            }
            else
            {
                // 아니라면 공격으로 넘어갑니다. (SUCCESS)
                return NodeState.SUCCESS;
            }
        }
    }
}