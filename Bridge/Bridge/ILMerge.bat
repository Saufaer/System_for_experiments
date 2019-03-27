ECHO parameter=1%1
CD %1
D:
COPY Bridge.exe temp.exe
"..\..\ILMerge.exe" /out:"Bridge.exe" "temp.exe" "MetroFramework.Design.dll"
DEL temp.exe