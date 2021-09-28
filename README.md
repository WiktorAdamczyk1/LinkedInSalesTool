# LinkedInSalesTool

This is an automated sales tool for [LinkedIn.com](https://linkedin.com/). The project consists of:
*  `LinkedInLib` library that uses `Selenium webdriver` for scraping.
*  `LinkedInSalesToolGUI` blazor server application that implements said library.

## Setup

1. Host a PostgreSQL database (guide in `Database Setup` folder).
2. Clone the repository.

## Usage

1. Fill out database creditentials on the settings page.
2. Add at least one account on the Accounts page (this account will be used to send invites and messages).
3. Add clients (import from a CSV file with links to clients profiles) on the Clients page.
4. Synchronise on the Home page.
5. Use Messages page to interact with clients.

## Functionalities

#### LinkedInLib

This library contains classes that are responsible for scraping and communicating with the database.

* Logging into linkedin.
* Inviting other users.
* Messaging other users.
* Keeping track of current progress (e.g. invite sent, contact failed).
* Full synchronisation that checks if status of any client has changed and if any action is needed.
---
### LinkedInSalesToolGUI

This is a blazor server application that is used as a simple GUI for the `LinkedInLib`.

#### Endpoints

* /messages - simple chat
* /accounts - Managing user accounts that will be used to contact clients. Allows to test the automatic login to make sure that there will not be a 2FA requirement.
* /clients - Importing clients from a CSV file containing profile links.
* /settings - Allows the user to set automatic messages contents, tool working time, number of days before taking certain action (e.g wait 2 days before sending an intial message after the invite was accepted), setup database connection.
* /howtostart - Short instruction on what to do after the first launch.

## Technologies

* [Selenium webdriver](https://www.selenium.dev/documentation/webdriver/)
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)

