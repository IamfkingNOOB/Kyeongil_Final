using UnityEngine;

/// <summary>
/// 플레이어의 Appear(등장) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerAppearState : BasePlayerState
{
    #region 변수

    private bool _isQTE = false;

    #endregion 변수

    #region 생성자

    public PlayerAppearState(BasePlayerController playerController, bool isQTE = false) : base(playerController)
    {
        _isQTE = isQTE;
    }

    #endregion 생성자

    // 상태 진입 시,
    public override void Enter()
    {
        // QTE 교체라면,
        if (_isQTE)
        {
            // 공격 상태에 들어간다.
            _playerController.ChangeState(new PlayerAttackState(_playerController, true));
        }
        else
        {
            // QTE 없는 교체에 대한 애니메이션 재생 VS 전투 전 시작 시 한 번만 재생되는 등장 애니메이션
        }

        // 등장 애니메이션을 재생합니다.
        _animator.SetTrigger("Appear");
    }

    public override void Execute()
    {
        // Standby 상태로의 전환을 확인합니다.
        CheckTransitionToStandby();
    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

    public override void OnAttack()
    {

    }

    public override void OnEvade()
    {

    }

    public override void OnMove(Vector2 inputVector)
    {

    }

    public override void OnUltimate()
    {

    }

    public override void OnWeaponSkill()
    {

    }
}
