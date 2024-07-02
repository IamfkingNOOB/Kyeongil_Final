using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어인 발키리가 입력을 받아 행동할 내용을 정의합니다.
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
/// 플레이어인 캐릭터(발키리)가 입력을 받아 행동할 내용을 다루는 최상위 클래스입니다.
/// </summary>
public abstract class BasePlayerController : MonoBehaviour, IPlayerController
{
    #region 변수

    #region 충돌체 / 강체

    // 캐릭터의 충돌체와 강체; 애니메이터로 루트 모션을 사용하므로, 캐릭터 컨트롤러 컴포넌트를 사용하지 않습니다.
    private CapsuleCollider _capsuleCollider;
    private Rigidbody _rigidbody;

    #endregion 충돌체 / 강체

    #region 애니메이터

    // 캐릭터의 애니메이터; 하위 클래스에서 접근하여 사용합니다.
    protected Animator _animator;

    #endregion 애니메이터

    #region 상태 패턴

    // 캐릭터의 현재 상태를 나타내는 인터페이스
    private IPlayerState _playerState;

    #endregion 상태 패턴

    #region 이동

    // 카메라의 위치 값
    public Transform _cameraTransform { get; private set; }

    #endregion 이동

    #endregion 변수

    #region 함수

    #region 유니티 생명 주기 함수

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

    #endregion 유니티 생명 주기 함수

    #region 커스텀 함수

    // 필드를 초기화합니다.
    private void InitializeField()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        // 시작 시 첫 상태는 Standby 상태입니다.
        ChangeState(new PlayerStandbyState(this));

        // 메인 카메라의 위치 값을 참조합니다.
        _cameraTransform = Camera.main.transform;
    }

    // 캐릭터의 상태를 변경합니다.
    public void ChangeState(IPlayerState playerState)
    {
        _playerState?.Exit(); // 현재의 상태를 종료하고,
        _playerState = playerState; // 매개변수로 받은 상태를 참조하여,
        _playerState.Enter(); // 그 상태에 진입합니다.
    }

    // Input Systems
    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        _playerState.OnMove(callbackContext.ReadValue<Vector2>());
    }

    public void OnEvade(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerState.OnEvade();
        }
    }

    public void OnAttack(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerState.OnAttack();
        }
    }

    public void OnWeaponSkill(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerState.OnWeaponSkill();
        }
    }

    public void OnUltimate(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            _playerState.OnUltimate();
        }
    }

    #endregion 커스텀 함수

    #endregion 함수
}
