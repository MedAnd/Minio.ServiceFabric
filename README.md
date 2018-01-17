Service Fabric Minio 
==============================================
Minio for Service Fabric is an open source object storage server with Amazon S3 compatible API. 

### Benefits of running Minio in Service Fabric
 * High availability. Service Fabric ensures that instances of Minio are running.
 * Health monitoring. Service Fabric health monitoring detects if Minio is running, and provides diagnostic information if there is a failure.
 * Application lifecycle management. Besides providing upgrades with no downtime, Service Fabric provides automatic rollback to the previous version if there is a bad health event reported during an upgrade.
 * Density. You can run multiple Minio instances in a cluster, which eliminates the need for each application to run on its own hardware.
 * Discoverability: Using REST you can call the Service Fabric Naming service to find instances of Minio in the cluster.

### Minio Pluggable Storage Backend
Minio supports filesystem and erasure code backends for DAS and JBODs, external storage backends such as NAS, Google Cloud Storage, and Azure Blob Storage via configuration only changes.

### Getting started
Download the latest version of [Minio](https://www.minio.io/downloads.html#download-server-windows) and copy minio.exe to the Minio.ServiceFabricPkg\Code folder:

[![Minio.ServiceFabricPkg\Code folder](https://raw.githubusercontent.com/MedAnd/Minio.ServiceFabric/master/Code_folder.png)]

### Configure Service Fabric Minio 
Open the ServiceManifest.xml file found in Minio.ServiceFabricPkg folder and in the EntryPoint section elect to run Minio in either Gateway or Server mode. 
Two example bat files are provide as guidance:

* minio_gateway_azure.bat - Minio acts as a gateway server and forwards data to Azure Blob Storage
* minio_server.bat - Minio will save data to the local Node's file-system or equivalent

If running Minio as a gateway to Azure Blob Storage, don't forget to set the MINIO_ACCESS_KEY (AccountName) and MINIO_SECRET_KEY (AccountKey) corresponding to your Azure Blob Storage account.
