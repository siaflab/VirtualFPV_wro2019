VirtualFPV
===
[Space Moere Project](http://space-moere.org) telecoding balloon trajectory realtime visualizer, simulator, log viewer

![image](demo.gif)

## FEATURES

- Balloon trajectory realtime visualize via OSC message
- Virtual FPV camera
- Simulation data file visualize (CUSF Landing Predictor http://predict.habhub.org/ )
- Demo mode: trajectory log file visualize

## REQUIREMENT

- Mac OS X, Windows 64bit with high spec GPU
- Unity 2017 or later

## DEPENDENCIES

You need to import the following libraries to build this program:

- [Post Processing Stack v1](https://assetstore.unity.com/packages/essentials/post-processing-stack-83912)
- [UnityOSC](https://github.com/jorgegarcia/UnityOSC)
- [Mapbox for Unity](https://www.mapbox.com/unity/)

## OSC INTERFACE

Port Number: 32000

| command | description | example |
----|----|----
| /data | realtime trajectory visualize | /data "1,1,-42,03:30:00,43.126652,141.430371,6M,\x00\r\n" |
| /reset | reset command | /reset |
| /sim | simulation trajectory command | /sim "1503342000,43.1221,141.426,62" |
| /simclear | clear simulation trajectory | /simclear |

## CREDIT
VirtualFPV program licensed under MIT License.  
https://github.com/siaflab/VirtualFPV_wro2019

Space Moere Project  
ARTSAT x SIAF Lab  
http://space-moere.org

3D map licensed by
Mapbox  
https://www.mapbox.com/
