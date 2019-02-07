using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CsvReader
{
    int totalRows = 0;

    // filePath : 拡張子はつけない
    public List<string[]> ReadCSV(string filePath)
    {
        // 行数を初期化
        totalRows = 0;
        // csvをロード
        TextAsset csv = Resources.Load(filePath) as TextAsset;
        // csvをテキストに変換
        StringReader reader = new StringReader(csv.text);
        // 格納するリストを用意
        List<string[]> data = new List<string[]>();

        while (reader.Peek() > -1)
        {
            // 1行を格納
            string line = reader.ReadLine();

			//// 空欄の場合は無視
			//System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries;
			//// CR＋LR の 改行 で区切る
			//string[] stringArray = line.Split(new char[] { '\r', '\n' }, option);

			// [,] で 区切る
			//string[] stringArray = line.Split(',');

			// [,] で 区切って 空欄の場合は無視
			System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries;
			string[] stringArray = line.Split(new char[] { ',' }, option);

            // 先頭が "//" なら追加しない
            if (stringArray[0] == "//") continue;

            data.Add(stringArray);
            ++totalRows;
        }

        if (totalRows == 0) return null;
		totalRows = 0;
        return data;
    }
	
    public int TotalRows { get { return totalRows; } }
}