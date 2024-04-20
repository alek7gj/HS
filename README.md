I'm using Selenium with C#, with Visual Studio 2022 tool. 
I have automated 13 scenarios for the following web application Demo Web Shop, link: https://demowebshop.tricentis.com/. For most of them, I described the details in the .pdf file that I sent you.
The framework is made to be able to easily set which browser we will use for running the tests. Available options are Google Chrome & Mozilla Firefox (set by default).
There are tests when the customer does not have to be logged in to the web application. Also, tests when the customer must be logged into the web application.
Configuration values are in the app.config file, there is the BaseURL and the Username & Password for the tests where we run tests for logged-in users.
The tests for each Web Page are a separate category, for example, Home Page, Register Page, Product Category Page, Product Details Page,...
