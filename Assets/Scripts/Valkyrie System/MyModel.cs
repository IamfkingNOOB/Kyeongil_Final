using System.ComponentModel;
using UnityEngine;

public class MyModel
{
    #region UI 데이터

    private string _valkyrieName;
    private string _suitName;

    private string _level;
    private Sprite _rank;
    private Sprite[] _traits;

    private string _weaponName;
    private Sprite _weaponIcon;

    private Sprite _stigmataTop;
    private Sprite _stigmataMiddle;
    private Sprite _stigmataBottom;

    #endregion UI 데이터

    #region 프로퍼티

    public string ValkyrieName
    {
        get => _valkyrieName;
        set { _valkyrieName = value; OnPropertyChanged(nameof(ValkyrieName)); }
    }

    public string SuitName
    {
        get => _suitName;
        set { _suitName = value; OnPropertyChanged(nameof(SuitName)); }
    }

    public string Level
    {
        get => _level;
        set { _level = value; OnPropertyChanged(nameof(Level)); }
    }

    public Sprite Rank
    {
        get => _rank;
        set { _rank = value; OnPropertyChanged(nameof(Rank)); }
    }

    public Sprite[] Traits
    {
        get => _traits;
        set { _traits = value; OnPropertyChanged(nameof(Traits)); }
    }

    public string WeaponName
    {
        get => _weaponName;
        set { _weaponName = value; OnPropertyChanged(nameof(WeaponName)); }
    }

    public Sprite WeaponIcon
    {
        get => _weaponIcon;
        set { _weaponIcon = value; OnPropertyChanged(nameof(WeaponIcon)); }
    }

    public Sprite StigmataTop
    {
        get => _stigmataTop;
        set { _stigmataTop = value; OnPropertyChanged(nameof(StigmataTop)); }
    }

    public Sprite StigmataMiddle
    {
        get => _stigmataMiddle;
        set { _stigmataMiddle = value; OnPropertyChanged(nameof(StigmataMiddle)); }
    }

    public Sprite StigmataBottom
    {
        get => _stigmataBottom;
        set { _stigmataBottom = value; OnPropertyChanged(nameof(StigmataBottom)); }
    }

    #endregion 프로퍼티

    #region UI 이벤트

    // 프로퍼티 변경 이벤트를 구현합니다.
    private event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // 외부 클래스에서 이벤트를 구독하기 위한 함수를 구현합니다.
    public void RegisterPropertyChangedEvent(bool isRegister, PropertyChangedEventHandler handler)
    {
        if (isRegister) PropertyChanged += handler;
        else PropertyChanged -= handler;
    }

    #endregion UI 이벤트

    #region 생성자

    public MyModel(PropertyChangedEventHandler handler)
    {
        PropertyChanged += handler;
    }

    #endregion 생성자
}
