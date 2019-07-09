using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.ComponentModel;

public static class ExtensionMethod
{
	// enum
	public static string ToDesc(this System.Enum a_eEnumVal)
	{
		var da = (DescriptionAttribute[])(a_eEnumVal.GetType().GetField(a_eEnumVal.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
		return da.Length > 0 ? da[0].Description : a_eEnumVal.ToString();
	}

	#region 테이블값

    public static TImeData GetTimeDB(this int ID)
    {
        return Table<int, TImeData>.GetTB(ID);
    }

	#endregion
}
