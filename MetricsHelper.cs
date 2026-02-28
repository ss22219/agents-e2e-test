using System;
using System.Collections.Generic;
using System.Linq;

public static class MetricsHelper
{
    public static Counter CreateCounter(string name) => new Counter(name);
    public static Gauge CreateGauge(string name) => new Gauge(name);
    public static Histogram CreateHistogram(string name) => new Histogram(name);

    public class Counter
    {
        public string Name { get; }
        private long _value;

        public Counter(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Increment() => _value++;
        public void Add(long value) => _value += value;
        public long Value => _value;
    }

    public class Gauge
    {
        public string Name { get; }
        private double _value;

        public Gauge(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Set(double value) => _value = value;
        public double Value => _value;
    }

    public class Histogram
    {
        public string Name { get; }
        private readonly List<double> _values = new List<double>();

        public Histogram(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Observe(double value) => _values.Add(value);
        public int Count => _values.Count;
        public double Sum => _values.Sum();
        public double Mean => Count > 0 ? Sum / Count : 0;
    }
}
