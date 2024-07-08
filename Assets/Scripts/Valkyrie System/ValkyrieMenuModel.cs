using System.ComponentModel;
using UnityEngine;

public class ValkyrieMenuModel
{
    #region Property Changed Event

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion Property Changed Event

    #region Field

    private string _valkyrieName;
    private Sprite _rank;
    private string _suitName;
    private string _level;

    private string _weaponName;
    private Sprite _weaponPrefab;

    private Sprite _stigmata_T;
    private Sprite _stigmata_M;
    private Sprite _stigmata_B;

    #endregion Field

    #region Property

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

    public Sprite WeaponPrefab
    {
        get { return _weaponPrefab; }
        set { _weaponPrefab = value; OnPropertyChanged(nameof(WeaponPrefab)); }
    }

    public Sprite Stigmata_T
    {
        get { return _stigmata_T; }
        set { _stigmata_T = value; OnPropertyChanged(nameof(Stigmata_T)); }
    }

    public Sprite Stigmata_M
    {
        get { return _stigmata_M; }
        set { _stigmata_M = value; OnPropertyChanged(nameof(Stigmata_M)); }
    }

    public Sprite Stigmata_B
    {
        get { return _stigmata_B; }
        set { _stigmata_B = value; OnPropertyChanged(nameof(Stigmata_B)); }
    }

    #endregion Property
}
