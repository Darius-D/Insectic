# <p align="center"> Welcome to my project, Insect-IC!</p>
##  <p align="center"><u> <a href=https://github.com/Darius-D/Insectic/tree/main/prototype> Click here</a></u> to see current Prototype and Here to see the <a href=https://github.com/Darius-D/Insectic/tree/master> Code </a></p>
## <p align="center"> or below to learn more </p>
 ### Table of Contents 
 1. [Why Insectic?](#head)
 2. [What is Insectic](#head2)
 3. [Use-Case Diagram](#head3)
 4. [ERD](#erd)
 5. [Draft WireFrames](#head4)
 6. [User Stories](#head5)
 7. [Use Cases](#head6)
 8. [Requirements](#head7)
 9. [Test Table](#head8)
 10. [Issues Encountered](#head9)
 11. <a href=https://github.com/Darius-D/Insectic/tree/main/prototype> Prototype Section </a>
 12. [Todo List](#head10)

***
<a name="head"></a>
 # <p align ="center"> :beetle: Why Insectic? :beetle: [🔝](#table-of-contents) </p> 

Insectic is a side project I am working on to help viuslize one of the 4 pillars of work; Unplanned work. This idea came to me after reading <i>The Phoenix Project</i> I wanted to follow along with Bill and Patty and see if I could create an application that would of helped visualize, track, and streamline the completion of unplanned tasks and work. 

<a name="head2"></a>
## <p align ="center">  What Is Insectic?  [🔝](#table-of-contents) </p>
Insectic will be an interactive bug/patches tracking web application that will forcus on the unplanned work aspect of DevOPs. This Web application will allow Managers to track current items being worked on with detailed statistics to help locate bottle necks. Team leaders will be able to utilize this tool to task out team members, track team progress and will be able to see team analytics to better articulate the needs of the team to the department manager.  <a href=https://github.com/Darius-D/Insectic/tree/main/prototype> Check out the Prototype. </a>
***
<a name="head3"></a>
### <p align="center"> :page_facing_up: [ Use-Case Diagram](https://github.com/Darius-D/Insectic/blob/main/CaseUseDiagram.jpg) :page_facing_up: </p>
***
### <p align ="center"><a href="https://github.com/Darius-D/Insectic/blob/main/img/myERD.jpg"> ERD<a/>  </p>
***
<a name="erd"></a>
###    <p align="center">Database Diagram [🔝](#table-of-contents) </p>

<p align="center">  
  <img src="/img/diagram (2).JPG" />
</p>


***
<a name="head4"></a>

###     <p align ="center"> DRAFT WIREFRAMES [🔝](#table-of-contents) </p>

![](/img/wireframe.jpg)

***

<a name="head5"></a>
### <p align ="center"> User Stories [🔝](#table-of-contents) </p>

1. As a Department Manager, I need to create “tickets” when ever a problem is detected in our process, so that we can visualize the bottleneck and common trends. 
2. As a Department Manager, I need to see the analytics of all the tickets in our system so that I can provide detailed reports to the CEO. 
3. As a Team lead, I need to be able manage my team assign them to tasks so that I can provide the Department Manager with daily status updates. 
4. As a Team Members, I need to be able to submit tickets for issues encountered with a detailed description and categories so that my team lead can articulate our current issues and progress with the Department Manager

***
<a name="head6"></a>
### <p align ="center"> Use Cases [🔝](#table-of-contents) </p>

* Given a new user
When user fills out application
Then assign values to new user object

* Given a user discovers a reportable issue
When all required forms are filled properly, 
Then create a ticket object and store the data.

* Given a ticket number 
when a user desires to update a ticket
Then pull ticket data and allow comments to be added and update database. 

* Given a ticket number, 
When a team member desires to close a ticket, 
Then query ticket and change status to pending closure and alert Department Manager.

* Given a ticket number, 
When a Department manager desires to close a ticket, 
Then query ticket and change status to close to add to archives.

* Given a Ticket ID
When user wants to view the ticket
Then populate the ticket into a table.

* Given a filtering condition, 
When user wants to pull analytics, 
Then generate a query that outputs values to display the count of all tickets by category, subcategory.

* Given a user ID
When a user needs to be assigned to a group
Then populate drop by selection to select groups available and update user’s group in DB.

*** 
<a name="head7"></a>
### <p align ="center"> Requirements [🔝](#table-of-contents) </p>

| Requirement ID | Requirement Description | Test Method | Test ID |
|:-------------|:------------------:|:----------: |:-----------:|
| <a name="1"></a> 1 | The system shall create a user account with all required fields filled. | Analysis |  [100](#100) | 
| <a name="11"></a> 1.1 | The system shall allow github authentication. | Analysis | [101](#101) |
|<a name="2"></a>  2 | The system shall display the users name and roles on all pages | Inspection | [200](#200)|
|<a name="3"></a>  3 | The system Shall create unique ticket objects for each ticket submitted | Test | [300](#300) |
|<a name="31"></a>  3.1 | The system shall make a unique ticket ID for every ticket creation | Test | [301](#101) |
|<a name="32"></a>  3.2 | The system shall store all attributes of the ticket. | Test | [302](#101)|
| <a name="4"></a> 4 | The system shall provide Department managers with Analytics for the whole company | Demonstration | [400](#401) | 
| <a name="41"></a> 4.1 | The system shall provide Department managers with Analytics for the whole company | Demonstration | [401](#401) |
|<a name="42"></a>  4.2 | The System shall provide the Team Leaders with analytics for their team | Demonstration | [402](#402) |
| <a name="43"></a> 4.3 | The system shall provide Team members with only their analytics. | Demonstration | [403](#403) |
|<a name="5"></a> 5| The System shall archive closed tickets | Test |[500](#500)|
| <a name="51"></a> 5.1 | The System shall only allow Department managers to close tickets | Demonstration | [501](#501) | 
|<a name="52"></a> 5.2 | The System shall provide users the option to place ticket in pending close status | Demonstration | [502](#502) |
|<a name="6"></a>  6 | The System shall allow Department managers to move team member groups around | Demonstration | [600](#600) |
|<a name="7"></a>  7 | The System shall utilize a API to perform C.R.U.D operations for the Ticket Objects | Test | [700](#700) |
|<a name="8"></a>  8 | The System shall utilize a API to perform C.R.U.D operations for the Comment Objects | Test | [800](#800) |
|<a name="9"></a>  9 | The System shall utilize a API to perform C.R.U.D operations for the User Objects | Test | [900](#900) |

***
<a name="head8"></a>
### <p align="center"> Test Table  [🔝](#table-of-contents) </p> 

| Test ID | Requirement ID | Test Prodedure | Current Status | TimeStamp |
|:--------:|:--------------:|:--------------:|:--------------:|:---------:|
|  <a name="100"></a>100  |     [1](#1)          | Fill out form on page and verify model biniding occured and stored the values to a new user object |:red_circle:|TBD|
| <a name="101"></a> 101     |     [1.1](#11)        | Utilizing GitHub authentication, ensure new user object is created and values are stores in the DB |:red_circle:|TBD|
| <a name="200">200     |     [2](#2)         | With seveal users created in multiple roles, verify all pages render appropriate headers |:red_circle:|TBD|
| <a name="300">300     |      [3](#3)        | Upon creation of a ticket verify ticket values are unique utilizing test method |:red_circle:|TBD|
| <a name="301">301     |       [3.1](#31)      | Upon creation of a ticket verify ticket values are unique utilizing test method |:red_circle:|TBD|
| <a name="302">302     |      [3.2](#32)       | Upon creation of a ticket verify all not null fields are assigned values in the ticket table on server|:red_circle:|TBD|
|<a name="400"> 400     |      [4](#4)         | Inspect the Analytics web page ensuring data values are correct and match data in the server |:red_circle:|TBD|
| <a name="401">401     |      [4.1](#41)       | Utilizing a department Manager assigned user account, verify detailed analytics page displayes correct information  |:red_circle:|TBD|
| <a name="402">402     |       [4.2](#42)      | Utilizing a Team Leader assigned user account, verify detailed analytics page displayes correct information  |:red_circle:|TBD|
| <a name="403">403     |       [4.3](#43)      | Utilizing a Team Member assigned user account, verify detailed analytics page displayes correct information  |:red_circle:|TBD|
| <a name="500"> 500     |       [5](#44)        | Utilizing a Department manager role user, change an open ticket to closed and verify status in date base has been changed |:red_circle:|TBD|
| <a name="501"> 501     |       [5.1](#51)      | Utilizing any role besides Department Manager role, ensure  close ticket is not a drop down option |:red_circle:|TBD|
| <a name="502"> 502     |       [5.2](#52)      | Utilizing any role besides Department Manager role, ensure  pending close ticket is a drop down option|:red_circle:|TBD|
| <a name="600"> 600     |       [6](#6)        | Utilizing a Department Manager role user attempt to change user permissions |:red_circle:|TBD|
| <a name="700"> 700     |       [7](#7)        | Utilizing Postman, ensure all TicketController API requests work and output expected results |:green_circle:|March 30, 2021|
 | <a name="700"> 701     |       [7.1](#7)        | Utilizing Postman, ensure GetAllTickets TicketController API request works and output expected results |:green_circle:|March 30, 2021|
 | <a name="700"> 702     |       [7.2](#7)        | Utilizing Postman, ensure GetTicket TicketController API request works and output expected results |:green_circle:|March 30, 2021|
 | <a name="700"> 703     |       [7.3](#7)        | Utilizing Postman, ensure AddTicket TicketController API request works and output expected results |:green_circle:|March 30, 2021|
 | <a name="700"> 704     |       [7.4](#7)        | Utilizing Postman, ensure EditTicket TicketController API request works and output expected results |:green_circle:|March 30, 2021|
 | <a name="700"> 705     |       [7.5](#7)        | Utilizing Postman, ensure DeleteTicket TicketController API request works and output expected results |:green_circle:|March 30, 2021|
| <a name="800"> 800     |       [8](#8)        | Utilizing Postman, ensure all TicketCommentController API requests work and output expected results  |:green_circle:|TBD|
| <a name="900"> 900     |       [9](#9)        | Utilizing Postman, ensure all UserController requests API work and output expected results  |:green_circle:|TBD|

   
***
<a name="head9"></a>
### <p align="center"> Issues Encountered  [🔝](#table-of-contents) </p>

| Problem ID  | Problem Description | Solution| Encounter Date| Solution Date |
|:---:|:---:|:---:|:---:|:--:|
|01|After Creating my layout for my views, the ‘textarea’ input on the ticket page expands out of the container when the browser is less than 500px. |I reconstructed the webpage utilizing Grid in the main content space. The web page now uses several media queries to hide several tags at various lengths and with the utilization of grid has become more responsive.  | March 6, 2021 | March 7,2021|
|02| Difficulty making a Ticket ID property that increments each time an object is made. I attempted to make a constructor that incremented +1 however that seemed to not work. I believe there is an error on my side.| The failure was in the fact I did not have a static variable to assign to my ‘TicketId’ property. I was attempting to increment ‘TicketId’ by 1 every time an instance was created however since ‘TicketId’ is not static the value reset to 0 every instance. |March 8,2021|March 8,2021|   
|03| Visual Studio has a bug where if you copy and paste in a CSS script from Visual studio code it will not assist in linking a photo in the root folder into the URL block. This results in me having to reset VS every time I make to deploy changes, I made in VSC. | No current solution found besides restarting VS |March 11,2021|March 11,2021|
|04| Red and green tacks were placed on the page to add small fun details. the bottom red tack would move the screen height was adjusted. | This was due to the .Main-section class starting with a lowercase letter resulting in the parent element not being in ‘position: relative’. Issue was corrected on all pages. Media queries will need to be made to remove tacks from view once screen width is 850px or less.  |March 14,2021|March 14,2021| 
|05| Foreach loop for auto table generation for each of the ticket priority boxes would not work with LINQ syntax| I believe this was due to me writing the syntax in the SQL syntax variant. Intelisense did not like me utilizing the "select" keyword. I am not sure if this is because It knew more than one value would be returned from the query. This was corrected by using the more appropriate method syntax | March 20,2021|March 21,2021|
|06|Attempted to add new controller (TicketsContoller) to call views in a folder in the view folder(Tickets). I was doing this hoping to separate  my view pages into meaningful groups. However, When I select the createTicket link. the Controller does not change from "port/Home/CreateTicket" to "port/Tickets/createTickets" as I expected, resulting in a 404| Discovered the helper tag of asp-controller. This oversight was the reason why my controllers were not switching between HomeController and the TicketController. This was discovered when I was helping a classmate with their issue.| March 26,2021|April 03, 2021|
|07| Discovered upon visual inspection the "Status" property of the Ticket object does not display in the ticket table. I believe this is an issue with the data binding of the drop down list values. The values are returned which is how they are sorted but do not print to screen.|Discovered that the "name" and "Id" must match the model's property identifier as well. I was under the assumption that the helper tag (asp-for) was responsible for the binding.| March 26,2021| March 26, 2021|
|08| Created an API in my solution  to act as the "middle-man" between my webapp and my database. The API has three controllers "Tickets". " ticketComments", and "users". The Ticket controller CRUD action methods are complete but an error populates on postman when trying to send a "Patch" request. My generated message of "Ticket with Guid of {00000000-0000-0000-0000-000000000000} does not exist" is returned to me. That message should only return if the ticket is not in the Database. The get request works with the inputted GUID so the ticket is in the DB. | After placing several stoppers, I noticed my Guid was not being passed to the action method and instead was getting passed a empty Guid. The reason behind this was do to my action method parameter was named guid of type Guid. by changing the identifier to id of type Guid the action method started to pass the input request id to the GetTicket method inside the action method to pull the existing ticket and perform a deep copy. I was not aware the parameter name has to match the {id} route argument identifier. |March 30,2021| March 31, 2021|
|09|Created some tests for my API using WebApplicationFactory and Xunit. Tests work however the tests do modify the database. and require hard coded values to compare to that are pre-existing in the database. Currently looking for a way to use Moq to run Unit tests without having to modify Db or hard code dynamic values. Click here to see image of test setup. <a href="https://github.com/Darius-D/Insectic/blob/main/img/tests.JPG">test setup</a>  | No current solution| March 31,2021|TDB|
|10|While consuming APIs in postman worked, I ran into issues with sending post request in my project. The properties that required DateTime inputs are requiring Datetime inputs even though in the model the datatype is DateTime.Date. Currently looking for solutions to this issue. | Problem is now resolved. Issue was caused by having the default value of "dateTime.Now" in the model to be assigned upon construction of a new object of type Ticket. This was interfering with the assignment of the incident date and due date properties in SQL server| April 5,2021|April 6, 2021|
***
 ###   <p align="center"><a href="https://github.com/Darius-D/Insectic/tree/main/prototype"> :construction: Click to See Current Prototype :construction:</a></p>
***
 ### <p align="center"> SQL Mock DB <a href="https://github.com/Darius-D/Insectic/blob/main/InsecticMockData.sql">Script</a>: Users:20, Tickets:500, TicketComments:750 </p>
   
***
<a name="head10"></a> 
###  <p align="center"> TODO:// [🔝](#table-of-contents) </p>


- [x] Create Dashboard view
- [x] Create Ticket Submission view
- [x] Create Contact Page
- [x] Create Contact Page Profile Cards
- [ ] Create View Tickets Page
- [x] create database Api
- [ ] Create Scrum board
- [ ] Create Manage Team View Page and BLL
- [ ] Assign name values to grid columns and rows for easier media queries.
- [x] Normalize DB
- [x] Link DB
- [ ] Optimize Mobile View
- [X] Optimize classes
- [ ] Create Unit tests
- [ ] Run Unit Tests
- [ ] Do beta test with users
- [ ] Apply feedback
- [ ] Run second Beta Test
- [ ] Run Alpha Test


[To Top](#table-of-contents)
