using UnityEngine;

public class PlayerPrefsList : Singleton<PlayerPrefsList>
{
    public string MainValkyrie { get; } = PlayerPrefs.GetString("MainValkyrie");
}
