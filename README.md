[![Build Status](https://travis-ci.com/edalmasso/Auth0.svg?branch=master)](https://travis-ci.com/edalmasso/Auth0)

# Smart Apartment Data Api

## Features:
- Auth0 using M2M
- API versioning
- Testing
- Swashbuckle
- Docker
- Use of SecureString to protect sensitive data
- Entities and DTOs

### Auth0 using Machine to Machine communication

It is assumed that the API will be consumed by another machine.
The code shows three different cases:
- Unsecured endpoint
- Secured endpoint (only needs authentication)
- Secured endpoint with scopes (includes resource based authorization using policies)

### API versioning

API endpoint uses versioning like /api/v1/ or /api/v2/ for easy extension
API also has a Controller (NotVersionedController) that has no versioning

### Testing

Testing project is configured to run against a docker container running on Azure
- Tests can be executed because they are working with the docker container
- Public unsecured API endpoint: https://smartapartmentdataapi20191031094229.azurewebsites.net/api/v1/customer
- It is also possible to create and run Postman tests scripts and add them to the project. These tests scripts can be executed as part of the CI/CD pipeline

### Swashbuckle

API documentation created using Swashbuckle:
- Swashbuckle URL: https://smartapartmentdataapi20191031094229.azurewebsites.net/swagger
- Swashbuckle is configured to show XML comments

### Docker

The APi project has a Dockerfile to publish the image to the registry and start a container

### Use of SecureString to protect sensitive data

Because the project is using sensitive data (private key and bearer token) and the memory of the server can be compromised, the use of SecureStrings is a good choice to add a layer of security.
Only in the test project, the use of SecureString is shown. In a production enviroment, the secret key should be encrypted in a file. This was not implemented because the encrypted file will only work in the computer where it was created(can not be decrypted on another computer).

### Entities and DTOs

The SmartApartmentData.Entities project has the POCO entities than can be used by Entity Framework to create the database.
The SmartApartmentData.Entities.Dto has the DTOs required for specific actions that it is not needed to expose all fields of entities. Useful to have a typed class when developing too.
