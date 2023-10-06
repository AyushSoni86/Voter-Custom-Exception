# Voter-Custom-Exception
Learning Exception Handling in C#

### Assignment 1: Custom Exception Implementation (Voter Eligibility) 

- Create a custom exception class called UnderageVoterException that inherits from the System.Exception class. This exception should be used to handle cases where an individual is underage to vote. 

### Assignment 2: Exception Handling in Voter Eligibility Check 

- Develop a voter eligibility check module within your application. 

- Implement custom exception handling to calculate an individual's age based on their birthdate and check if they are eligible to vote. 

- If the age is below the legal voting age (e.g., 18 years old), throw the UnderageVoterException. 

- Catch and handle this exception appropriately by displaying a user-friendly error message. 

 

### Assignment 3: Logging Underage Voter Exceptions 

 

- Extend your application to include a basic logging mechanism. 

- When the UnderageVoterException is thrown due to an underage voter, log a simple error message to a log file. 
