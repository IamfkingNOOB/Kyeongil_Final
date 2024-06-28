using UnityEngine;

public class PlayerPrefsList : Singleton<PlayerPrefsList>
{
    public int _mainCharacterIndex { get; } = PlayerPrefs.GetInt("MainCharacterIndex", -1);
}
