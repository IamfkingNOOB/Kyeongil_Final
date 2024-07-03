using System;
using UnityEditor.Animations;
using UnityEngine;
using static HoyoToon.AnimationParser;

/// <summary>
/// 플레이어의 Attack(공격) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerAttackState : BasePlayerState
{
    #region 생성자

    public PlayerAttackState(BasePlayerController playerController) : base(playerController) { }

    #endregion 생성자

    #region 함수

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        // 변수를 초기화합니다.
        InitializeField();

        // 공격 애니메이션을 재생합니다.
        PlayAttackAnimation(_animator);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // 현재 재생 중인 애니메이션의 시점을 가져옵니다. (0 ~ 1 사이의 정규화된 값)
        float currentAnimatorStateTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        // 만약 현재 애니메이션의 전환이 불가능한 시점일 경우,
        if (_preInputDelay >= currentAnimatorStateTime) // 선입력 대기 시간일 경우,
        {
            // 전환하지 않습니다.
            _isInTransition = false;
        }
        else if (_preInputDelay < currentAnimatorStateTime && _preInput != null && !_isInTransition)
        {
            _preInput.Invoke(); // 선입력한 값이 있다면, 그것을 호출한다.
            _preInput = null; // 선입력 버퍼를 지운다.

            _isInTransition = true;
        }

        // Standby 상태로의 전환를 확인한다.
        CheckTransitionToStandby();
    }

    // 상태 탈출 시,
    public override void Exit()
    {
        // 공격 애니메이션의 매개변수를 초기화합니다.
        _animator.ResetTrigger(_attack_AnimatorHash);

        _preInput = null;
    }

    #endregion 상태 전환 함수

    #region 입력 시스템

    // Input Systems
    public override void OnMove(Vector2 inputVector)
    {
        _preInput = () => { _playerController.ChangeState(new PlayerMoveState(_playerController)); };
    }

    public override void OnEvade()
    {
        // 회피는 선입력 없이 즉시 실행합니다.
        _playerController.ChangeState(new PlayerEvadeState(_playerController));
    }

    public override void OnAttack()
    {
        _preInput = () => { PlayAttackAnimation(_animator); };
    }

    public override void OnWeaponSkill()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerWeaponSkillState(_playerController)); };
    }

    public override void OnUltimate()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }

    #endregion 입력 시스템

    #region 커스텀 함수

    // 변수를 초기화합니다.
    private void InitializeField()
    {
        _preInputDelay = 0.3f;
    }

    // 공격 애니메이션을 재생합니다.
    private void PlayAttackAnimation(Animator animator)
    {
        // 공격 애니메이션을 재생합니다.
        animator.SetTrigger(_attack_AnimatorHash);
    }

    // Standby 상태로의 전환을 확인합니다.
    private void CheckTransitionToStandby()
    {
        // 만약 현재 애니메니이션이 Standby 상태로 전환 중일 경우,
        if (_animator.GetAnimatorTransitionInfo(0).IsName("Attack -> Standby"))
        {
            // Standby 상태에 진입합니다. (Standby 애니메이션은 FSM의 Exit Time 값을 설정하여 직접 전환한다.)
            _playerController.ChangeState(new PlayerStandbyState(_playerController));

            // 전환 상태가 됩니다. (중복 호출 방지)
            _isInTransition = true;
        }
    }

    #endregion 커스텀 함수

    #endregion 함수
}
