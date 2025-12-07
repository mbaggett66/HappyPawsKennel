Happy Paws Kennel
by Andie Baggett
COP 2839

Project Summary:

Happy Paws Kennel is a small ASP.NET Core MVC application designed to make running a dog boarding kennel 
more organized and efficient for the staff members. Instead of dealing with paperwork and spreadsheets, 
the app gives staff an easy system to register dogs, assign them to kennels, check availability, and manage 
check-ins and check-outs. Everything is kept in one place, which helps reduce problems and keep daily kennel 
operations running smoothly.
The Happy Paws Kennel project is also a way to put key ASP.NET Core MVC concepts into practice. It uses proper 
modeling to represent dogs, kennels, and staff actions, and follows separation of concerns by organizing the 
code into models, views, and controllers. CRUD functionality is built in so staff can create, edit, view, and 
remove records easily. The app also uses diagnostics and logging to help with troubleshooting and tracking issues 
as they arise. The project also includes stored procedures to handle certain operations in a clean and secure manner.
Overall, Happy Paws Kennel is both a functional tool for managing kennel tasks and a hands-on example of building a 
structured, testable web application with ASP.NET Core MVC. It’s practical in a real world setting, easy to use, 
and designed with everyday use in mind.



Planning Table:

| Week | Concept               | Feature                              | Goal                                           | Acceptance Criteria                                                                 | Evidence in README.md                     | Test Plan                                                                 |
|------|------------------------|--------------------------------------|------------------------------------------------|--------------------------------------------------------------------------------------|-------------------------------------------|---------------------------------------------------------------------------|
| 10   | Modeling              | Create 'Dog' and 'Kennel' entities.  | App can store dogs and assign them to kennels. | - Dogs table created<br>- Kennels table created<br>- Relationship works              | Implemented code; README write-up; screenshots. | Run migration; check database tables.                                     |
| 11   | Separation of Concerns / DI | Add 'IDogService' for kennel assignment. | Move logic from controller into a service.     | - IDogService interface exists<br>- Controller uses constructor injection<br>- Assignment logic works | Implemented code; README write-up; screenshots. | Call service methods from controller endpoints.                           |
| 12   | CRUD                  | Create/Edit/Delete dog and kennel pages. | Allow staff to manage dog records and kennel assignments through a web UI. | - Create/edit/delete pages exist<br>- Changes persist to DB<br>- Kennel occupancy updates correctly | Implemented code; README write-up; screenshots. | Add a dog, edit fields, delete, and confirm database changes.             |
| 13   | Diagnostics           | Add `/healthz` endpoint.             | Health check to verify DB connectivity.        | - Endpoint returns healthy when DB is reachable<br>- Returns unhealthy if DB is unavailable | Implemented code; README write-up; screenshots. | Stop DB, call `/healthz`.                                                 |
| 14   | Logging               | Log dog check-ins & check-outs.      | Track kennel operations with structured logs.  | - Log messages created on check-in/out<br>- Logs include dog and kennel information   | Implemented code; README write-up; screenshots. | Perform check-in/out operations and check log output.                     |
| 15   | Stored Procedures     | Top kennels by occupancy.            | Show kennels with the highest occupancy.       | - Stored procedure executes correctly<br>- Results displayed                         | Implemented code; README write-up; screenshots. | Run stored procedure in app and verify result matches DB query.           |
| 16   | Deployment            | Deploy app to Azure App Service.     | Make the application accessible.               | - App Service created<br>- App runs on Azure<br>- `/healthz` reachable<br>- One path works | Implemented code; README write-up; screenshots; deployed URL. | Visit URL; check `/healthz` and ensure page loads.                        |


Week 10 - Modeling:

This week’s focus was on modeling, specifically creating the Dog and Kennel entities and setting up the relationships 
between them. The goal was to give the application the ability to store information about dogs and assign them to kennels, 
forming the foundation for later features like check-ins, occupancy tracking, and service-based logic.

I started by defining the Dog and Kennel model classes, giving each their necessary properties such as DogId, Name, Breed, 
and KennelId for dogs, and KennelId, Name, and Capacity for kennels. I then added navigation properties to establish a 
one-to-many relationship, allowing each kennel to contain multiple dogs while each dog belongs to one kennel. After updating 
the DbContext to include DbSet<Dog> and DbSet<Kennel>, I created and ran a migration to generate the corresponding tables in 
SQL Server.

Once the migration was complete, I verified that both the Dogs and Kennels tables appeared correctly in the database and that 
their foreign key relationship was properly configured. This step confirmed that the model structure was functioning as intended 
and that Entity Framework Core was successfully mapping the relationships.

Overall, Week 10 solidified the foundation of the application’s data layer. By implementing the core entities and ensuring the 
database schema reflected the model design, the project is now ready to build on this structure for the future weeks.


Week 11 – Separation of Concerns / Dependency Injection:

