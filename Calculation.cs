using System;

namespace PivotPointCalculation
{
    public class Calculation
    {
        //Pivot point (PP) = (High + Low + Close) / 3
        public decimal PivotPoint(decimal close, decimal high, decimal low) => (close + high + low) / 3;

        public decimal Resistance(int level,decimal close, decimal high, decimal low)
        {
            decimal PP = (high + low + close) / 3;
            switch (level)
            {
                default:
                    //First resistance(R1) = (2 x PP) – Low
                    return (2 * PP) - low;
                case (2):
                    //Second resistance(R2) = PP + (High – Low)
                    return PP + (high - low);
                case (3):
                    //Third resistance(R3) = High + 2(PP – Low)
                    return PP + (2 * (high - low));

            }
        }
        public decimal Support(int level, decimal close, decimal high, decimal low)
        {
            decimal PP = (high + low + close) / 3;
            switch (level)
            {
                default:
                    //First support(S1) = (2 x PP) – High
                    return (2 * PP) - high;
                case (2):
                    //Second support(S2) = PP – (High – Low)
                    return PP - (high - low);
                case (3):
                    //Third support(S3) = Low – 2(High – PP)
                    return low - (2 * (high - low));

            }
        }
    }
}
