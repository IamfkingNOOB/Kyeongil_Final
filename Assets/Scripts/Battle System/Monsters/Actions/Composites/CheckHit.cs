using BehaviourTree;

namespace Monster
{
    /// <summary>
    /// 몬스터가 피격했는지를 판별하는 클래스입니다.
    /// </summary>
    public class CheckHit : Node
    {
        // 몬스터(Monster) 클래스
        private readonly Monster _monster;

        // 생성자
        public CheckHit(Monster monster)
        {
            _monster = monster;
        }

        // 평가 함수
        public override NodeState Evaluate()
        {
            // 몬스터가 플레이어의 공격에 의해 충돌했을 경우, 피격한 것입니다.
            bool isHit = _monster.Data.IsHit;

            // 피격 상태일 경우 성공 상태를, 아닐 경우 실패 상태를 반환합니다.
            state = (isHit) ? NodeState.SUCCESS : NodeState.FAILURE;
            return state;
        }
    }
}
