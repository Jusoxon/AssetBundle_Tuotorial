using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    #region INSPECTOR
    public InputField inputField;
    public Text txt;
    #endregion


    TImeData timeDB = null;

    public int timeID = 101;
    public int part;
    public int nutrition;
    public int power;
    public int time;

    public void ChangeID()
    {
        timeID = int.Parse(inputField.text);
        if(inputField.text == null)
        {
            timeID = 101;
        }
    }

    public void Init()
    {
        timeDB = timeID.GetTimeDB();

        if(timeDB == null)
        {
            Debug.LogError("Don't have this ID");
        }
        else
        {
            part = timeDB.nPart;
            nutrition = timeDB.nNutrition;
            power = timeDB.nPower;
            time = timeDB.nTime;
        }
    }

    public void ChangeTxt()
    {
        string s = string.Format("Time ID : " + timeID + "\n" + "Part Count : " + part + "\n" + "Nutrition Count : " + nutrition + "\n" + "Power Count : " + power + "\n" + "Time : " + time / 60 + "h " + time %60 + "m");
        txt.text = s;
    }
}
