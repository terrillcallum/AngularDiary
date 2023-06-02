
## Project Description

write a browser based web application which enables a user to:

- Add a diary entry with a title, creation time & content
- View a list of their diary entries
- View the content of any given diary entry
- Remove a diary entry
- Search for a diary entry by content text
- Share a diary entry with a friend

Expectations:

- How long you spend on this is up to you, it is not required to finish all of the “tickets”. We recommend 2-3 hours but this time limit is not strict. The goal is for us to be able to see the kind of considerations you make when writing code and how you structure a code base. The more you write, the easier this will be to show.
- Either the back end must be written in .NET  (Framework / Core) OR the front end must be written in Angular (or you can use both together).
- You may want to include a README.md with a list of improvements you would make if you had more time.
- We recommend using version control.
- You must include instructions on how to run the application.
- You may code the points in any order but we recommend answering them top to bottom as this will provide the highest “value added” features first.

## Prerequisites

Before running the project, please ensure that you have the following software and tools installed on your machine:

-   Node.js
-   Visual Studio

## Running the Project

just run the project in visual studio everything should work 

## Database Configuration

The project already includes the necessary database structure. No additional setup is required for the database.

## Functionality and Features

-   Copy to Clipboard: The application includes a feature to copy certain content to the clipboard. This functionality was implemented quickly due to time constraints.

## Styling

While the project includes some styling, the main focus was on implementing the required functionality. As a result, the styling may be minimalistic.

## Authentication

Authentication was initially planned for this project. However, due to time limitations, I was unable to implement real authentication. Instead, I used the IP of the user's computer as a temporary implementation. Please note that this is not secure and should not be used in a production environment.

## Future Improvements

Here are some areas for improvement in the project:

-   Real Authentication: Implement a secure authentication system for users.
-   Share Button: Add a share button and integrate the application with social media platforms.
-   Improved Styling: Enhance the visual appearance of the application to provide a better user experience.

## solved Issues

There were a few challenges encountered during the development process:

-   API Requests: Initially, the API requests were not functioning correctly. The issue was discovered to be related to Angular's proxy configuration, which was blocking the `/api` requests. This was resolved by allowing the requests to go through the proxy.

## Known Issues

Authenticaion not working with username/password
copy to clipboard is a simple solution to the friend thing but this could be hugly improved

## Conclusion

Thank you for your interest in me. 
the project serves as a demonstration of my willingness to learn new skills,
despite limited prior experience. If you have any further questions or feedback,
please feel free to contact me.

Best regards, callum