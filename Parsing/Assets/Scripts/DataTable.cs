using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
[Serializable]
public class DataTable : ScriptableObject // ���� ���� ������ ����
{
	public List<DataTableEntity> data;
}
