using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 발키리(캐릭터)를 종합적으로 관리하는 매니저 클래스입니다.
/// </summary>
public class ValkyrieManager : Singleton<ValkyrieManager>
{
    // 모든 발키리 데이터를 관리하기 위한 사전(Dictionary)
    private Dictionary<int, Valkyrie> _valkyrieDictionary;

    // 사전의 프로퍼티(Property)
    public Dictionary<int, Valkyrie> ValkyrieDictionary
    {
        get
        {
            // 만약 발키리 사전이 생성되어 있지 않다면,
            if (_valkyrieDictionary == null)
            {
                // 발키리 사전을 생성합니다.
                _valkyrieDictionary = new Dictionary<int, Valkyrie>();

                // 발키리 사전을 초기화합니다.
                InitializeValkyrieDictionary();
            }
            return _valkyrieDictionary;
        }
    }

    // 발키리 사전을 초기화합니다.
    private void InitializeValkyrieDictionary()
    {
        // 발키리 사전의 내용을 초기화합니다.
        _valkyrieDictionary.Clear();

        // 리소스(Resources) 폴더에서 발키리의 데이터를 모두 불러옵니다.
        Valkyrie[] valkyries = Resources.LoadAll<Valkyrie>("Valkyries");

        // 불러온 발키리 데이터를 발키리 사전에 추가합니다.
        foreach (Valkyrie valkyrie in valkyries)
        {
            _valkyrieDictionary.Add(valkyrie._valkyrie_ID, valkyrie);
        }
    }
}
