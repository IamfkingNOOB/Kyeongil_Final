using System;
using UnityEngine;

/// <summary>
/// 플레이어의 각 상태에 대한 행동을 구체화하기 위한 인터페이스입니다. (상태 패턴)
/// </summary>
public interface IPlayerState
{
    void Enter(); // 상태 진입 시
    void Execute(); // 상태 유지 시
    void Exit(); // 상태 탈출 시

    // Input Systems
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
    // 플레이어의 조작을 담당하는 최상위 클래스
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

/// <summary>
/// 플레이어의 Standby(출격 시의 기본 값) 상태를 다루는 클래스입니다.
/// </summary>
public class PlayerStandbyState : BasePlayerState
{
    // 변수
    private float tempTimeValue; // 시간과 관련한 값을 저장할 임시 변수 공간
    private float timeToIdle = 10.0f; // Idle 애니메이션을 재생하기까지의 대기 시간

    // 생성자
    public PlayerStandbyState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시, 
    public override void Enter()
    {
        // 진입했을 때의 시간을 저장한다.
        tempTimeValue = Time.time;
    }

    // 상태 유지 시,
    public override void Execute()
    {
        Debug.Log($"PlayerStandbyState : GetCurrentAnimatorStateInfo().normalizedTime = {_animator.GetCurrentAnimatorStateInfo(0).normalizedTime}");


        // 만약 일정 시간 이상 Standby 상태를 유지할 경우,
        if (tempTimeValue + timeToIdle < Time.time)
        {
            // Idle 상태에 진입합니다.
            _playerController.ChangeState(new PlayerIdleState(_playerController));
        }
    }

    // 상태 탈출 시,
    public override void Exit() { }


    // Input Systems
    public override void OnMove(Vector2 inputVector)
    {
        _playerController.ChangeState(new PlayerMoveState(_playerController));
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
}

/// <summary>
/// 플레이어의 Idle(출격 시의 AFK 값) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerIdleState : BasePlayerState
{
    // 생성자
    public PlayerIdleState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        // Idle 애니메이션을 재생합니다.
        _animator.SetTrigger(_idle_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // 만약 Standby 상태로 전환 중이라면, (Has Exit Time에 의한 자동 전환)
        if (_animator.GetAnimatorTransitionInfo(0).IsName("Idle -> Standby"))
        {
            // Standby 상태에 진입합니다.
            _playerController.ChangeState(new PlayerStandbyState(_playerController));
        }
    }

    // 상태 탈출 시,
    public override void Exit() { }

    // Input Systems
    public override void OnMove(Vector2 inputVector)
    {
        _playerController.ChangeState(new PlayerMoveState(_playerController));
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
}

/// <summary>
/// 플레이어의 Move(이동) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerMoveState : BasePlayerState
{
    // 변수
    private Transform _cameraTransform; // 플레이어를 비추는 카메라의 위치 값
    private Vector2 _inputVector; // 방향 입력 값

    // 생성자
    public PlayerMoveState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        // 카메라의 위치 값을 참조합니다.
        _cameraTransform = _playerController._cameraTransform;
    }

    // 상태 유지 시,
    public override void Execute()
    {
        // 플레이어는 입력을 받아 이동합니다.
        Move(_inputVector);
    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

    // Input Systems
    public override void OnMove(Vector2 inputVector)
    {
        _inputVector = inputVector;
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

    // 캐릭터의 이동을 구현합니다.
    private void Move(Vector2 inputVector)
    {
        // 카메라의 방향과 입력 값을 참조하여 이동 방향을 계산합니다.
        Vector3 moveVector = inputVector.y * _cameraTransform.forward + inputVector.x * _cameraTransform.right;
        moveVector.y = 0f; // Y축으로는 이동하지 않습니다.
        moveVector.Normalize(); // 값을 정규화합니다.

        // 입력 값이 있을 때만 이동과 회전을 수행합니다.
        bool isMove = (inputVector != Vector2.zero);

        _animator.SetBool(_move_AnimatorHash, isMove); // 이동; 루트 모션을 사용합니다.

        if (isMove) // 회전
        {
            _playerController.transform.rotation = Quaternion.Slerp(_playerController.transform.rotation, Quaternion.LookRotation(moveVector), 10.0f * Time.deltaTime);
        }
    }
}


/// <summary>
/// 플레이어의 Attack(공격) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerAttackState : BasePlayerState
{
    // 선입력 관련 변수
    private float _preInputDelay = 0.3f;
    private Action _preInput;
    private bool isTransit = false;

    // 생성자
    public PlayerAttackState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_attack_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        if (_preInputDelay > _animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            isTransit = false;
        }

        if (_preInputDelay < _animator.GetCurrentAnimatorStateInfo(0).normalizedTime && !isTransit)
        {
            Debug.Log($"Pre Input Delay = {_preInputDelay}, GetCurrentAnimatorStateInfo().normalizedTime = {_animator.GetCurrentAnimatorStateInfo(0).normalizedTime}");

            _preInput?.Invoke();
            _preInput = null;
            isTransit = true;
        }
    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

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
        _preInput = () => { _animator.SetTrigger(_attack_AnimatorHash); };
    }

    public override void OnWeaponSkill()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerWeaponSkillState(_playerController)); };
    }

