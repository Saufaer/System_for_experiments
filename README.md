# System_for_experiments
# ���������� ��� ���������� ������������� � Globalizer

### � ������� ������ ���������� ����� ��������� ������������ � ��������� �����������.
### ���� ������������ ����� ��������������� ������ example, ������� ��������� ���������� ������ ������ ������� Globalizer. ������� ����������: 
                                                 ..\example\BridgeM.exe 

### ���������� ��� ������:
### ��� ������� .exe � .dll � ������ .exe ����� �������������� �������� ILMerge, � ������� ������� (������):
ILMerge.exe Bridge.exe MetroFramework.Design.dll MetroFramework.dll MetroFramework.Fonts.dll Microsoft.Threading.Tasks.dll Microsoft.Threading.Tasks.Extensions.Desktop.dll Microsoft.Threading.Tasks.Extensions.dll System.IO.dll System.Runtime.dll System.Threading.Tasks.dll /out:d:BridgeM.exe /target:winexe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"
### �������������� �������� ������� .exe � ����������: 
                                                  ..\System_for_experiments\Bridge\ILMerge 
### � �������� ������������ ����� ��������������� .bat-������ MergeScript
