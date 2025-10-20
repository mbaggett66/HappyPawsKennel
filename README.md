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
