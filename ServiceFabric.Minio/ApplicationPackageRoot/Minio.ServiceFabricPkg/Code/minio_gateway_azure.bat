@ECHO OFF
SETLOCAL
	SET "MINIO_ACCESS_KEY="
	SET "MINIO_SECRET_KEY="
	:: Make sure the --address port and Endpoint port in ServiceManifest.xml are the same
	CALL minio gateway azure --config-dir C:\Minio\ --address=:9000 
ENDLOCAL