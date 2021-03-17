# Test-sislogik
Se presenta solución Test_T_02 Para la empresa sislogik
El aplicativo puede ser visualizado en producción en el siguiente link http://chrissmen-001-site11.gtempurl.com/
o bien podrá hacerse un deploy copiando el repositorio GITHUB  Chrissmen/Test-sislogic el contenido viene en un archivo 
"release-test-sislogik.zip"  en un Server IIS 8 / .NET 4.5

El script de la base de datos se encuentra en la carpeta "scriptDB" del mismo repositorio y puede aplicarse en MS SQL 2012

----------------------------------
Observaciones de QA
El archivo datosempleado_ej_te_02.xls facilitado mostró problemas de compatibilidad con motores OLEDB en 64 bits
por lo que generamos el archivo empleados365.xls con office 365 con la misma estructura en columnas y datos y pasó las pruebas unitarias
el archivo empleados365.xls se encuentra en la carpeta ejemplos
