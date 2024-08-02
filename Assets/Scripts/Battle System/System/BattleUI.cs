using System.ComponentModel;
using TMPro;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    // [TODO]: 우선은 교대 없이, 캐릭터 한 명만을 구현하도록 하자.

    // 출전 발키리( = View Model )
    private Valkyrie _onFieldValkyrie; // 필드 위에 있어 조작할 수 있는 발키리
    // private Valkyrie _outFieldValkyrie01; // 필드 밖에 있어 조작할 수 없는 발키리 01
    // private Valkyrie _outFieldValkyrie02; // 필드 밖에 있어 조작할 수 없는 발키리 02

    // UI
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _spText;
    // private Button _qteButton01;
    // private Button _qteButton02;

    // 활성화할 때,
    private void OnEnable()
    {
        // 뷰 모델(View Model)을 생성하고, 프로퍼티 변경 이벤트를 등록합니다.
        if (_onFieldValkyrie == null)
        {
            _onFieldValkyrie.PropertyChanged += OnPropertyChanged;
        }
    }

    // 비활성화할 때,
    private void OnDisable()
    {
        // 프로퍼티 변경 이벤트를 해제하고, 뷰 모델(View Model)을 삭제합니다.
        if (_onFieldValkyrie != null)
        {
            _onFieldValkyrie.PropertyChanged -= OnPropertyChanged;
        }
    }

    // 플레이어의 데이터의 값이 변경되었을 때 호출하는 이벤트 콜백 함수
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // 현재 출전 중인 플레이어의 HP/SP가 변화했을 때, 이벤트를 발생시켜 Text를 바꿉니다.
        switch (e.PropertyName)
        {
            case (nameof(_onFieldValkyrie.CurrentHP)):
                _hpText.text = $"{_onFieldValkyrie.CurrentHP} / {_onFieldValkyrie.HP}";
                break;
            case (nameof(_onFieldValkyrie.CurrentSP)):
                _spText.text = $"{_onFieldValkyrie.CurrentSP} / {_onFieldValkyrie.SP}";
                break;
        }
    }
}
