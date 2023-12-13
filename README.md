## How to install Informix ODBC Driver 32-bit for Microsoft Windows.

Step 1: [Download Informix ODBC Driver](https://www.ibm.com/support/pages/informix-32-bit-odbc-setup-microsoft-windows)

Step 2: Install ODBC Driver and Create a System DSN to connect to Informix Server

## Setting up System DSN to connect to Informix Server.

In this section you will need:

1. Download and install Informix ODBC Driver from the link above.
2. Create a System DSN using the Informix Server connection information.

## Using Project

Once you have installed the ODBC Driver and configured System DSN, You can follow these steps:

1. Download the project
2. Edit connectionString in the code to connect to your Informix Server.
     ```csharp
     string connectionString = "DSN=DSN name you created;UID=ID informix;PWD=password informix";
     ```
3. Run the project and go to the Search Page.
