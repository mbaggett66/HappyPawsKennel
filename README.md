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

Week:   Concept:           Feature:                Goal:                 Acceptance Criteria:         Evidence in README.md:          Test Plan:

10      Modeling         Create 'Dog' and       App can store dogs      -Dogs table created         Implemented code; README        Run migration;
                         'Kennel' entities.      and assign them to     -Kennels table created      write-up; screenshots.          Check Db tables. 
                                                kennels.                -Relationship works         

11      Separation       Add 'IDogService'      Move logic from         -IDogService interface      Implemented code; README        Call service methods from 
        of Concerns/DI   for kennel             controller into a       exists                      write-up; screenshots.          controller end-points.
                         assignment.            service.                -Controller uses 
                                                                        constructor injection
                                                                        -Assignment logic works

12      CRUD             Create/Edit/Delete     Allow staff to          -Create/edit/delete         Implemented code; README        Add a dog, edit fields,
                         dog and kennel pages.  manage dog records      pages exist.                write-up; screenshots.          delete, and confirm
                                                and kennel assignments  -Changes persist to                                         database changes.
                                                through a web UI.       DB
                                                                        -Kennel occupancy
                                                                        updates correctly

13      Diagnostics      Add /healthz           Health check to verify  -Endpoint returns healthy   Implemented code; README        Stop DB, call /healthz.
                         endpoint.              Db connectivity.        when DB is reached          write-up; screenshots.
                                                                        -Returns unhealthy if 
                                                                        DB is unavailable

14      Logging          Log dog check-ins &    Track kennel operations -Log messaged created       Implemented code; README        Perform check-in/out
                         check-outs.            with structured logs.   on check-in/out             write-up; screenshots.          operations and check
                                                                        -Logs include dog and                                       log output.
                                                                        kennel information

15      Stored           Top kennels by         Show kennels with        -Stored procedure          Implemented code; README        Run stored procedure in
        Procedures       occupancy.             the highest occupancy.   executes correctly         write-up; screenshots.          app and verify result 
                                                                         -Results displayed                                         matches DB query.

16      Deployment       Deploy app to Azure    Make the application     -App Service created       Implemented code; README        Visit URL; check /healthz
                         App Service.           accesible.               -App runs on Azure         write-up; screenshots;          and ensure page loads.
                                                                         -/healthz reachable        deployed URL.
                                                                         -One path works