# AFI Registration API

## Solution Overview
The solution uses a 3-tier structure. This is a greater seperation of concerns than this task requires, but I assumed that if this were a production api, that was likely to have more functionality added over time, this would lay the foundations that could be more easily built upon.

### API Layer
Responsible for providng API endpoints and validating requests before routing onto the relevant services.

### Service Layer
Responsible for mapping between request and data entity, performing any business logic, coordinating database interations and building the responses.

### Data Access Layer
Responsible for defining database schema and interactions.

### + Models
Request/Response models seperated into own dlls for ease of sharing.

---
## Running the app

Open the solution /Willis.Afi.Registration.Api/Willis.Afi.Registration.Api.sln, build and run Willis.Afi.Registration.Api as the Startup project.  
  
It includes swagger page for simple dev testing.  
The Sqlite db files have been included in the repository to ensure the solution runs without needing any specific prior setup.  
It also includes a range of unit tests covering most aspects of the logic and 1 integration test.  
The unit tests that involve the db call run against the an InMemory db.  

---
