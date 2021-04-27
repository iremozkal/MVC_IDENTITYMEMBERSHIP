## MVC_IDENTITYMEMBERSHIP

Basic claim-based identity membership structure instead of session usage with Asp.Net MVC4 using Code First approach.  
The identity itself represents a single declaration that may have many claims associated with it. Claims; apart from roles, they are structures that enable us to keep information about the user and to authorize according to this information.  
A cookie value is used to perform the authorization function by using clauses, which are extra information defined for the user. Claims specially defined for the user who will log in to the system are added to the created Cookie value and accessed from there if necessary.  
There is no need to create your own webrole class with this structure. The id and name of a role are defined from IdentityRole class in Microsoft.AspNet.Identity.EntityFramework. Login and Register operations successfully runs. The user, admin and general pages accept people based on the user role. The input fields of login and register view models are controlled with System.ComponentModel.DataAnnotations.

### Technologies  

+ Asp.Net Web Application with .Net Framework 4.5 
+ Entity Framework 6.4.4
+ Microsoft.Aspnet.Identity.Core  2.2.3
+ Microsoft.Aspnet.EntityFramework 2.2.3
+ Microsoft.Owin 4.1.1
+ Owin 1.0
+ Bootstrap 4.5.3
+ Jquery 3.5.1
+ Visual Studio 2012


### Usage

```python
PM> update-database 	# creates database for the first time and
                        # updates the database when code changes.
```
