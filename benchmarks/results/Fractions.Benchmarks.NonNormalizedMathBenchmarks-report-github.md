```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
AMD Ryzen 9 7900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.300
  [Host]                      : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET 8.0           : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  ShortRun-.NET Framework 4.8 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256

IterationCount=3  LaunchCount=1  WarmupCount=3  

```
| Method   | Job                         | Runtime            | a                    | b                    | Mean       | Error      | StdDev    | Gen0   | Allocated |
|--------- |---------------------------- |------------------- |--------------------- |--------------------- |-----------:|-----------:|----------:|-------:|----------:|
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1000(...)000/1 [41]** | **1/1000000000000**      |  **62.296 ns** |  **3.8531 ns** | **0.2112 ns** | **0.0024** |      **40 B** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1000(...)000/1 [41] | 1/1000000000000      |  44.248 ns |  3.1319 ns | 0.1717 ns | 0.0029 |      48 B |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 121.602 ns |  1.3574 ns | 0.0744 ns | 0.0126 |      80 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1000(...)000/1 [41] | 1/1000000000000      | 108.669 ns | 17.2412 ns | 0.9450 ns | 0.0076 |      48 B |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-1024/1**              | **-1/1024**              |  **35.979 ns** |  **4.6775 ns** | **0.2564 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -1024/1              | -1/1024              |  28.607 ns |  0.4970 ns | 0.0272 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  79.185 ns | 10.6374 ns | 0.5831 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -1024/1              | -1/1024              |  72.565 ns |  3.1611 ns | 0.1733 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **-45/1**                | **1/6**                  |  **52.368 ns** |  **3.2978 ns** | **0.1808 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | -45/1                | 1/6                  |  27.783 ns |  1.8219 ns | 0.0999 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  | 115.642 ns |  4.0982 ns | 0.2246 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | -45/1                | 1/6                  |  72.781 ns |  1.0475 ns | 0.0574 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/-96**               | **36/-96**               |  **68.894 ns** |  **3.3638 ns** | **0.1844 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/-96               | 36/-96               |  53.958 ns |  6.1139 ns | 0.3351 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 195.245 ns |  2.8700 ns | 0.1573 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/-96               | 36/-96               | 129.785 ns | 10.5112 ns | 0.5762 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **0/1**                  | **1/1**                  |   **7.377 ns** |  **1.8221 ns** | **0.0999 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 0/1                  | 1/1                  |   7.901 ns |  1.5166 ns | 0.0831 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  26.878 ns |  3.8287 ns | 0.2099 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 0/1                  | 1/1                  |  28.899 ns |  0.2597 ns | 0.0142 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **77/3600**              | **37/3600**              |  **75.298 ns** | **37.2122 ns** | **2.0397 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 77/3600              | 37/3600              |  48.625 ns |  0.9268 ns | 0.0508 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 200.208 ns |  5.5002 ns | 0.3015 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 77/3600              | 37/3600              | 130.841 ns |  6.2828 ns | 0.3444 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **135/1000**             | **76/1000**              |  **66.912 ns** |  **1.3487 ns** | **0.0739 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 135/1000             | 76/1000              |  49.392 ns |  1.5547 ns | 0.0852 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 198.762 ns | 14.0523 ns | 0.7703 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 135/1000             | 76/1000              | 134.174 ns | 14.9916 ns | 0.8217 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **27/200**               | **19/250**               |  **68.122 ns** |  **7.7142 ns** | **0.4228 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 27/200               | 19/250               |  70.545 ns |  1.2203 ns | 0.0669 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 197.263 ns |  9.5259 ns | 0.5221 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 27/200               | 19/250               | 201.861 ns | 14.3767 ns | 0.7880 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **42/66**                | **36/96**                |  **72.581 ns** |  **1.5156 ns** | **0.0831 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 42/66                | 36/96                |  70.302 ns |  2.1135 ns | 0.1158 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 199.112 ns | 22.2447 ns | 1.2193 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 42/66                | 36/96                | 203.630 ns | 39.5360 ns | 2.1671 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **70742(...)85248 [33]** | **70742(...)70496 [33]** | **154.565 ns** |  **9.1999 ns** | **0.5043 ns** | **0.0162** |     **272 B** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 70742(...)85248 [33] | 70742(...)70496 [33] |  67.042 ns | 11.3982 ns | 0.6248 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 367.237 ns | 62.7151 ns | 3.4376 ns | 0.0420 |     265 B |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 70742(...)85248 [33] | 70742(...)70496 [33] | 154.197 ns | 10.0746 ns | 0.5522 ns | 0.0100 |      64 B |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **NaN**                  |   **8.140 ns** |  **1.7144 ns** | **0.0940 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | NaN                  |   6.264 ns |  0.5303 ns | 0.0291 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  34.951 ns |  0.3209 ns | 0.0176 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | NaN                  |  25.841 ns |  0.8368 ns | 0.0459 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **-∞**                   |   **8.350 ns** |  **3.6662 ns** | **0.2010 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | -∞                   |   6.051 ns |  0.7638 ns | 0.0419 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  30.078 ns |  1.1539 ns | 0.0632 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | -∞                   |  25.858 ns |  2.6613 ns | 0.1459 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **245850922/78256779**   | **0**                    |   **7.498 ns** |  **1.3841 ns** | **0.0759 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 245850922/78256779   | 0                    |   8.983 ns |  1.0427 ns | 0.0572 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  26.782 ns |  0.7392 ns | 0.0405 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 245850922/78256779   | 0                    |  32.613 ns |  5.2746 ns | 0.2891 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **97/1**                 | **89/1**                 |  **23.713 ns** |  **1.4399 ns** | **0.0789 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 97/1                 | 89/1                 |  38.913 ns |  1.7378 ns | 0.0953 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 |  71.970 ns |  7.6101 ns | 0.4171 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 97/1                 | 89/1                 | 113.350 ns |  2.7382 ns | 0.1501 ns |      - |         - |
| **Multiply** | **ShortRun-.NET 8.0**           | **.NET 8.0**           | **1000/1**               | **100/1**                |  **23.868 ns** |  **1.2896 ns** | **0.0707 ns** |      **-** |         **-** |
| Divide   | ShortRun-.NET 8.0           | .NET 8.0           | 1000/1               | 100/1                |  28.747 ns |  3.5493 ns | 0.1946 ns |      - |         - |
| Multiply | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  70.147 ns |  5.6152 ns | 0.3078 ns |      - |         - |
| Divide   | ShortRun-.NET Framework 4.8 | .NET Framework 4.8 | 1000/1               | 100/1                |  80.492 ns |  4.2057 ns | 0.2305 ns |      - |         - |
