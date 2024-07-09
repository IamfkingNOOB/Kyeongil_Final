using BehaviourTree;

namespace Monster
{
    public class Chase : Node
    {
        // 몬스터(Monster) 클래스
        private readonly Monster _monster;

        // 생성자
        public Chase(Monster monster)
        {
            _monster = monster;
        }

        public override NodeState Evaluate()
        {
            // 플레이어를 추적합니다.
            DoChase();

            // 성공 상태를 반환합니다.
            return NodeState.SUCCESS;
        }

        // 몬스터의 추적을 구현합니다.
        private void DoChase()
        {

        }
    }
}

