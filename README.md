# MauiFormulaOne
---
## Data used in this project can be found on [ErgastAPI](http://ergast.com/mrd/)
---
# **Work in progress**

## Project consists of:
- .Net Maui app - it is supposed to graphically display data about F1
- SQL Database - it has stored procedures for CRUD actions
- API - created to allow communication between DB and MauiApp
- Libraries - used to deserialize data from ErgastAPI and store it in DB.

For now, application allows to pull F1 drivers list by season from **ErgastAPI**, deserialize it into `Driver` objects, which then can be inserted into DB using stored procedure named `spDrivers_Insert`.

