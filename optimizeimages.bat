@ECHO OFF
FOR /F "tokens=*" %%G IN ('dir /s /b /aa *.png') DO "C:\Checkout\bin\optipng\optipng.exe" -nc -nb -o7 -full %%G
