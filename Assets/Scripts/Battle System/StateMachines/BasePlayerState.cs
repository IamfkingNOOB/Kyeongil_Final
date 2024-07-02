using UnityEngine;

/// <summary>
/// 플레이어를 상태(State) 패턴으로 구현하기 위한 인터페이스입니다.
/// </summary>
public interface IPlayerState
{
    // 상태의 전환에 따른 함수들
    void Enter(); // 상태 진입 시
    void Execute(); // 상태 유지 시
    void Exit(); // 상태 탈출 시

    // 입력 시스템(Input System)에 따른 함수들
    void OnMove(Vector2 inputVector);
    void OnEvade();
    void OnAttack();
    void OnWeaponSkill();
    void OnUltimate();
}

/// <summary>
/// 플레이어의 상태를 다루는 최상위 클래스입니다.
/// </summary>
public abstract class BasePlayerState : IPlayerState
{
    // 플레이어의 조작을 다루는 최상위 클래스
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
    public abstract void OnMove(Vector2 inputVector);
    public abstract void OnEvade();
    public abstract void OnAttack();
    public abstract void OnWeaponSkill();
    public abstract void OnUltimate();
}