    public override void OnUltimate()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }
}

/// <summary>
/// 플레이어의 Evade(회피) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerEvadeState : BasePlayerState
{
    // 변수; 연속 회피 가능 횟수
    private int _currentEvadeCount = 0;
    private int _maxEvadeCount = 2;

    // 선입력 관련 변수
    private float _preInputDelay;
    private Action _preInput;

    // 생성자
    public PlayerEvadeState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_evade_AnimatorHash);
        _currentEvadeCount++;
    }

    // 상태 유지 시,
    public override void Execute()
    {
        if (_preInputDelay < _animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            _preInput?.Invoke();
        }
    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

    public override void OnMove(Vector2 inputVector)
    {
        _preInput = () => { _playerController.ChangeState(new PlayerMoveState(_playerController)); };
    }

    public override void OnEvade()
    {
        if (_currentEvadeCount < _maxEvadeCount)
        {
            _preInput = () => { _animator.SetTrigger(_evade_AnimatorHash); _currentEvadeCount++; };
        }
    }

    public override void OnAttack()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerAttackState(_playerController)); };
    }

    public override void OnWeaponSkill()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerWeaponSkillState(_playerController)); };
    }

    public override void OnUltimate()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }

    
}

/// <summary>
/// 플레이어의 WeaponSkill(무기 스킬) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerWeaponSkillState : BasePlayerState
{
    // 선입력 관련 변수
    private float _preInputDelay;
    private Action _preInput;

    // 생성자
    public PlayerWeaponSkillState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_weapon_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {
        if (_preInputDelay < _animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            _preInput?.Invoke();
        }
    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

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
        _preInput = () => { _playerController.ChangeState(new PlayerAttackState(_playerController)); };
    }

    public override void OnWeaponSkill()
    {
        // ?
    }

    public override void OnUltimate()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }
}

/// <summary>
/// 플레이어의 Ultimate(필살기) 상태를 관리하는 클래스입니다.
/// </summary>
public class PlayerUltimateState : BasePlayerState
{
    // 필살기 모드에 진입했을 경우, 아래와 같은 특수 상황이 발생한다.
    // 1. 컷신이 재생된다.
    // 2. 컷신이 재생되는 동안, 모든 조작이 불가능해진다.
    // 3. 필살기는 전환을 아예 하지 않아도 괜찮을 수도 있다.

    // 선입력 관련 변수
    private float _preInputDelay;
    private Action _preInput;

    // 생성자
    public PlayerUltimateState(BasePlayerController playerController) : base(playerController) { }

    // 상태 진입 시,
    public override void Enter()
    {
        _animator.SetTrigger(_ultimate_AnimatorHash);
    }

    // 상태 유지 시,
    public override void Execute()
    {

    }

    // 상태 탈출 시,
    public override void Exit()
    {

    }

    public override void OnMove(Vector2 inputVector)
    {
        _preInput = () => { _playerController.ChangeState(new PlayerMoveState(_playerController)); };
    }

    public override void OnEvade()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerEvadeState(_playerController)); };
    }

    public override void OnAttack()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerAttackState(_playerController)); };
    }

    public override void OnWeaponSkill()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerWeaponSkillState(_playerController)); };
    }

    public override void OnUltimate()
    {
        _preInput = () => { _playerController.ChangeState(new PlayerUltimateState(_playerController)); };
    }
}