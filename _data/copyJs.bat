
@ECHO OFF
rem use robocopy instead of xcopy

setlocal enabledelayedexpansion
cls

rem === Vote related ===
rem set toDirs=BaoAdm BaoCust
rem === Hr related ===
rem set toDirs=DbAdm Mantis TplMvc
rem === Bao related ===
rem set toDirs=BaoAdm BaoCust
rem === All ===
rem set toDirs=DbAdm Mantis TplMvc BaoAdm BaoCust
rem set toDirs=Mantis TplMvc BaoAdm BaoCust
set toDirs=DbAdm GroupProg AdoptAdm

set baseDir=d:\_project
set fromDir=%baseDir%\HrAdm\wwwroot

rem %%a must be one char !!
rem @ECHO ON
for %%a in (%toDirs%) do (
	set toDir=%baseDir%\%%a\wwwroot

	rem css & js(ico, base, lib)
	rem /XO for exclude if source files are old
	robocopy %fromDir%\css !toDir!\css icomoon.* /XO
	robocopy %fromDir%\css\base !toDir!\css\base *.css /XO
	robocopy %fromDir%\css\lib !toDir!\css\lib *.css /XO
	robocopy %fromDir%\js\base !toDir!\js\base *.js /XO
	robocopy %fromDir%\js\lib !toDir!\js\lib *.js /XO
	
	rem icomoon font
	robocopy %fromDir%\css\fonts !toDir!\css\fonts * /XO
	
	rem locale
	rem /XF for exclude file with name
	robocopy %fromDir%\locale\zh-TW !toDir!\locale\zh-TW * /XF summernote.js /XO
	robocopy %fromDir%\locale\zh-CN !toDir!\locale\zh-CN * /XF summernote.js /XO
	robocopy %fromDir%\locale\en-US !toDir!\locale\en-US * /XF summernote.js /XO
	
	echo.
)

@ECHO finish!!
pause