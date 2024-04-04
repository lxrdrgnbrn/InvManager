[Setup]
; �������� ������ ����������
AppName=InvManager
; ������ ������ ����������
AppVersion=1.0
; ���������� ������������� ��� ������ ����������
AppId={{3A5B5B54-4470-4F3B-8D2C-2C3B1FA5E5C5}
; ���� �� ��������� ��� ��������� ������ ����������
DefaultDirName={pf}\InvManager
; ��� ������������ ����� ������ ����������
OutputBaseFilename=setup
; ����������� ������ ��� ���������� ������� ������������� �����
Compression=lzma
; �������� ��������� ������� ��� ������ ������ ������ ����������
CreateAppDir=yes
SetupIconFile=C:\oop-projects\simple-database\InvManager\Images\InvManager.ico
;------------------------------------------------------------------------------
;   ������������� ����� ��� �������� ���������
;------------------------------------------------------------------------------
[Languages]

Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";
;------------------------------------------------------------------------------
;   ����������� - ��������� ������, ������� ���� ��������� ��� ���������
;------------------------------------------------------------------------------
[Tasks]
; �������� ������ �� ������� �����
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
[Files]
; ������� �����, ������� ������ ���� �������� � ���������
; Source: "����\�\������\�����.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\oop-projects\simple-database\InvManager\bin\Release\Deploy\InvManager.exe"; DestDir: "{app}"; Flags: ignoreversion
; �������� ���������� .NET Framework
Source: "C:\Users\ilyai\Downloads\ndp481-x86-x64-allos-rus.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall

[Icons]
; �������� ������ �� ������� �����
Name: "{commondesktop}\InvManager"; Filename: "{app}\InvManager.exe"; IconFilename: "C:\oop-projects\simple-database\InvManager\Images\InvManager.ico"; Tasks: desktopicon

[Run]
; �������� ������� ��� ������� ����������� .NET Framework, ���� �� �� ����������
Filename: "{tmp}\ndp481-x86-x64-allos-rus.exe"; Parameters: "/q /norestart"; StatusMsg: "��������� .NET Framework..."
; ��������� ���� ���������� ����� ���������
Filename: "{app}\InvManager.exe"; Description: "{cm:LaunchProgram,InvManager}"; Flags: nowait postinstall skipifsilent
