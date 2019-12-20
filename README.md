# AcmeWidgetCompany

This project is helps the user to register in company fun activities. 

the respective project is divided into below parts
1. Model Layer (AcmeWidgetBusinessModels) - this contain all the objects definition
2. data Layer (AcmeWidgetCompanyEmployeeActivity) - this is microservice webapi using Entity framework to connect the database.
3. Presentation Layer (AcmeWidgetUI) - this layer all the front end UI and using datalayer to get the data.

Note: to run the project in Visual Studio
1. Start the data Layer in debug mode
2. open command prompt navigate to AcmeWidgetUI\ClientApp then type ng serve --open
3. After 2nd Step go back to VS and right click on AcmeWidgetUI project >> Debug >> start a new instance

Requirements
VS 2019
.Net Core 3.1

