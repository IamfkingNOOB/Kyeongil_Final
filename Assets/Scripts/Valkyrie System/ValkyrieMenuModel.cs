using System.ComponentModel;
using UnityEngine;

/// <summary>
/// 발키리 화면에서, 데이터를 관리하는 클래스입니다.
/// </summary>
public class ValkyrieMenuModel // = Selected Valkyrie
{
    #region 변수

    public ValkyrieData SelectedValkyrie { get; set; }

    private string _characterName;
    private Sprite _rank;
    private string _suitName;
    private string _level;

    private string _weaponName;
    private Sprite _weaponIcon;

    private Sprite _stigmataTop;
    private Sprite _stigmataMiddle;
    private Sprite _stigmataBottom;

    #endregion 변수

    #region 프로퍼티

    public string CharacterName
    {
        get => _characterName;
        set { _characterName = value; OnPropertyChanged(nameof(CharacterName)); }
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

    #region 프로퍼티 변경 이벤트

    private event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

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
}
