### Информация для сборки:
### Для слияния .exe и .dll в единый .exe можно воспльзоваться утилитой ILMerge, с помощью команды (пример):
ILMerge.exe Bridge.exe MetroFramework.Design.dll MetroFramework.dll MetroFramework.Fonts.dll /out:d:BridgeM.exe /target:winexe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"
### предварительно поместив целевой .exe в директорию: 
                                                  ..\System_for_experiments\Bridge\ILMerge 
### В качестве альтернативы можно воспользоваться .bat-файлом MergeScript