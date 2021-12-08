# YieldBenchmarks

// * Summary *

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1348 (20H2/October2020Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  Job-ROBIOG : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

Runtime=.NET 6.0  RunStrategy=Throughput  

|                               Method |    Count |             Mean |            Error |           StdDev |           Median | Ratio | RatioSD |
|------------------------------------- |--------- |-----------------:|-----------------:|-----------------:|-----------------:|------:|--------:|
|                                Yield |      100 |        323.49 ns |         5.441 ns |         5.344 ns |        322.74 ns |  1.00 |    0.00 |
|                                Array |      100 |         87.27 ns |         1.678 ns |         1.932 ns |         86.27 ns |  0.27 |    0.01 |
|                    ArrayAsEnumerable |      100 |        393.13 ns |         7.830 ns |         9.322 ns |        395.34 ns |  1.22 |    0.03 |
|                     ListAsEnumerable |      100 |        694.61 ns |         6.296 ns |         5.581 ns |        695.77 ns |  2.15 |    0.04 |
|         ListAsEnumerablePreAllocated |      100 |        616.97 ns |         5.846 ns |         4.882 ns |        616.75 ns |  1.91 |    0.04 |
|                                 List |      100 |        292.27 ns |         3.277 ns |         2.558 ns |        291.40 ns |  0.90 |    0.02 |
|                     ListPreAllocated |      100 |        199.04 ns |         3.907 ns |         6.083 ns |        197.61 ns |  0.62 |    0.02 |
| CustomEnumerableWithStructEnumerator |      100 |        470.31 ns |         5.300 ns |         4.698 ns |        469.44 ns |  1.45 |    0.03 |
|  CustomEnumerableWithClassEnumerator |      100 |        331.07 ns |         2.735 ns |         2.558 ns |        330.30 ns |  1.02 |    0.02 |
|               CustomStructEnumerator |      100 |         27.92 ns |         0.420 ns |         0.372 ns |         27.98 ns |  0.09 |    0.00 |
|                CustomClassEnumerator |      100 |         39.15 ns |         0.672 ns |         0.561 ns |         39.13 ns |  0.12 |    0.00 |
|                                      |          |                  |                  |                  |                  |       |         |
|                                Yield |     1000 |      3,009.05 ns |        38.632 ns |        30.161 ns |      3,018.61 ns |  1.00 |    0.00 |
|                                Array |     1000 |        751.97 ns |        13.301 ns |        17.756 ns |        747.66 ns |  0.25 |    0.01 |
|                    ArrayAsEnumerable |     1000 |      3,847.77 ns |        49.729 ns |        46.517 ns |      3,826.70 ns |  1.28 |    0.02 |
|                     ListAsEnumerable |     1000 |      6,250.00 ns |       110.469 ns |       103.333 ns |      6,278.98 ns |  2.09 |    0.02 |
|         ListAsEnumerablePreAllocated |     1000 |      5,854.05 ns |        48.607 ns |        45.467 ns |      5,852.20 ns |  1.95 |    0.02 |
|                                 List |     1000 |      2,169.92 ns |        17.866 ns |        15.838 ns |      2,170.10 ns |  0.72 |    0.01 |
|                     ListPreAllocated |     1000 |      1,709.18 ns |         8.170 ns |         6.822 ns |      1,707.05 ns |  0.57 |    0.01 |
| CustomEnumerableWithStructEnumerator |     1000 |      4,257.71 ns |        66.800 ns |        62.485 ns |      4,242.87 ns |  1.41 |    0.02 |
|  CustomEnumerableWithClassEnumerator |     1000 |      2,962.27 ns |        35.880 ns |        33.562 ns |      2,965.58 ns |  0.99 |    0.02 |
|               CustomStructEnumerator |     1000 |        230.42 ns |         0.749 ns |         0.626 ns |        230.41 ns |  0.08 |    0.00 |
|                CustomClassEnumerator |     1000 |        295.12 ns |         5.497 ns |         5.142 ns |        297.75 ns |  0.10 |    0.00 |
|                                      |          |                  |                  |                  |                  |       |         |
|                                Yield |    10000 |     29,983.66 ns |        47.035 ns |        41.696 ns |     29,985.45 ns |  1.00 |    0.00 |
|                                Array |    10000 |      6,806.75 ns |        82.233 ns |        76.921 ns |      6,802.96 ns |  0.23 |    0.00 |
|                    ArrayAsEnumerable |    10000 |     37,152.16 ns |       728.566 ns |       681.501 ns |     37,395.62 ns |  1.24 |    0.02 |
|                     ListAsEnumerable |    10000 |     60,462.74 ns |       220.471 ns |       195.442 ns |     60,486.40 ns |  2.02 |    0.01 |
|         ListAsEnumerablePreAllocated |    10000 |     55,568.52 ns |       555.222 ns |       492.190 ns |     55,647.00 ns |  1.85 |    0.02 |
|                                 List |    10000 |     22,333.96 ns |       293.195 ns |       274.254 ns |     22,316.87 ns |  0.74 |    0.01 |
|                     ListPreAllocated |    10000 |     16,459.57 ns |       107.819 ns |        95.579 ns |     16,469.69 ns |  0.55 |    0.00 |
| CustomEnumerableWithStructEnumerator |    10000 |     44,527.81 ns |       883.572 ns |       907.363 ns |     44,310.67 ns |  1.48 |    0.03 |
|  CustomEnumerableWithClassEnumerator |    10000 |     30,653.31 ns |       579.333 ns |       643.927 ns |     30,623.20 ns |  1.02 |    0.02 |
|               CustomStructEnumerator |    10000 |      2,244.77 ns |        29.063 ns |        27.186 ns |      2,250.89 ns |  0.07 |    0.00 |
|                CustomClassEnumerator |    10000 |      2,826.18 ns |        49.125 ns |        41.021 ns |      2,846.22 ns |  0.09 |    0.00 |
|                                      |          |                  |                  |                  |                  |       |         |
|                                Yield |   100000 |    297,542.05 ns |     3,438.966 ns |     3,216.811 ns |    298,662.01 ns |  1.00 |    0.00 |
|                                Array |   100000 |    147,588.47 ns |     2,496.082 ns |     2,084.342 ns |    148,072.36 ns |  0.50 |    0.01 |
|                    ArrayAsEnumerable |   100000 |    438,420.08 ns |     1,531.732 ns |     1,357.840 ns |    438,237.06 ns |  1.47 |    0.02 |
|                     ListAsEnumerable |   100000 |    686,192.31 ns |     2,749.833 ns |     2,437.656 ns |    685,464.55 ns |  2.31 |    0.03 |
|         ListAsEnumerablePreAllocated |   100000 |    609,270.77 ns |     8,498.192 ns |     7,533.426 ns |    611,159.42 ns |  2.05 |    0.02 |
|                                 List |   100000 |    324,619.10 ns |     2,232.381 ns |     2,088.171 ns |    324,205.57 ns |  1.09 |    0.01 |
|                     ListPreAllocated |   100000 |    190,926.23 ns |     2,732.167 ns |     2,281.483 ns |    190,903.12 ns |  0.64 |    0.01 |
| CustomEnumerableWithStructEnumerator |   100000 |    433,648.87 ns |     1,091.738 ns |       852.357 ns |    433,612.92 ns |  1.46 |    0.02 |
|  CustomEnumerableWithClassEnumerator |   100000 |    296,065.56 ns |     5,097.317 ns |     4,768.033 ns |    298,236.43 ns |  1.00 |    0.01 |
|               CustomStructEnumerator |   100000 |     22,522.82 ns |        64.900 ns |        54.195 ns |     22,515.25 ns |  0.08 |    0.00 |
|                CustomClassEnumerator |   100000 |     28,289.81 ns |       316.850 ns |       280.879 ns |     28,343.98 ns |  0.10 |    0.00 |
|                                      |          |                  |                  |                  |                  |       |         |
|                                Yield |  1000000 |  2,989,156.08 ns |    16,765.536 ns |    15,682.493 ns |  2,991,361.91 ns |  1.00 |    0.00 |
|                                Array |  1000000 |    775,294.94 ns |     9,064.444 ns |     7,569.221 ns |    775,597.46 ns |  0.26 |    0.00 |
|                    ArrayAsEnumerable |  1000000 |  3,520,008.54 ns |    66,862.292 ns |    65,667.711 ns |  3,550,180.86 ns |  1.18 |    0.02 |
|                     ListAsEnumerable |  1000000 | 12,370,020.12 ns |   526,847.300 ns | 1,553,421.150 ns | 12,814,113.28 ns |  3.18 |    0.71 |
|         ListAsEnumerablePreAllocated |  1000000 |  5,391,812.56 ns |    49,574.305 ns |    43,946.330 ns |  5,393,511.72 ns |  1.80 |    0.01 |
|                                 List |  1000000 |  8,880,658.66 ns |   239,008.973 ns |   704,723.349 ns |  8,949,829.69 ns |  2.92 |    0.36 |
|                     ListPreAllocated |  1000000 |  1,706,143.67 ns |    23,577.076 ns |    20,900.464 ns |  1,709,267.38 ns |  0.57 |    0.01 |
| CustomEnumerableWithStructEnumerator |  1000000 |  4,314,318.14 ns |    70,385.412 ns |    62,394.834 ns |  4,330,433.20 ns |  1.44 |    0.02 |
|  CustomEnumerableWithClassEnumerator |  1000000 |  2,980,619.67 ns |     5,188.429 ns |     4,599.407 ns |  2,981,454.10 ns |  1.00 |    0.01 |
|               CustomStructEnumerator |  1000000 |    225,562.93 ns |     1,107.806 ns |     1,036.242 ns |    225,156.86 ns |  0.08 |    0.00 |
|                CustomClassEnumerator |  1000000 |    279,812.22 ns |     5,416.337 ns |     5,066.445 ns |    282,959.47 ns |  0.09 |    0.00 |
|                                      |          |                  |                  |                  |                  |       |         |
|                                Yield | 10000000 | 29,931,733.33 ns |   183,994.593 ns |   172,108.656 ns | 29,963,725.00 ns |  1.00 |    0.00 |
|                                Array | 10000000 | 10,680,494.87 ns |   138,257.324 ns |   122,561.516 ns | 10,669,801.56 ns |  0.36 |    0.00 |
|                    ArrayAsEnumerable | 10000000 | 38,083,218.33 ns |   512,069.952 ns |   478,990.551 ns | 38,223,100.00 ns |  1.27 |    0.02 |
|                     ListAsEnumerable | 10000000 | 95,055,335.56 ns |   830,092.872 ns |   776,469.387 ns | 95,239,733.33 ns |  3.18 |    0.02 |
|         ListAsEnumerablePreAllocated | 10000000 | 56,966,400.00 ns | 1,105,923.268 ns | 1,034,481.311 ns | 57,256,662.50 ns |  1.90 |    0.03 |
|                                 List | 10000000 | 59,180,371.43 ns |   878,574.487 ns |   778,833.398 ns | 59,021,866.67 ns |  1.98 |    0.02 |
|                     ListPreAllocated | 10000000 | 19,905,609.58 ns |   193,580.156 ns |   181,074.998 ns | 19,872,903.12 ns |  0.67 |    0.01 |
| CustomEnumerableWithStructEnumerator | 10000000 | 41,019,379.67 ns |   323,021.867 ns |   286,350.471 ns | 41,106,750.00 ns |  1.37 |    0.00 |
|  CustomEnumerableWithClassEnumerator | 10000000 | 29,727,891.47 ns |    24,553.040 ns |    20,502.900 ns | 29,728,829.69 ns |  0.99 |    0.01 |
|               CustomStructEnumerator | 10000000 |  2,237,885.83 ns |    31,847.156 ns |    28,231.675 ns |  2,247,300.78 ns |  0.07 |    0.00 |
|                CustomClassEnumerator | 10000000 |  2,822,536.16 ns |    31,452.209 ns |    27,881.564 ns |  2,831,136.33 ns |  0.09 |    0.00 |
