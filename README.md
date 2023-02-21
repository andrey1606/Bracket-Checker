# Bracket-Checker
The Bracket Checker program is a simple console application written in C# that checks if brackets in a given code file are placed correctly. It uses a stack data structure to keep track of the opening brackets and pops the brackets off the stack when a closing bracket is encountered. If a closing bracket does not match the expected opening bracket, the program records an error and reports it to the user. The program also handles errors that may occur while reading the file.
## Installation
To use the Bracket Checker program, you need to have [.NET Core](https://dotnet.microsoft.com/download) installed on your machine. Once you have installed .NET Core, you can clone this repository or download the source code as a ZIP file and extract it to a folder on your computer.

## Usage
To run the Bracket Checker program, follow these steps:

1. Open a command prompt or terminal window and navigate to the folder where you extracted the source code.
2. Type `dotnet run` and press Enter.
3. The program will prompt you to enter the file path of the code file you want to check.
4. Enter the file path and press Enter.
5. The program will display whether the brackets are placed correctly or if there are errors in the code.

## Explanation of the algorithm
The Bracket Checker program uses a stack data structure to keep track of the opening brackets that have been encountered in the code. When a closing bracket is encountered, the program pops the top bracket off the stack and checks if it matches the closing bracket. If it does not match, the program records an error.

Here is a step-by-step breakdown of the algorithm:

1. The program prompts the user to enter the file path of the code file they want to check.
2. Reads the contents of the file into a string variable called `code`.
3. Initializes an empty stack called `stack` and an empty list of errors called `error`.
4. Iterates over each character in the `code` string using a `for` loop.
5. For each character in the `code` string, the program checks if it is an opening bracket (`(`, `{`, `[`, or `<`). If it's, the program creates a tuple containing the opening bracket and its position in the string and pushes it onto the `stack`.
6. If the character is a closing bracket (`)`, `}`, `]`, or `>`), the program checks if the `stack` is empty. If it's, the program records an error. If the `stack` isn't empty, the program pops the top item off the `stack` and checks if the opening bracket matches the closing bracket. If it doesn't match, the program records an error.
7. After the `for` loop has completed, the program checks if the `stack` is empty. If it's not empty, the program records an error for each remaining opening bracket in the `stack`.
8. The program returns the list of errors.
9. The main method then checks if the list of errors is empty. If it's, the program prints a message indicating that the brackets are placed correctly. If the list of errors is not empty, the program prints a message indicating that the brackets are not placed correctly and lists the errors.
