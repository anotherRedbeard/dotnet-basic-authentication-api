# dotnet-basic-authentication-api

## .NET - Basic HTTP Authentication API

## Prerequisites

- You will need to create a new client_id and secret on an existing or new service principal.
  - Here is the command to create the new service principal

    ```# Bash script
      az ad sp create-for-rbac --name myServicePrincipalName1 --role reader --scopes /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG1
    ```

  - The output from this command will need to be saved into a github secret named `AZURE_CREDENTIALS_BASIC_AUTH`


Documentation at https://jasonwatmore.com/post/2021/12/20/net-6-basic-authentication-tutorial-with-example-api
