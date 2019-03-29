# System_for_experiments
# Подсистема для проведения экспериментов в Globalizer

### Файл ConfigReader.h должен быть добвлен в examin. С помощью данной подсистемы можно проводить эксперименты с заданными настройками.
### Ради демонстрации можно воспользоваться папкой example, которая имитирует директорию сборки общего проекта Globalizer. Целевое приложение: ..\example\Bridge.exe .

### Информация для сборки:
### Для слияния .exe и .dll в единый .exe можно воспльзоваться утилитой ILMerge, с помощью команды (пример):
ILMerge.exe Bridge.exe MetroFramework.Design.dll MetroFramework.dll MetroFramework.Fonts.dll /out:d:BridgeM.exe /target:winexe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"
### предварительно поместив целевой .exe в директорию: 
                                                  ..\System_for_experiments\Bridge\ILMerge 

