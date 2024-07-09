using BehaviourTree;

namespace Monster
{
    public class Patrol : Node
    {
        // 몬스터(Monster) 클래스
        private readonly Monster _monster;

        // 생성자
        public Patrol(Monster monster)
        {
            _monster = monster;
        }

        // 평가 함수
        public override NodeState Evaluate()
        {
            // 순찰을 수행합니다.
            DoPatrol();

            // 성공 상태를 반환합니다.
            return NodeState.SUCCESS;
        }

        // 몬스터의 순찰을 구현합니다.
        private void DoPatrol()
        {

        }
    }
}
