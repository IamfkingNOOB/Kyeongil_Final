using System.ComponentModel;
using UnityEngine;

/// <summary>
/// 발키리 화면에서, 데이터를 관리하는 클래스입니다.
/// </summary>
public class ValkyrieMenuModel
{
    #region 프로퍼티 변경 이벤트

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion 프로퍼티 변경 이벤트

    #region 변수

    private string _valkyrieName;
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

    public string ValkyrieName
    {
        get { return _valkyrieName; }
        set { _valkyrieName = value; OnPropertyChanged(nameof(ValkyrieName)); }
    }

    public Sprite Rank
    {
        get { return _rank; }
        set { _rank = value; OnPropertyChanged(nameof(Rank)); }
    }

    public string SuitName
    {
        get { return _suitName; }
        set { _suitName = value; OnPropertyChanged(nameof(SuitName)); }
    }

    public string Level
    {
        get { return _level; }
        set { _level = value; OnPropertyChanged(nameof(Level)); }
    }

    public string WeaponName
    {
        get { return _weaponName; }
        set { _weaponName = value; OnPropertyChanged(nameof(WeaponName)); }
    }

    public Sprite WeaponIcon
    {
        get { return _weaponIcon; }
        set { _weaponIcon = value; OnPropertyChanged(nameof(WeaponIcon)); }
    }

    public Sprite StigmataTop
    {
        get { return _stigmataTop; }
        set { _stigmataTop = value; OnPropertyChanged(nameof(StigmataTop)); }
    }

    public Sprite StigmataMiddle
    {
        get { return _stigmataMiddle; }
        set { _stigmataMiddle = value; OnPropertyChanged(nameof(StigmataMiddle)); }
    }

    public Sprite StigmataBottom
    {
        get { return _stigmataBottom; }
        set { _stigmataBottom = value; OnPropertyChanged(nameof(StigmataBottom)); }
    }

    #endregion 프로퍼티
}
