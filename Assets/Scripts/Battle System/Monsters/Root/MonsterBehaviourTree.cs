using BehaviourTree;
using System.Collections.Generic;
using UnityEngine;

namespace Monster
{
    // 몬스터(Monster)의 행동 트리(Behaviour Tree) 클래스
    public class MonsterBehaviourTree : MonoBehaviour
    {
        // 몬스터(Monster) 객체
        private Monster _monster;

        // 뿌리(Root) 노드
        private Node rootNode;

        private void Awake()
        {
            // 생성 시 자신의 Monster(를 상속받는 클래스) 스크립트를 컴포넌트에서 참조합니다.
            TryGetComponent(out _monster);

            // 행동 트리를 작성한다.
            rootNode = SetBehaviourTree();
        }

        private void Update()
        {
            // 매 프레임마다 상태를 평가합니다.
            rootNode.Evaluate();
        }

        // 행동 트리를 작성합니다.
        public Node SetBehaviourTree()
        {
            /*
                                                   Root
                                                     ┃
                                                 Selector
                                 ┏━━━━━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━━━━┓
                             Sequence                               Selector
                        ┏━━━━━━━━┻━━━━━━━━┓            ┏━━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━━┓
                CheckIsPossessed → BeingPossessed  Sequence                          Selector
                                                  ┏━━━━┻━━━━┓       ┏━━━━━━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
                                             CheckIsDead → Die  Sequence                                                         Selector
                                                              ┏━━━━━┻━━━━━┓                      ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━━━━━━━━━━━━━┓
                                                         CheckGetHit → GetHit                Sequence                            Sequence                   Patrol
                                                                           ┏━━━━━━━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━━━┓            ┏━━━━━━┻━━━━━┓
                                                                   CheckNearToAttack → CheckForwardToAttack → Attack  CheckNearToChase → Chase


            아래와 같이 변경.

													                Root
													                  ┃
												                  Selector
					                ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
				                Selector                                                           Selector
		                 ┏━━━━━━━━━━┻━━━━━━━━━━┓                          ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┻━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
	                 Sequence              Sequence                   Sequence                                                  Selector
	                 ┏━━━┻━━━━━┓        ┏━━━━━━┻━━━━┓            ┏━━━━━━━━┻━━━━━━━━┓            ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━┓
                CheckIsDead → Die  CheckGetHit → GetHit  CheckIsPossessed → BeingPossessed  Sequence                            Sequence       Patrol
														                  ┏━━━━━━━━━━━━━━━━━━━━━╋━━━━━━━━━━━━━━━┓            ┏━━━━━━┻━━━━━┓
												                  CheckNearToAttack → CheckForwardToAttack → Attack  CheckNearToChase → Chase



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
    }
}