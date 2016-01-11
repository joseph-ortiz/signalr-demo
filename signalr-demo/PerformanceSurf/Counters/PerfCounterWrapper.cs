﻿using System.Diagnostics;

namespace PerformanceSurf.Counters
{
    public class PerfCounterWrapper
    {
        public string Name { get; set; }
        public float Value {
            get { return _counter.NextValue(); }
        }
        PerformanceCounter _counter;

        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            _counter = new PerformanceCounter(category, counter, instance, readOnly:true);
            Name = name;
        }
    }
}