# Banking

# **How to Use**
Start by migrating the database to your device. To do this, navigate to Banking.API.appsettings.Development.json and update the database connection string.

![image](https://github.com/user-attachments/assets/2e1d55c5-0f14-40d5-af19-ca15ff0086b1)

Next, open the Package Manager Console, select Banking.Infrastructure, and run the following commands:
`add-migration <NameMigration>`
`update-database`
![image](https://github.com/user-attachments/assets/5b66a795-b841-402d-940b-2157672ed99a)
After completing these steps, the database will be successfully created on your device. Once the database is created, run the project to populate it with test data specified in the Banking.Infrastructure.Seeder.BankingSeeder.cs file.
![image](https://github.com/user-attachments/assets/a35df879-befb-4a84-9d59-cf7b50ed5ba4)

# **Project Structure**
The project consists of the following layers:

- **Banking.Api**:  
  This layer is responsible for handling HTTP requests and interacting with clients.

- **Banking.Application**:  
  This layer contains the application logic. The primary functionality is divided into domain modules (e.g., `Accounts`, `Transactions`, `TransactionType`, `User`).

- **Banking.Domain**:  
  This layer is responsible for the domain model.

- **Banking.Infrastructure**:  
  This layer manages technical aspects such as database access.

Additionally, the project includes the following test modules:

- **Banking.ApplicationTests1**:  
  Tests the `Banking.Application` module.

- **Banking.APITests**:  
  Tests the `Banking.API` module.
