# System_for_experiments

# System for conducting experiments in globalizer

## File ConfigReader.h goto examin. 

## Use Bridge for creating config files and run main project 

## For merging .exe and .dll's to single .exe need use command:
### ILMerge.exe Bridge.exe MetroFramework.Design.dll MetroFramework.dll MetroFramework.Fonts.dll /out:d:BridgeM.exe /target:winexe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"
### you can put a target .exe in: 
..\System_for_experiments\Bridge\ILMerge 
### and to do this