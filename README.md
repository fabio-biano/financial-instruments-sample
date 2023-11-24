# Introduction 
This is a didatic project, for study purposes.
It shows some design patterns and programming practices in a solution written in C#, using Entity Framework Core, SQL Server and .NET 7.
Basicallyit it has an API (Not fully developed yet), an Infrastructure project used for database access with Repository Pattern, Migrations for database updates (while the program evolves) in code first approach, a Domain project that encapsulates domain classes, contracts and services.
Also it has Unity and Integration tests. The unity tests uses dependency injection for mock data and the integration tests makes a real connection to the database and calls a stored procedure to retrieve data and verify the results.
As business rules, the software works with Financial Instruments.
A financial instrument owns a type name and a market value. Based on its market value, the software is able to categorize the financial instrument based on its market value.
The database has a table called FinancialInstrumentCategory, that parameterizes each category with the minimum and maximum market value.
The market value must be in a range between the minimum and maximum market value.
The FinancialInstrument implements the following interface:

    interface IFinancialInstrument
    {
	    double MarketValue { get; }
	    string Type { get; }
	  }

Currently, there are three categories based on the market value:

 - Low Value: Instruments with a market value less than $1,000,000
 - Medium Value: Instruments with a market value between $1,000,000 and $5,000,000
 - High Value: Instruments with a market value greater than $5,000,000

Imagine you receive a list of financial instruments, and you need to categorize them according to the rules above.

**Example:**

Input

    Instrument1 {MarketValue = 800000; Type = "Stock"}
    Instrument2 {MarketValue = 1500000; Type = "Bond"}
    Instrument3 {MarketValue = 6000000; Type = "Derivative"}
    Instrument4 {MarketValue = 300000; Type = "Stock"}

Output

    instrumentCategories = {"Low Value", "Medium Value", "High Value", "Low Value"}

This rule applies to FinancialInstrumentService and for the Stored Procedure version.

# Getting Started
The solution is simple. You just need to compile and run the Unity Tests to see it working.
For integration tests, some configurations is required as explaine below:
For FinancialInstruments.Api, you just need to open the appsettings.json and configure the connection string called FinancialInstruments.DbContext, supplying with your server addres/name, the database name, user id and password.
In development environment, you can create an appsettings.Development.json and use a differente connection string.
For integration tests, you have to configure the appsettings.json file as explained above. You can just copy and paste it.

*Connection string sample*

    "ConnectionStrings": {
        "FinancialInstruments.DbContext": "Server=localhost,1433;Database=[database-name];Trusted_Connection=True;User Id=[your-credentials];Password=[your-password]"
      },

# Build and Test
To build just right click on FinancialInstrumentsSample solution and select *Build Solution*.

Open the Package Manager Console at:

    Tools > Nuget Package Manager > Package Manager Console

In package manager console, type *update-database* to apply the existing migrations to your database and setup test data.

To test, just open the Test Explorer, and right click on the desired tests and click Run.

> Remember to configure the appsettings.json prior to run **Integration Tests**!

If the Integration Tests fails, check if the connection string is properly configured and if the Stored Procedure and Sql User Defined Table Types is correctly created. Sometimes the migration fails to create it.
To fix it, you can manually create it. Just go to FinancialInstruments.Migrations project, at the Scripts folder, and run the SCR_CREATE_FINANCIAL_INSTRUMENT_TYPE.SQL and USP_CATEGORIZE_FINANCIAL_INSTRUMENTS.SQL scripts in your database.
```