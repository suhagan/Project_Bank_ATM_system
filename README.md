# Bank/ATM System:
This is a project to develop a simple Bank/ATM system with basic functionalities to learn about arrays, lists, class, objects. The goals is to develop a console application where predefined multiple clients can access the app. In this application, every clients can have more than one account, or at least one.

# Features:
This application has following active features:
- A Login Menu: 
       1) Client's Login: Through this, existing clients can log in to the app.
       2) Exit: This will allow app user to terminate the program.
- Operations Menu:
      [1] See Accounts Information and Balances
      [2] Transfer between Accounts
      [3] Withdraw Amounts
      [4] Log out
      
# Planning and Implementation
During planning and implementation, I have tried to touch the following ares: 

    - Data and its representation: I have tried to present the data in an organized way, so that in future any developer wants to take hints, or   use my work for further upgradation, will have a clear view of data. Usually this application has several clients, and individual clients have one to several accounts. 
    
    - Security: A basic security has been introduced in this system. During the though process, I have added PinCode for every accounts to impose 3 attempts login in every single account instead of individual client login. Later, during the implementation phase, I have implemented that 3 attempts login only for Client Login level. Although they system will become strong with security, however it would not be a user friendly application, if it blocks in every level of client's accounts. It will be time consuming and user will be tiresum.
    
    - Exception handling: I have used "try - catch" for exception handling, so that the system will not crush.
    
    - Program readibility: The program has comments in different places to increase the understandability and readability of the program.

# Future Work
Since this application is pretty basic, the program has opportunity to have future works in different ways. Opportunity of expanding and updating of "Deposit Amount in different accounts", "Transfer between other client's accounts", "a view of all Transaction History", "Creating client's account" are still open to work on. Though it will slow the application, account validation in different layer will be an interesting feature to attract client's to feel more secured. 