This week, I implemented Separation of Concerns by moving logic out of the controller and into a service class. The idea was to 
make the controller lighter and the code easier to maintain. I created a new service interface and a concrete implementation called 
KennelService, which handles logic related to kennel availability. The service communicates directly with the database context and 
provides a simple method for retrieving the number of available kennels.

After creating the service, I registered it in the DI container using a scoped lifetime, which allows it to be created once per HTTP 
request. Then, I injected it into the KennelsController and used it inside the Index action. The controller now simply calls the 
service method and passes the result to the view.

One of the biggest takeaways from this week was understanding how dependency injection improves maintainability. 
By keeping the data access logic separate, I could easily replace the service for testing purposes without affecting the 
rest of the application. This pattern can be used in real-world projects, and it helps create more modular, flexible, and 
professional ASP.NET applications.


Week 12 - CRUD

For Week 12, I focused on implementing CRUD (Create, Read, Update, Delete) functionality for the Dog entity in the HappyPaws Kennel
web application. This enhancement allows users to add new dogs, view detailed information, update existing records, and remove dogs
directly through the user-friendly web interface. To ensure the program was efficient and responsive, I utilized Entity Framework Core with
asynchronous methods such as ToListAsync, FindAsync, and SaveChangesAsync, whichenables smooth data retrieval and updates without blocking 
the application.

I scaffolded the DogController to manage user interactions and linked it to the HappyPawsContext database context to handle all data-related 
operations. I also added form validation to the Create and Edit views, ensuring that users provide accurate and complete information 
before submitting changes. This prevents common data entry errors and improves overall reliability.

Once all of the components were connected and tested, the Dog management system became fully functional within the HappyPaws Kennel application. 
The kennel staff can now easily manage dog records from one centralized place, making it much more practical for tracking kennel occupancy and daily 
operations. This week's additions represent a key step in creating a more interactive and efficient kennel management tool.


Week 13 – Diagnostics 

This week, I implemented diagnostics for my HappyPawsKennel application by adding an operational /healthz endpoint that reports the health of at least
one real dependency, in this case, the application’s SQL Server database. The goal of this week was to create a reliable way to check whether the system
is functioning correctly without exposing any sensitive information.
Since .NET 9 does not currently support the AddDbContextCheck extension found in earlier versions, I created a custom DbHealthCheck class that implements
the IHealthCheck interface. Inside this health check, I used Entity Framework Core’s Database.CanConnectAsync() method to verify that the application can
successfully connect to the database. If the connection succeeds, the health check reports a “Healthy” status; if not, it returns “Unhealthy,” along with
a short description that helps identify the issue.
I then mapped a custom /healthz endpoint and added a JSON response writer. The output includes overall system status, individual check results, and
execution durations—all useful for troubleshooting but intentionally designed not to leak secrets or internal exception details.
Implementing this feature helped me understand how health checks are used in real-world production systems, especially in environments where automatic
monitoring tools, such as Azure, need a reliable way to determine whether an app instance is ready or functional. I can see how this approach contributes
to building more stable and maintainable applications.


Week 14- Logging

This week I focused on adding structured logging throughout my HappyPawsKennel application to improve observability, track key actions, and support
troubleshooting. Logging is essential in real-world applications because it allows developers and administrators to understand what the system is doing,
detect failures early, and diagnose issues quickly. For this project, I implemented both success-path and error-path logs, added important contextual details,
and verified that logs correctly appear in the development console at runtime.
I began by configuring the logging providers in Program.cs, enabling both console and debug output. This ensured that logs generated by the application, as
well as by Entity Framework Core, would appear in the black console window when running the project. Next, I injected ILogger<DogsController> into the
DogsController and added structured logs to the Create action. When a dog is successfully added to the database, the system logs an informational message
containing the dog’s data as structured fields. If an exception occurs, an error log is written that includes the exception details and the attempted dog data.
I validated the logging by running the application, creating and deleting dogs, and confirming that SQL queries and structured log messages appeared in the
console. These logs now provide clear visibility into application behavior and would be very useful in a production environment for diagnosing issues such as
failing database operations or unexpected exceptions.


Week 15 – Stored Procedures 

For Week 15, I implemented stored procedures in the HappyPawsKennel application to demonstrate server-side querying using SQL and EF Core. I created a stored
procedure named GetDogsByBreed, which accepts a breed parameter and returns matching dog records. This procedure was added directly to my SQL Server database
and committed to the project in a /DatabaseScripts folder for reference.
To integrate the procedure into the app, I created a new service (DogService) with a method that executes the stored procedure using FromSqlInterpolated, which
safely handles parameters and prevents SQL injection. I also added a matching interface, IDogService, and registered the service in Program.cs so it could be
injected into controllers.
Next, I added a new controller action called SearchByBreed in the DogsController. This action calls the stored procedure via the service and returns the results
to a Razor view. I created a simple view (SearchByBreed.cshtml) that includes a search box, executes the procedure on GET requests, and displays the results in 
a table.
Overall, this week helped me understand how stored procedures can be combined with EF Core to improve performance and use SQL logic. This approach would be
valuable in any real application that needs optimized or repeated database operations.


