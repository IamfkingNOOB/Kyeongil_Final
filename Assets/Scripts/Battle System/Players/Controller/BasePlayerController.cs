using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어가 입력(Input System)에 따른 행동을 정의하기 위한 인터페이스입니다.
/// </summary>
interface IPlayerController
{
    // 이동
    void OnMove(InputAction.CallbackContext callbackContext);

    // 회피
    void OnEvade(InputAction.CallbackContext callbackContext);

    // 공격
    void OnAttack(InputAction.CallbackContext callbackContext);

    // 무기
    void OnWeaponSkill(InputAction.CallbackContext callbackContext);

    // 궁극기
    void OnUltimate(InputAction.CallbackContext callbackContext);
}

/// <summary>
/// 플레이어의 조작을 다루는 최상위 클래스입니다.
/// </summary>
public abstract class BasePlayerController : MonoBehaviour, IPlayerController
{
    #region 변수(Field)

    #region 상태 패턴(State Pattern)

    // 캐릭터의 현재 상태를 나타내는 인터페이스
    private IPlayerState _playerState;

    #endregion 상태 패턴(State Pattern)

    #region 이동

    // 캐릭터가 파티의 리더인지를 판별하기 위한 변수
    public bool IsLeader { get; set; } = false;

    // 카메라의 위치 값
    public Transform CameraTransform { get; private set; }

    #endregion 이동

    #endregion 변수(Field)

    #region 함수(Method)

    #region 유니티 생명 주기 함수(Unity Life Cycle Method)

    // 게임을 시작할 때,
    protected virtual void Awake()
    {
        // 변수를 초기화합니다.
        InitializeField();
    }

    // 매 프레임마다,
    private void Update()
    {
        // 현재의 상태에 대한 행동을 수행합니다.
        _playerState.Execute();
    }

    #endregion 유니티 생명 주기 함수(Unity Life Cycle Method)

    #region 커스텀 함수

    // 필드를 초기화합니다.
    private void InitializeField()
    {
        // 메인 카메라의 위치 값을 참조합니다.
        CameraTransform = Camera.main.transform;

        // 시작 시의 첫 상태를 지정합니다.
        ChangeState(SetFirstState(IsLeader));
    }

    // 캐릭터의 첫 상태를 지정합니다.
    private BasePlayerState SetFirstState(bool isLeader)
    {
        // 캐릭터가 파티의 리더인지를 판별하여, 맞으면 Appear, 아닐 경우 Standby 상태를 반환합니다.
        return (isLeader) ? new PlayerAppearState(this) : new PlayerStandbyState(this);
    }

    // 캐릭터의 상태를 변경합니다.
    public void ChangeState(IPlayerState playerState)
    {
        _playerState?.Exit(); // 현재의 상태를 종료하고,
        _playerState = playerState; // 매개변수로 받은 상태를 참조하여,
        _playerState.Enter(); // 그 상태에 진입합니다.
    }

    #region 입력 시스템(Input System)

    // 이동
    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        // 이동은 입력(Press)과 해제(Release)의 구분 없이 모두 함수를 호출합니다.
        _playerState.OnMove(callbackContext.ReadValue<Vector2>());
    }

    // 회피
    public void OnEvade(InputAction.CallbackContext callbackContext)
    {
        // 그 외의 기능은 입력되었을 때만 함수를 호출합니다. (해제할 때는 호출하지 않습니다.)
        if (callbackContext.performed)
        {
            _playerState.OnEvade();
        }
    }

    // 공격
    public void OnAttack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerState.OnAttack();
        }
    }
    
    // 무기 스킬
    public void OnWeaponSkill(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerState.OnWeaponSkill();
        }
    }

    // 필살기
    public void OnUltimate(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerState.OnUltimate();
        }
    }

    #endregion 입력 시스템(Input System)

    #endregion 커스텀 함수

    #endregion 함수(Method)


}
