using BehaviourTree;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// 몬스터(Monster)의 행동 트리(Behaviour Tree)를 정의하는 클래스입니다.
    /// </summary>
    public class MonsterBT : MonoBehaviour
    {
        #region 변수

        // 몬스터(Monster) 객체
        private Monster _monster;

        // 뿌리(Root) 노드
        private Node _rootNode;

        #endregion 변수

        #region 유니티 생명 주기 함수

        // Awake
        private void Awake()
        {
            // 생성 시 자신의 Monster(를 상속받는 클래스) 스크립트를 컴포넌트에서 참조합니다.
            if (TryGetComponent(out _monster))
            {
                // 행동 트리를 작성한다.
                _rootNode = SetBT();
            }
        }

        // Update
        private void Update()
        {
            // 매 프레임마다 상태를 평가합니다.
            _rootNode?.Evaluate();
        }

        #endregion 유니티 생명 주기 함수

        #region 커스텀 함수

        // 행동 트리를 작성합니다.
        private Node SetBT()
        {
            /*
													                 Root
													                   ┃
												                   Selector
				             ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
			             Selector                                                                             Selector
		            ┏━━━━━━━━┻━━━━━━━━┓                                       ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━┓
	            Sequence          Sequence                                Sequence                            Sequence       Patrol
	            ┏━━━┻━━━━┓       ┏━━━━┻━━━━┓            ┏━━━━━━━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━━━┓            ┏━━━━━━┻━━━━━┓
            CheckDead → Die  CheckHit → GetHit  CheckNearToAttack → CheckForwardToAttack → Attack  CheckNearToChase → Chase
            */

            // 0. 뿌리 노드(Selector)
            Node node = new Selector(new List<Node>
            {
                new Selector(new List<Node>()
                {
                    // 1. 죽음 상태 여부 확인
                    new Sequence(new List<Node>()
                    {
                        new CheckDead(_monster), new Die(_monster)
                    }),

                    // 2. 피격 상태 여부 확인
                    new Sequence(new List<Node>()
                    {
                        new CheckHit(_monster), new Hit(_monster)
                    })
                }),

                new Selector(new List<Node>()
                {
                    // 4. 공격 가능 상태 여부 확인
                    new Sequence(new List<Node>()
                    {
                        new CheckNearToAttack(_monster), new CheckForwardToAttack(_monster), new Attack(_monster)
                    }),

                    // 5. 추적 가능 상태 여부 확인
                    new Sequence(new List<Node>()
                    {
                        new CheckNearToChase(_monster), new Chase(_monster)
                    }),

                    // 6. 순찰
                    new Patrol(_monster)
                })
            });

            // 작성한 노드를 반환합니다.
            return node;
        }

        #endregion 커스텀 함수
    }
}
