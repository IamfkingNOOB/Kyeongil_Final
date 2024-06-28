using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private Button _pauseButton; // 일시정지 버튼
    [SerializeField] private TextMeshProUGUI _timerText; // 경과 시간

    [SerializeField] private TextMeshProUGUI _enemyNameText; // 적 이름
    [SerializeField] private Image _enemyHPBarImage; // 적 HP 바
    
    [SerializeField] private Image _playerHPBarImage; // 플레이어 HP 바
    [SerializeField] private TextMeshProUGUI _playerHPText; // 플레이어 HP 수치
    [SerializeField] private Image _playerSPBarImage; // 플레이어 SP 바
    [SerializeField] private TextMeshProUGUI _playerSPText; // 플레이어 SP 수치

    [SerializeField] private Button _evadeButton; // 회피 버튼
    [SerializeField] private Button _attackButton; // 공격 버튼
    [SerializeField] private Button _weaponButton; // 무기 버튼
    [SerializeField] private Button _ultraButton; // 필살기 버튼

    [SerializeField] private Button _qte01Button; // QTE 01 버튼
    [SerializeField] private Button _qte02Button; // QTE 02 버튼


}
