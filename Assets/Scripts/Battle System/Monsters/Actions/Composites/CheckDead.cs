using BehaviourTree;

namespace Enemy
{
    /// <summary>
    /// 몬스터가 죽었는지를 판별하는 클래스입니다.
    /// </summary>
    public class CheckDead : Node
    {
        #region 변수

        // 몬스터(Monster) 클래스
        private readonly Monster _monster;

        #endregion 변수

        #region 생성자

        public CheckDead(Monster monster)
        {
            _monster = monster;
        }

        #endregion 생성자

        #region 행동 트리 함수

        // 평가 함수
        public override NodeState Evaluate()
        {
            // 몬스터의 체력이 0일 경우 죽은 것입니다.
            bool isDead = (_monster.Data.HP <= 0);

            // 죽은 상태일 경우 성공 상태를, 아닐 경우 실패 상태를 반환합니다.
            state = (isDead) ? NodeState.SUCCESS : NodeState.FAILURE;
            return state;
        }

        #endregion 행동 트리 함수
    }
}
