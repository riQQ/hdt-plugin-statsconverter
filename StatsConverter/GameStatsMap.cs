﻿using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Hearthstone_Deck_Tracker.Stats;
using System.Globalization;

namespace AndBurn.HDT.Plugins.StatsConverter
{
    public sealed class GameStatsMap : CsvClassMap<GameStats>
    {
        public GameStatsMap()
        {
            Map(m => m.DeckName).Name("Deck");
            Map(m => m.PlayerDeckVersionString).Name("Version");
            Map(m => m.PlayerHero).Name("Hero");
            Map(m => m.GameMode).Name("Mode");
            Map(m => m.RegionString).Name("Region");
            Map(m => m.RankString).Name("Rank");
            Map(m => m.StartTime).TypeConverterOption("yyyy-MM-dd HH:mm:ss").Name("Start Time");
            Map(m => m.GotCoin).Name("Coin");
            Map(m => m.OpponentHero).Name("Opponent Hero");
            Map(m => m.OpponentName).Name("Opponent Name");            
            Map(m => m.Turns);
            Map(m => m.SortableDuration).Name("Duration");
            Map(m => m.Result);
            Map(m => m.WasConceded).TypeConverter<BooleanConverter>().Name("Conceded");
            Map(m => m.Note);
        }
    }

    // "Trouble with CSV-Helper not converting bool values" http://stackoverflow.com/a/22998705
    public class BooleanConverter : DefaultTypeConverter
    {
        public override string ConvertToString(TypeConverterOptions options, object value)
        {
            if (value == null)
            {
                return "No";
            }

            var boolValue = (bool)value;

            return boolValue ? "Yes" : "No";
        }
    }
}
