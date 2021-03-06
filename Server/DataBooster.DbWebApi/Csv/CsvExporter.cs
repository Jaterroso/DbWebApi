﻿// Copyright (c) 2015 Abel Cheng <abelcys@gmail.com> and other contributors.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// Repository:	https://github.com/DataBooster/DbWebApi

using System.IO;
using System.Collections;
using System.Collections.Generic;
using CsvHelper;

namespace DataBooster.DbWebApi.Csv
{
	public class CsvExporter
	{
		private readonly CsvWriter _CsvWriter;

		private int _ColumnCount;
		public int ColumnCount { get { return _ColumnCount; } }

		public CsvExporter(TextWriter writer)
		{
			_CsvWriter = new CsvWriter(writer, DbWebApiOptions.CsvConfiguration);
		}

		public void WriteHeader(IEnumerable<string> headerColumns)
		{
			if (headerColumns != null)
			{
				_ColumnCount = 0;

				foreach (string header in headerColumns)
				{
					_CsvWriter.WriteField(header);
					_ColumnCount++;
				}

				_CsvWriter.NextRecord();
			}
		}

		public void WriteRow(IEnumerable valueColumns)
		{
			if (valueColumns != null)
			{
				foreach (object cell in valueColumns)
					_CsvWriter.WriteField(cell);

				_CsvWriter.NextRecord();
			}
		}
	}
}
