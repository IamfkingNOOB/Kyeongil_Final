using UnityEngine;

/// <summary>
/// 플레이어의 Standby(출격 시의 기본 값) 상태를 다루는 클래스입니다.
/// </summary>
public class PlayerStandbyState : BasePlayerState
{
    #region 변수

    private float stateEntryTime; // 시간과 관련한 값을 저장할 임시 변수 공간; 상태 진입 시의 시점을 저장합니다.
    private float timeToIdle = 10.0f; // Idle 애니메이션을 재생하기까지의 대기 시간

    #endregion 변수

    #region 생성자

    public PlayerStandbyState(BasePlayerController playerController) : base(playerController) { }

    #endregion 생성자

    #region 함수

    #region 상태 전환 함수

    // 상태 진입 시, 
    public override void Enter()
    {
        // 변수를 초기화합니다.
        InitializeField();

        // Standby로의 전환은 Exit Time을 사용하여 자동으로 전환하므로, 별도의 코드를 통해 제어하지 않습니다.
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // Idle 상태로의 전환을 확인합니다.
        CheckTransitionToIdle();
    }

    // 상태 탈출 시,
    public override void Exit() { }

    #endregion 상태 전환 함수

    #region 입력 시스템

    public override void OnMove(Vector2 inputVector)
    {
        _playerController.ChangeState(new PlayerMoveState(_playerController, inputVector));
    }

    public override void OnEvade()
    {
        _playerController.ChangeState(new PlayerEvadeState(_playerController));
    }

    public override void OnAttack()
    {
        _playerController.ChangeState(new PlayerAttackState(_playerController));
    }

    public override void OnWeaponSkill()
    {
        _playerController.ChangeState(new PlayerWeaponSkillState(_playerController));
    }

    public override void OnUltimate()
    {
        _playerController.ChangeState(new PlayerUltimateState(_playerController));
    }

    #endregion 입력 시스템

    #region 커스텀 함수

    // 변수를 초기화합니다.
    private void InitializeField()
    {
        stateEntryTime = Time.time;
        timeToIdle = 10.0f;
    }

    // Idle 상태로의 전환을 확인합니다.
    private void CheckTransitionToIdle()
    {
        // 만약 일정 시간 이상 Standby 상태를 유지할 경우,
        if (stateEntryTime + timeToIdle < Time.time)
        {
            // Idle 상태에 진입합니다.
            _playerController.ChangeState(new PlayerIdleState(_playerController));
        }
    }

    #endregion 커스텀 함수

    #endregion 함수
}
