﻿namespace Core.Domain.Statistics.Models
{
    using Common.Domain;
    using System;
    using System.Collections.Generic;

    public class StatisticsData : IInitialData
    {
        public Type EntityType => typeof(Statistics);

        public IEnumerable<object> GetData()
            => new List<Statistics>
            {
                new Statistics()
            };
    }
}
