 ## Table of Contents 
 1. [Why Insectic?](#head)
 2. [What is Insectic](#head2)
 3. [Case Use Diagram](#head3)
 4. [ERD](#erd)
 5. [Draft WireFrames](#head4)
    1. [Dashboard page](#head41)
    2. [Analytics page](#head42)
    3. [Archive page](#head43)
    4. [Ticket Submission page](#head44)
    5. [Contact page](#head45)
 6. [User Stories](#head5)
 7. [Use Cases](#head6)
 8. [Requirements](#head7)
 9. [Test Table](#head8)
 10. [Issues Encountered](#head9)
 11. <a href=https://github.com/Darius-D/Insectic/tree/main/prototype> Prototype Section </a>

***
<a name="head"></a>
 # <p align ="center"> :beetle: Why Insectic? :beetle: [:arrow_up_small:](#table-of-contents) </p> 

Insectic is a side project I am working on to help viuslize one of the 4 pillars of work; Unplanned work. This idea came to me after reading <i>The Phoenix Project</i> I wanted to follow along with Bill and Patty and see if I could create an application that would of helped visualize, track, and streamline the completion of unplanned tasks and work. 

<a name="head2"></a>
## <p align ="center"> :beetle: What Is Insectic? :beetle: [:arrow_up_small:](#table-of-contents) </p>
Insectic will be an interactive bug/patches tracking web application that will forcus on the unplanned work aspect of DevOPs. This Web application will allow Managers to track current items being worked on with detailed statistics to help locate bottle necks. Team leaders will be able to utilize this tool to task out team members, track team progress and will be able to see team analytics to better articulate the needs of the team to the department manager. 
***
<a name="head3"></a>
### <p align="center"> :page_facing_up: [Case Use Diagram](https://github.com/Darius-D/Insectic/blob/main/CaseUseDiagram.jpg) :page_facing_up: </p>
***
### <p align ="center"> ERD [:arrow_up_small:](#table-of-contents) </p>
***
<a name="erd"></a>
![](img/myERD.jpg)

***
<a name="head4"></a>
###     <p align ="center"> DRAFT WIREFRAMES [:arrow_up_small:](#table-of-contents) </p>

***
<a name="head41"></a>
###   <p align ="center"> Dashboard/Home Draft [:arrow_up_small:](#table-of-contents) </p>

<img src="https://github.com/Darius-D/Insectic/blob/main/img/dashboard2.JPG" width="1000" height="600">



<a name="head42"></a>
###  <p align ="center"> Analytics Page [:arrow_up_small:](#table-of-contents) </p>


![](img/Analytic%20page.JPG)

***
<a name="head43"></a>
###   <p align ="center"> Archives Page [:arrow_up_small:](#table-of-contents) </p>

![](img/Archives.JPG)

***
<a name="head44"></a>
###   <p align ="center"> Ticket Submission [:arrow_up_small:](#table-of-contents)  </p>


<p align="center">  
  
  <img src="https://github.com/Darius-D/Insectic/blob/main/img/ticket%20submission.png" width="1000" height="600"></p>
  
***
<a name="head45"></a>
###   <p align="center">  Contact Page [:arrow_up_small:](#table-of-contents) </p>

<a name="head45"></a>
![](img/Contact.JPG)

***
<a name="head5"></a>
### <p align ="center"> User Stories [:arrow_up_small:](#table-of-contents) </p>

1. As a Department Manager, I need to create “tickets” when ever a problem is detected in our process, so that we can visualize the bottleneck and common trends. 
2. As a Department Manager, I need to see the analytics of all the tickets in our system so that I can provide detailed reports to the CEO. 
3. As a Team lead, I need to be able manage my team assign them to tasks so that I can provide the Department Manager with daily status updates. 
4. As a Team Members, I need to be able to submit tickets for issues encountered with a detailed description and categories so that my team lead can articulate our current issues and progress with the Department Manager

***
<a name="head6"></a>
### <p align ="center"> Use Cases [:arrow_up_small:](#table-of-contents) </p>

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
### <p align ="center"> Requirements [:arrow_up_small:](#table-of-contents) </p>

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

***
<a name="head8"></a>
### <p align="center"> Test Table  [:arrow_up_small:](#table-of-contents) </p> 

| Test ID | Requirement ID | Test Prodedure | Current Status | TimeStamp |
|:--------|:--------------:|:--------------:|:--------------:|:---------:|
|  <a name="100"></a>100  |     [1](#1)          | Fill out form on page and verify model biniding occured and stored the values toa new user object |:red_circle:|TBD|
| <a name="101"></a> 101     |     [1.1](#11)        | Utilizing GitHub authentication, ensure new user object is created and values are stores in the DB |:red_circle:|TBD|
| <a name="200">200     |     [2](#2)         | With seveal users created in multiple roles, verify all pages render appropriate headers |:red_circle:|TBD|
| <a name="300">300     |      [3](#3)        | Upon creation of a ticket verify ticket values are unique utilizing test method |:red_circle:|TBD|
| <a name="301">301     |       [3.1](#31)      | Upon creation of a ticket verify ticket values are unique utilizing test method |:red_circle:|TBD|
| <a name="302">302     |      [3.2](#32)       | Upon creation of a ticket verify all NOT NULL fields are assigned values in the ticket table on server|:red_circle:|TBD|
|<a name="400"> 400     |      [4](#4)         | Inspect the Analytics web page ensuring data values are correct and match data in the server |:red_circle:|TBD|
| <a name="401">401     |      [4.1](#41)       | Utilizing a department Manager assigned user account, verify detailed analytics page displayes correct informtaion |:red_circle:|TBD|
| <a name="402">402     |       [4.2](#42)      | Utilizing a Team Leader assigned user account, verify detailed analytics page displayes correct informtaion |:red_circle:|TBD|
| <a name="403">403     |       [4.3](#43)      | Utilizing a Team Member assigned user account, verify detailed analytics page displayes correct informtaion |:red_circle:|TBD|
| <a name="500"> 500     |       [5](#44)        | Utilizing a Department manager role user, chnage an open ticket to closed and verify status in date base has been changed |:red_circle:|TBD|
| <a name="501"> 501     |       [5.1](#51)      | Utilizing any role besides Department Manager role, enusre close ticket is not a drop down option |:red_circle:|TBD|
| <a name="502"> 502     |       [5.2](#52)      | Utilizing any role besides Department Manager role, enusre pending close ticket is a drop down option|:red_circle:|TBD|
| <a name="600"> 600     |       [6](#6)        | Utilizing a Department Manager role user attempt to change user permissions |:red_circle:|TBD|
   
***
<a name="head9"></a>
### <p align="center"> Issues Encountered  [:arrow_up_small:](#table-of-contents) </p>

| Problem ID  | Problem Description | Solution| Encounter Date| Solution Date |
|:---:|:---:|:---:|:---:|:--:|
|01|After Creating my layout for my views, the taxtarea input on the ticket page expands out of the container when the browser is less than 500px. |I reconstructed the webpage utilizing Grid in the main content space. The web page now uses several media queries to hide several tags at various lengths and with the utilization of grid has become more responsive.  | March 6, 2021 | March 7,2021|
|02| Difficulty makine a Ticket ID property that increments each time an object is made. I attempeted to make a constructor that incremented +1 hoever that seemed to not work. I believe there is an error on my side .| The failure was in the fact i did not have a static variable to assign to my TicketId property. I was attempting to increment TicketId by 1 everytime an instance was created however since TicketId is not static the value reset to 0 every insatnce. |March 8,2021|March 8,2020|   
 
 ***
<a name="head10"></a> 
###  <p align="center"> TODO:// </p>

- [x] Create Dashboard view
- [x] Create Ticket Submission view
- [x] Create Contact Page
- [x] Create Contact Page Profile Cards
- [ ] Create View Tickets Page
- [ ] Create model for view tickets page
- [ ] Normalize DB
- [ ] Link DB
- [ ] Optimize Mobile View
- [ ] Optimize classes
- [ ] Create Unit tests
- [ ] Run Unit Tests
- [ ] Do beta test with users
- [ ] Apply feedback
- [ ] Run second Beta Test
- [ ] Run Alpha Test
- [ ] Rerun all tests
