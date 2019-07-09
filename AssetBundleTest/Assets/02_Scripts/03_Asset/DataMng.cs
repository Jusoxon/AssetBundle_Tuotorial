using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public enum eTable
{
    eTime = 0,

    Max
}

public class DataMng : MonoBehaviour
{
    #region SINGLETON
    static DataMng _instance = null;
    public static DataMng Ins
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(DataMng)) as DataMng;
                if (_instance == null)
                {
                    _instance = new GameObject("DataMng", typeof(DataMng)).GetComponent<DataMng>();
                }
            }
            return _instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    #endregion

    const string bundlePath = "AssetBundles/StandaloneWindows/datadb";

    AssetBundle loadBundles;

    public List<TImeData> lTime = new List<TImeData>();

    private void Start()
    {
        lTime.Clear();

        LoadAssetBundle();

        for(int i = 0; i < (int)eTable.Max; i++)
        {
            LoadDataTable((eTable)i);
        }
    }

    public void LoadAssetBundle()
    {
        loadBundles = AssetBundle.LoadFromFile(bundlePath);
        Debug.Log(loadBundles == null ? "Asset Load Fail" : "Asset Load Success");
    }

    public void LoadDataTable(eTable _table)
    {
        string assetName = "";

        switch(_table)
        {
            case eTable.eTime:
                {
                    assetName = "TimeDB";
                    var asset = loadBundles.LoadAsset(assetName).ToString();

                    var liTime = JsonMapper.ToObject<List<TImeData>>(asset);
                    lTime.AddRange(liTime);

                    for(int i = 0; i < lTime.Count; i++)
                    {
                        Table<int, TImeData>.SetTB(lTime[i].nID, lTime[i]);
                    }

                    break;
                }
        }
    }

}



public class TImeData
{
    public int nID;
    public int nPart;
    public int nNutrition;
    public int nPower;
    public int nTime;
}