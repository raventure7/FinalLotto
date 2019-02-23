﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CSVWriter : MonoBehaviour {

	public void Write () {
		using (var writer = new CsvFileWriter("Assets/Resources/csv/userLottoManager.csv"))
		{
			List<string> columns = new List<string>(){"Num", "fdNum", "fdDate", "fdType", "fdNum1", "fdNum2", "fdNum3", "fdNum4", "fdNum5", "fdNum6" };// making Index Row
			writer.WriteRow(columns);
            /*
            columns.Clear();

			columns.Add("Bbulle"); // Name
			columns.Add("99"); // Level
			columns.Add("999"); // Hp
			columns.Add("5000"); // Exp
			columns.Add("99"); // Str
			columns.Add("50"); // Dex
			columns.Add("80"); // Con
			columns.Add("40"); // Int
			writer.WriteRow(columns);
			columns.Clear();

			columns.Add("Kukai"); // Name
			columns.Add("50"); // Level
			columns.Add("666"); // Hp
			columns.Add("3500"); // Exp
			columns.Add("66"); // Str
			columns.Add("66"); // Dex
			columns.Add("44"); // Con
			columns.Add("22"); // Int
			writer.WriteRow(columns);
			columns.Clear();
            */
		}
	}
}
