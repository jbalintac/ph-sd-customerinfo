
# Customer Info

## Overview
A very simple customer listing app.

Hypothetically this should be listing B2B customers, however the current initial data represent my work experiences employers and the companies of my job applications (you can say from my point of view ─ my customers).

[Live Demo](https://portfolios.nyzme.com/propellerhead-sd)


## Requirement Checklist
|  |Requirement | Notes |
|--|--|--|
| [x] | Unique customer identifier | Used Guid as the Id | 
| [x] | Status: one of "prospective", "current", "non-active" |   |
| [x] | Creation date and time | |
| [x] | General information like name and contact details | Aside from the one mention just added description detail |
| [x] | Filter | Filtering by Name and Status |
| [x] | Sort list of customers | Sortable by Name |
| [x] | Click on customer in the list to view their details |  |
| [x] | Add/Edit notes |  |
| [x] | Change their status |  |


## Improvement Recommendations
- Create Api and Web unit tests.
- Further refactor.


## Prerequisite
Build & Run:
- Docker, Docker Compose

Development:
- Node, NPM
- .Net Core 2.1 SDK


## Build
Run `docker-compose up -d` to build and run the project. Navigate to `http://localhost:4200/`. 


## Development
For local, none docker-compose development run in order:
- `docker-compose up -d customerinfo-db`
- Allow some time for customerinfo-db to finish initializing before issuing `dotnet run`
- On ./api/ `dotnet run customerinfo-db=127.0.0.1`
- On ./web/ `ng serve -c local`

If using docker-compose:
- `docker-compose up -d`
- On subsequent changes just run on the changed service: `docker-compose up -d --no-deps --build <service_name>`


## Troubleshoot
- For error such as  `Error starting userland proxy: mkdir /port/tcp:0.0.0.0:`  try restarting you local docker
- Make sure port 4200, 5000 are unused.
- Make sure all containers are running and healthy when navigating to `http://localhost:4200/`
- Allow sometime for `customerinfo-db` to finish initializing in some instance.
- Each service is dependent to one other and it would be necessary to run the component in order: Db, Api, Web. This is already configure on the `docker-compose.yml` thus by running the `docker-compose up -d` should be enough.
- Check on `docker ps -a` if containers up and healthy.


<!-- 
Todo:
- API SRP
- Initial Sort
- Import simplify
- CORS
-->