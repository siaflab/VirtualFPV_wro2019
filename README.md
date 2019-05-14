# VirtualFPV WRO2019 Biennale version

Balloon trajectory realtime visualizer, simulator, log viewer for WRO2019 BIENNALE

![vfpv_wro2019.gif](vfpv_wro2019.gif)


download link for executable file:

macOS  
https://drive.google.com/open?id=1KX_R7Dkl1aG5dv3OmMRv_rufohkl-I1S

Windows 64bit  
https://drive.google.com/open?id=1n1vLBd-sSXkleht9W2EQzZxiChX9Tgd6


## 1. macOS trouble shooting

If System Status shows 'NG' like the following image

<img src="vfpv_wro2019_NG.png" alt="vfpv_wro2019_NG.png" width="300" height="230">

### Step1

create a new folder

### Step2

copy vfpv_wro2019.app file into the new folder using Finder

### Step3

copy the other files/folders into the new folder using Finder

execute vfpv_wro2019.app of the new folder.


The following is OK status image:

<img src="vfpv_wro2019_OK.png" alt="vfpv_wro2019_OK.png" width="300" height="200">


## 2. Log data and Simulation data

The tracking data is logged into logfile as './logdata/gps_data_yyyymmdd.txt'.

You can visualize logged data.
1. rename './logdata/gps_data_yyyymmdd.txt' to './logdata/gps_data.txt'
2. Data menu -> Run Demo  

You can visualize simulation data too.
1. simulate https://predict.habhub.org/ and save as CSV
2. move saved CSV file into ./simdata/flight_path.csv
3. Data menu -> Simulation


## 3. Customize

You can customize visualizer by 'config.txt'.

|keyword|value|
----|---- 
|OSCPort|OSC message receive port|
|Latitude|default latitude|
|Longitude|default longitude|
|Zoom|default zooming|
|Height|terrain height emphasis|
|PositionY|terrain altitude|
|ScaleX, ScaleY, ScaleZ|lat/lon to terrain coefficient parameter|

