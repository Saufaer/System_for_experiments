# System_for_experiments
# ���������� ��� ���������� ������������� � Globalizer

### ���� ConfigReader.h ������ ���� ������� � examin. � ������� ������ ���������� ����� ��������� ������������ � ��������� �����������.
### ���� ������������ ����� ��������������� ������ example, ������� ��������� ���������� ������ ������ ������� Globalizer. ������� ����������: ..\example\Bridge.exe .

### ���������� ��� ������:
### ��� ������� .exe � .dll � ������ .exe ����� �������������� �������� ILMerge, � ������� ������� (������):
ILMerge.exe Bridge.exe MetroFramework.Design.dll MetroFramework.dll MetroFramework.Fonts.dll /out:d:BridgeM.exe /target:winexe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"
### �������������� �������� ������� .exe � ����������: 
                                                  ..\System_for_experiments\Bridge\ILMerge 

