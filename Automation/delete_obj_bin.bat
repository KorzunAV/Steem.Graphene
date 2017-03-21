cd ..\Sources

FOR /R %%f IN (.) DO (
	if "%%~nf"=="obj" (
		rmdir /S /Q "%%f"
	)
	if "%%~nf"=="bin"	(
		rmdir /S /Q "%%f"
	)
	if "%%~nf"=="Bin"	(
		rmdir /S /Q "%%f"
	)
	if EXIST "_ReSharper.*" (
		rmdir /S /Q "_ReSharper.*"
	)
	
	if "%%~nf"=="PDFDocuments"	(
		rmdir /S /Q "%%f"
	)
	if "%%~nf"=="RTFDocuments"	(
		rmdir /S /Q "%%f"
	)
)

cd ..\Deploy\ProfInfo
DEL *.cab
DEL *.msi
DEL *.wixpdb

cd ..\Compare
DEL *.cab
DEL *.msi
DEL *.wixpdb