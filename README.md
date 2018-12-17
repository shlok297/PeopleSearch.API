# PeopleSearchApplicationAPI
ASP.NET Core web API application

This API performs Create and Read operations

Postman testing
---------------

***** For testing Create (Post) *****

  http://localhost:[REPLACEME]/api/users/

  example json body:
                  {
                    "firstName": "TestFirstName",
                    "LastName": "TestLastName",
                    "Age": 20,
                    "StreetAddress": "xyz",
                    "City": "SLC",
                    "Zip": "84102",
                    "Country": "USA",
                    "Interests": "ASP.NET Core",
                    "State": "UT",
                    "Image": "image conversion happens on the front end"
                  }

***** For testing Read (Get) *****

  http://localhost:[REPLACEME]/api/users/{searchString}
