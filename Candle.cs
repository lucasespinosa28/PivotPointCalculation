using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PivotPointCalculation
{
    public class Candle
    {
        
        public string timestamp { get; set; }
        
        public string symbol { get; set; }
        
        public decimal open { get; set; }
        
        public decimal high { get; set; }
        
        public decimal low { get; set; }
        
        public decimal close { get; set; }
        
        public decimal trades { get; set; }
        
        public decimal volume { get; set; }
        
        public decimal vwap { get; set; }
        
        public decimal lastSize { get; set; }
        
        public object turnover { get; set; }
        
        public decimal homeNotional { get; set; }
        
        public decimal foreignNotional { get; set; }

    }
}
