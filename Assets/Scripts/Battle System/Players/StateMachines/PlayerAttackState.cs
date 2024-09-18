using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 플레이어의 Attack(공격) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerAttackState : BasePlayerState
{
    #region 변수

    private bool _isQTE = false; // QTE 공격인지를 판별하는 변수

    #endregion 변수

    #region 생성자

    public PlayerAttackState(BasePlayerController playerController, bool isQTE = false) : base(playerController)
    {
        _isQTE = isQTE;
    }

    #endregion 생성자

    #region 함수

    #region 상태 전환 함수

    // 상태 진입 시,
    public override void Enter()
    {
        // 공격 애니메이션을 재생합니다.
        PlayAttackAnimation(_animator, _isQTE);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // 선입력 시간이라면, 아무것도 하지 않고 기다립니다.
        if (_isPreInputTime) return;

        // 선입력 시간이 지나고 입력 값이 들어오면,
        if (_preInputAction != null)
        {
            _preInputAction.Invoke(); // 입력 값을 즉시 실행하고,
            _preInputAction = null; // 입력 값을 초기화하고,
            _isPreInputTime = true; // 선입력 시간에 들어갑니다.
        }

        // Standby 상태로의 전환을 확인합니다.
        CheckTransitionToStandby();
    }

    // 상태 탈출 시,
    public override void Exit()
    {
        // 공격 애니메이션의 매개변수를 초기화합니다.
        _animator.ResetTrigger(_attack_AnimatorHash);

        _preInputAction = null;
    }

    #endregion 상태 전환 함수

    #region 입력 시스템

    // 이동
    public override void OnMove(Vector2 inputVector)
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerMoveState(_playerController, inputVector)); };
    }

    // 회피
    public override void OnEvade()
    {
        // 회피는 선입력 없이 즉시 실행합니다. (캔슬 기능)
        _playerController.ChangeState(new PlayerEvadeState(_playerController));
    }

    // 공격
    public override void OnAttack()
    {
        // 공격 중 다시 공격할 수 있습니다. 이때는 콤보 공격을 수행하며, '상태의 전환'이 일어나지 않습니다.
        _preInputAction = () => { PlayAttackAnimation(_animator, false); };
    }

    // 무기 스킬
    public override void OnWeaponSkill()
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerWeaponSkillState(_playerController)); };
    }

    // 필살기
    public override void OnUltimate()
    {
        _preInputAction = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }

    #endregion 입력 시스템

    #region 커스텀 함수

    // 공격 애니메이션을 재생합니다.
    private void PlayAttackAnimation(Animator animator, bool isQTE = false)
    {
        // QTE 스킬이라면,
        if (isQTE)
        {
            // QTE 애니메이션을 재생합니다.
            animator.SetTrigger(_qte_AnimatorHash);
        }
        // 아니라면,
        else
        {
            // 공격 애니메이션을 재생합니다.
            animator.SetTrigger(_attack_AnimatorHash);
        }
    }

    #endregion 커스텀 함수

    #endregion 함수
}
