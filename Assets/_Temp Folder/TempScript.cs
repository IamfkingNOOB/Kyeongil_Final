using System.ComponentModel;
using TMPro;
using UnityEngine;

public class TempScript : MonoBehaviour
{
    // 체력(HP)을 나타내는 텍스트 UI
    [SerializeField] private TextMeshProUGUI _hpText;

    // 체력을 담당하는 클래스
    private HealthPoint _healthPoint;

    // 체력 클래스의 프로퍼티 변경 이벤트에 등록할 콜백 함수로, 체력의 값이 변경되면 그 값을 텍스트 UI에 적용한다.
    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case (nameof(_healthPoint.CurrentHP)): // 변경된 프로퍼티의 이름이 "CurrentHP"라면,
                _hpText.text = $"{_healthPoint.CurrentHP} / {_healthPoint.MaxHP}"; // 텍스트 UI를 "CurrentHP / MaxHP"로 변경한다.
                break;
        }
    }

    #region 유니티 생명 주기 함수

    // 활성화할 때,
    private void OnEnable()
    {
        if (_healthPoint == null)
        {
            _healthPoint = new(100); // 최대 체력을 100으로 지정하여 체력 클래스를 생성한다.
            _healthPoint.AddPropertyChangedListener(true, OnPropertyChanged); // 프로퍼티 변경 이벤트에 콜백 함수를 등록한다.
        }
    }

    // 비활성화할 때,
    private void OnDisable()
    {
        if (_healthPoint != null)
        {
            _healthPoint.AddPropertyChangedListener(false, OnPropertyChanged); // 프로퍼티 변경 이벤트에 콜백 함수를 해제한다.
            _healthPoint = null; // 체력 클래스를 제거한다.
        }
    }

    #endregion 유니티 생명 주기 함수

    // [Debug] Space 키를 눌러 체력을 1씩 감소시킬 수 있다.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _healthPoint.CurrentHP -= 1;
        }
    }
}

// 체력(HP)을 담당하는 클래스
public class HealthPoint
{
    #region 생성자

    // 생성할 때, 최대 체력에 대한 값를 받아서 적용한다.
    public HealthPoint(int maxHP)
    {
        MaxHP = maxHP;
    }

    #endregion 생성자

    #region 프로퍼티 변경 이벤트

    // 프로퍼티 변경 이벤트 핸들러
    private event PropertyChangedEventHandler PropertyChanged;

    // 프로퍼티 변경 이벤트 호출 함수
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // 프로퍼티 변경 이벤트 핸들러에 콜백 함수를 등록/해제하는 함수
    public void AddPropertyChangedListener(bool isPositive, PropertyChangedEventHandler handler)
    {
        if (isPositive)
        {
            PropertyChanged += handler;
        }
        else
        {
            PropertyChanged -= handler;
        }
    }

    #endregion 프로퍼티 변경 이벤트

    #region 체력(HP)을 담당하는 데이터

    // 현재 체력
    private int _currentHP;
    public int CurrentHP
    {
        get => _currentHP;
        set
        {
            _currentHP = Mathf.Max(0, value); // 현재 체력은 0 미만으로 감소하지 않는다.
            OnPropertyChanged(nameof(CurrentHP)); // 값이 변경되면, 프로퍼티 변경 이벤트를 호출한다.
        }
    }

    // 최대 체력
    private int _maxHP;
    public int MaxHP
    {
        get => _maxHP;
        set
        {
            _maxHP = value;
            CurrentHP = MaxHP; // 최대 체력에 대한 값은 생성할 때 한 번 적용하고, 그 값을 현재 체력에도 적용한다.
        }
    }

    #endregion 체력(HP)을 담당하는 데이터
}
