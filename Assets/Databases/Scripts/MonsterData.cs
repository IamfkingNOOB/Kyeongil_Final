using UnityEngine;

namespace ScriptableObjectData
{
    // 몬스터에 대한 데이터
    [CreateAssetMenu]
    public class MonsterData : ScriptableObject
    {
        #region 변수

        [SerializeField] private int _hp; // HP
        [SerializeField] private bool _isHit; // 피격 여부
        [SerializeField] private bool _isSuperArmor; // 슈퍼 아머 여부
        [SerializeField] private float _chaseRange; // 추적 범위
        [SerializeField] private float _attackRange; // 공격 범위
        [SerializeField] private int _attackCount; // 공격 개수

        #endregion 변수

        #region 프로퍼티

        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public bool IsHit
        {
            get { return _isHit; }
            set { _isHit = value; }
        }

        public bool IsSuperArmor
        {
            get { return _isSuperArmor; }
            set { _isSuperArmor = value; }
        }

        public float ChaseRange
        {
            get { return _chaseRange; }
            set { _chaseRange = value; }
        }

        public float AttackRange
        {
            get { return _attackRange; }
            set { _attackRange = value; }
        }

        public int AttackCount
        {
            get { return _attackCount; }
            set { _attackCount = value; }
        }

        #endregion 프로퍼티
    }
}