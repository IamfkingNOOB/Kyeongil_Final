using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 죽음(Dead) 상태를 관리하기 위한 클래스입니다.
/// </summary>
public class PlayerDieState : BasePlayerState
{
    #region 생성자

    public PlayerDieState(BasePlayerController controller) : base(controller) { }

    #endregion 생성자

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        // 죽음 애니메이션을 재생합니다.
        PlayDieAnimation(_animator);
    }

    // 상태 유지 시,
    public override void Execute() { }

    // 상태 탈출 시,
    public override void Exit() { }

    #endregion 상태 전환 함수

    #region 커스텀 함수

    private void PlayDieAnimation(Animator animator)
    {
        animator.SetTrigger(_die_AnimatorHash);
    }

    #endregion  커스텀 함수

    #region 입력 시스템 (죽음 상태에서는 조작할 수 없습니다.)

    public override void OnAttack() { }

    public override void OnEvade() { }

    public override void OnMove(Vector2 inputVector) { }

    public override void OnUltimate() { }

    public override void OnWeaponSkill() { }

    #endregion 입력 시스템 (죽음 상태에서는 조작할 수 없습니다.)
}
