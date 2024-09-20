cd BizSocket
dotnet build
cd ../BizHawk
.\EmuHawk.exe --open-ext-tool-dll=BizSocket
exit /b 1