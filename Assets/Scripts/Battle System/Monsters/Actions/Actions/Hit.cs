using BehaviourTree;

namespace Monster
{
    /// <summary>
    /// 몬스터의 피격을 구현하는 클래스입니다.
    /// </summary>
    public class Hit : Node
    {
        // 몬스터(Monster) 클래스
        private readonly Monster _monster;

        // 생성자
        public Hit(Monster monster)
        {
            _monster = monster;
        }

        // 평가 함수
        public override NodeState Evaluate()
        {
            // 몬스터의 피격 연출을 실행합니다.
            DoHit();

            // 성공 상태를 반환합니다.
            return NodeState.SUCCESS;
        }

        // 몬스터의 피격 연출을 구현합니다.
        private void DoHit()
        {

        }
    }
}