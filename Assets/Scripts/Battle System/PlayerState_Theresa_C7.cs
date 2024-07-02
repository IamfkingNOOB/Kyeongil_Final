using TMPro;
using UnityEngine;

public abstract class BasePlayerState : IPlayerState
{
    // 플레이어 컨트롤러 클래스
    protected readonly BasePlayerController _playerController;

    // 애니메이터
    protected Animator _animator;

    // 애니메이터의 매개변수, 해시화
    protected readonly int _move_AnimatorHash = Animator.StringToHash("Move");
    protected readonly int _evade_AnimatorHash = Animator.StringToHash("Evade");
    protected readonly int _attack_AnimatorHash = Animator.StringToHash("Attack");
    protected readonly int _weapon_AnimatorHash = Animator.StringToHash("Weapon");
    protected readonly int _ultimate_AnimatorHash = Animator.StringToHash("Ultimate");

    protected readonly int _idle_AnimatorHash = Animator.StringToHash("Idle");

    // 생성자
    public BasePlayerState(BasePlayerController playerController)
    {
        _playerController = playerController;
        _animator = _playerController.GetComponent<Animator>();
    }

    // IPlayerState 인터페이스 함수
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}

public class PlayerStandbyState : BasePlayerState
{
    private float tempTimeValue; // 시간을 저장할 임시 변수 공간
    private float timeToIdle = 10.0f; // Idle 애니메이션을 재생하기까지의 대기 시간

    // 생성자
    public PlayerStandbyState(BasePlayerController playerController) : base(playerController) { }

    public override void Enter()
    {
        _animator.SetBool(_move_AnimatorHash, false);
        _animator.SetBool(_evade_AnimatorHash, false);
        _animator.SetBool(_ultimate_AnimatorHash, false);
        _animator.SetBool(_weapon_AnimatorHash, false);
        _animator.SetBool(_attack_AnimatorHash, false);

        // 이 상태에 들어온 시점의 시간을 저장한다.
        tempTimeValue = Time.time;
    }

    public override void Execute()
    {
        // 만약 일정 시간 이상 Standby 상태를 유지할 경우,
        if (tempTimeValue + timeToIdle < Time.time)
        {
            // Idle 상태로 진입한다.
            _playerController.ChangeState(new PlayerIdleState(_playerController));
        }
    }

    public override void Exit()
    {

    }
}

public class PlayerIdleState : BasePlayerState
{
    public PlayerIdleState(BasePlayerController playerController) : base(playerController) { }

    public override void Enter()
    {
        _animator.SetTrigger(_idle_AnimatorHash);
    }

    public override void Execute()
    {
        // 공격 버튼을 눌렀을 경우, PlayerAttack01State 상태에 진입한다.
        // 회피 버튼을 눌렀을 경우, PlayerEvadeState 상태에 진입한다.
        // 이동 버튼을 눌렀을 경우, PlayerMoveState 상태에 진입한다.
        // 무기 버튼을 눌렀을 경우, PlayerWeaponSkillState 상태에 진입한다.

        if (_animator.GetAnimatorTransitionInfo(0).IsName("Idle -> Standby"))
        {
            _playerController.ChangeState(new PlayerStandbyState(_playerController));
        }
    }

    public override void Exit()
    {

    }


}
