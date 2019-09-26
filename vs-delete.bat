@echo off

for /r . %%a in (bin) do (  
  if exist %%a (
  echo "delete" %%a
  rd /s /q "%%a" 
 )
)

for /r . %%a in (obj) do (  
  if exist %%a (
  echo "delete" %%a
  rd /s /q "%%a" 
 )
)

pause