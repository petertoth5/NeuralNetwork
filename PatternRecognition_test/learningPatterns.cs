using System;
using System.Collections.Generic;
using System.Text;

namespace PatternRecognition_test
{
    public class learningPatterns
    {
        public static double low            = -1.0;
        public static double lowQuarter     = 0.25;
        public static double mid            = 0.5;
        public static double highQuarter    = 0.75;
        public static double high           = 1.0;

        public double[][] inputPatterns = new double[][] {    new double[] {low,low},
                                                              new double[] {low,high},
                                                              new double[] {high,high},
                                                              new double[] {high,low}
                                                        };

        public double[][] outputPatterns = new double[][]   {new double[] {low},
                                                             new double[] {high},
                                                             new double[] {low},
                                                             new double[] {high}
                                                            };

        public double[][] inputPatterns2 = new double[][] {   new double[] {  Math.PI},
                                                              new double[] {  Math.PI / 2},
                                                              new double[] {  Math.PI / 4},
                                                              new double[] {  Math.PI / 8},
                                                              new double[] {- Math.PI},
                                                              new double[] {- Math.PI / 2},
                                                              new double[] {- Math.PI / 4},
                                                              new double[] {- Math.PI / 8}
                                                        };

        public double[][] outputPatterns2 = new double[][]   {new double[] {Math.Sin(Math.PI)},
                                                              new double[] {Math.Sin(Math.PI / 2)},
                                                              new double[] {Math.Sin(Math.PI / 4)},
                                                              new double[] {Math.Sin(Math.PI / 8)},
                                                              new double[] {Math.Sin(- Math.PI)},
                                                              new double[] {Math.Sin(- Math.PI / 2)},
                                                              new double[] {Math.Sin(- Math.PI / 4)},
                                                              new double[] {Math.Sin(- Math.PI / 8)}
                                                            };

    }
}
