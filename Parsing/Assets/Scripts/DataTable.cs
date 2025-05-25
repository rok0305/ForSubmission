using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
[Serializable]
public class DataTable : ScriptableObject // 엑셀 값을 저장할 공간
{
	public List<DataTableEntity> data;
}
