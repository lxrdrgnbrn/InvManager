[Setup]
; Название вашего приложения
AppName=InvManager
; Версия вашего приложения
AppVersion=1.0
; Уникальный идентификатор для вашего приложения
AppId={{3A5B5B54-4470-4F3B-8D2C-2C3B1FA5E5C5}
; Путь по умолчанию для установки вашего приложения
DefaultDirName={pf}\InvManager
; Имя исполняемого файла вашего приложения
OutputBaseFilename=setup
; Используйте сжатие для уменьшения размера установочного файла
Compression=lzma
; Создайте отдельный каталог для каждой версии вашего приложения
CreateAppDir=yes
SetupIconFile=C:\oop-projects\simple-database\InvManager\Images\InvManager.ico
;------------------------------------------------------------------------------
;   Устанавливаем языки для процесса установки
;------------------------------------------------------------------------------
[Languages]

Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl";
;------------------------------------------------------------------------------
;   Опционально - некоторые задачи, которые надо выполнить при установке
;------------------------------------------------------------------------------
[Tasks]
; Создание иконки на рабочем столе
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
[Files]
; Укажите файлы, которые должны быть включены в установку
; Source: "путь\к\вашему\файлу.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\oop-projects\simple-database\InvManager\bin\Release\Deploy\InvManager.exe"; DestDir: "{app}"; Flags: ignoreversion
; Добавьте установщик .NET Framework
Source: "C:\Users\ilyai\Downloads\ndp481-x86-x64-allos-rus.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall

[Icons]
; Создайте значок на рабочем столе
Name: "{commondesktop}\InvManager"; Filename: "{app}\InvManager.exe"; IconFilename: "C:\oop-projects\simple-database\InvManager\Images\InvManager.ico"; Tasks: desktopicon

[Run]
; Добавьте команду для запуска установщика .NET Framework, если он не установлен
Filename: "{tmp}\ndp481-x86-x64-allos-rus.exe"; Parameters: "/q /norestart"; StatusMsg: "Установка .NET Framework..."
; Запустите ваше приложение после установки
Filename: "{app}\InvManager.exe"; Description: "{cm:LaunchProgram,InvManager}"; Flags: nowait postinstall skipifsilent
