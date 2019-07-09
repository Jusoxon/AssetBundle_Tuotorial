using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle myLoadedAssetbundle;
    public string path;
    public string objName;

    private void Start()
    {
        LoadAssetBundle(path);
        InstantiateObjectFromBundle(objName);
    }

    void LoadAssetBundle(string _url)
    {
        myLoadedAssetbundle = AssetBundle.LoadFromFile(_url);
        Debug.Log(myLoadedAssetbundle == null ? "Asset Load Fail" : "Asset Load Success");
    }

    void InstantiateObjectFromBundle(string _assetName)
    {
        var prefab = myLoadedAssetbundle.LoadAsset(_assetName);
        Instantiate(prefab);
        Debug.Log(myLoadedAssetbundle == null ? "Asset Instantiate Fail" : "Asset Instantiate Success");
    }
}
