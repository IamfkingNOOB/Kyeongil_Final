using BehaviourTree;

namespace Monster
{
    /// <summary>
    /// 몬스터의 공격을 구현하는 클래스입니다.
    /// </summary>
    public class Attack : Node
    {
        // 몬스터(Monster) 클래스
        private readonly Monster _monster;

        // 생성자
        public Attack(Monster monster)
        {
            _monster = monster;
        }

        public override NodeState Evaluate()
        {
            // 플레이어를 공격합니다.
            DoAttack();

            // 성공 상태를 반환합니다.
            return NodeState.SUCCESS;
        }

        // 몬스터의 공격을 구현합니다.
        private void DoAttack()
        {

        }
    }
}
