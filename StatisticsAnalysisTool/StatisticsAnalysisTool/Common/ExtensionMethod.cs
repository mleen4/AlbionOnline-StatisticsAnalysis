﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsAnalysisTool.Common
{
    public static class ExtensionMethod
    {
        public static async Task ForEachAsync<T>(this List<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
                await Task.Run(() => { action(item); }).ConfigureAwait(false);
        }

        public static DateTime? GetHighestDateTime(this ObservableCollection<DateTime> list)
        {
            if (!list.Any())
            {
                return null;
            }

            return list.Max();
        }

        public static long? ObjectToLong(this object value)
        {
            return value as byte? ?? value as short? ?? value as int? ?? value as long?;
        }

        public static int ObjectToInt(this object value)
        {
            return value as byte? ?? value as short? ?? value as int? ?? 0;
        }

        public static short ObjectToShort(this object value)
        {
            return value as byte? ?? value as short? ?? 0;
        }

        public static double ObjectToDouble(this object value)
        {
            return value as float? ?? value as double? ?? 0;
        }

        public static double ToPositive(this double value)
        {
            return value > 0 ? value : -value;
        }

        public static Dictionary<int, T> ToDictionary<T>(this IEnumerable<T> array)
        {
            return array
                .Select((v, i) => new { Key = i, Value = v })
                .ToDictionary(o => o.Key, o => o.Value);
        }
    }
}