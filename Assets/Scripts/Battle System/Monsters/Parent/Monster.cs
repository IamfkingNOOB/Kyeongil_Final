using ScriptableObjectData;
using UnityEngine;

namespace Monster
{
    public class Monster : MonoBehaviour
    {
        #region 변수

        [SerializeField] private MonsterData _data;

        #endregion 변수

        #region 프로퍼티

        public MonsterData Data
        {
            get { return _data; }
            protected set { _data = value; }
        }

        #endregion 프로퍼티

        #region 유니티 충돌 이벤트

        // 캐릭터의 공격 충돌체에 충돌했을 경우, 피격 상태가 됩니다.
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player Attacker"))
            {
                _data.IsHit = true;
            }
        }

        // 충돌한 것이 없을 경우, 피격 상태를 해제합니다.
        private void OnTriggerExit(Collider other)
        {
            _data.IsHit = false;
        }

        #endregion 유니티 충돌 이벤트
    }
}
