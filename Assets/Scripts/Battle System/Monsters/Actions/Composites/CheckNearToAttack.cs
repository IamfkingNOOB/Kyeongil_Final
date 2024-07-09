using BehaviourTree;
using Unity.VisualScripting;
using UnityEngine;

namespace Monster
{
    /// <summary>
    /// 플레이어가 공격 범위 내에 있는지를 판별하는 클래스입니다.
    /// </summary>
    public class CheckNearToAttack : Node
    {
        #region 변수

        private readonly Monster _monster; // 몬스터(Monster) 클래스
        private readonly Transform _playerTransform; // 플레이어의 위치 값

        #endregion 변수

        // 생성자
        public CheckNearToAttack(Monster Monster)
        {
            _monster = Monster;

            // 플레이어는 생성자의 호출 시점에서 FindAnyObjectByType 함수를 사용하여 찾습니다. (FindAnyObjectByType이 Find 함수 중 성능이 가장 뛰어납니다.)
            _playerTransform = Object.FindAnyObjectByType<BasePlayerController>().transform;
        }

        // 평가 함수
        public override NodeState Evaluate()
        {
            // 몬스터와 플레이어 사이의 거리를 계산합니다.
            float distance = CalculateDistance(_monster.transform.position, _playerTransform.position);

            // 플레이어가 몬스터의 공격 범위 안에 있는지를 확인하여, 그 결과에 따른 상태를 반환합니다.
            state = CheckPlayerInAttackRange(distance, _monster.AttackRange);
            return state;
        }

        #region 커스텀 함수

        /// <summary>
        /// 몬스터와 플레이어 사이의 거리를 계산합니다.
        /// </summary>
        /// <param name="monster">몬스터의 위치 값</param>
        /// <param name="player">플레이어의 위치 값</param>
        /// <returns>몬스터와 플레이어 사이의 거리 값</returns>
        private float CalculateDistance(Vector3 monster, Vector3 player)
        {
            // 거리 계산 시 y축(상하)는 계산하지 않습니다.
            Vector3 MonsterTransform = new Vector3(monster.x, 0, monster.z);
            Vector3 playerTransform = new Vector3(player.x, 0, player.z);

            // 적과 플레이어 사이의 거리를 계산하여, 반환합니다.
            float distance = Vector3.Distance(MonsterTransform, playerTransform);
            return distance;
        }

        /// <summary>
        /// 플레이어가 몬스터의 공격 범위 안에 있는지를 확인합니다.
        /// </summary>
        /// <param name="distance">몬스터와 플레이어 사이의 거리</param>
        /// <param name="range">몬스터의 공격 범위</param>
        /// <returns>노드의 상태 값</returns>
        private NodeState CheckPlayerInAttackRange(float distance, float range)
        {
            // 거리가 공격 범위 안일 경우,
            if (distance <= range)
            {
                // 성공 상태를 반환합니다.
                return NodeState.SUCCESS;
            }
            // 아닐 경우,
            else
            {
                // 실패 상태를 반환합니다.
                return NodeState.FAILURE;
            }
        }

        #endregion 커스텀 함수
    }
}