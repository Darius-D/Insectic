#   <p align="center" > :stop_sign: Caution: This is a prototype as of April 9, 2021. :stop_sign: </p>
  <p align="center" > Anything below is subject to change</p>
  <p align="center" ><a href=https://github.com/Darius-D/Insectic/blob/main/README.md> :pushpin: Return to Main Page :pushpin: </a></p>
  <p align="center" ><a href=https://github.com/Darius-D/Insectic/tree/master> :pushpin: Go to see my code :pushpin: </a></p>
  
  
  ##    <p align="center" > Curent working features written in HTML </p>

<p> This is currently my dashboard AKA my CorkBoard. As of April 12th, 2021 I have removed the footer sticky notes. I did this to allow for easier media queries while also reducing clutter. I have now started to implement version 3 which took carried with it some features from V2. V3 has a better page layout reducing the need for media queries by 70%. This has allowed for better accessibility and mobile views. All colors are simply for ease of constructing and editing my code. Color pallet will be applied once all back end work is completed. See V2 and V3 below along with the mobile views. </p>
  
 ###  <p align="center"> Major Changes </p> 
 |Date|Change Made|Current status|
 |----|-----------|--------------|
  |March 10, 2021| Changed background from chalkboard black to an image of college ruled paper. | Implemented|
  |March 15, 2021|Added small tacks to pages in various locations to add small details. Tack images are position:relative. | Implemented|
 |March 19, 2021| Moved single ticket table into four separate  tables in their respective priorities making sorting much easier. Prior image can be found in img folder named /dashbord2.1.JPG for reference.| Implemented|
 |March 21, 2021|Made a Todo list in replace of the original assigned ticket table. This will populate what tasks are assigned to the member by their team leader. This change will be temporary as I create a SCRUM board view page. | Implemented|
 |March 30, 2021|Made an API in my solution to be the "middleman" between my web application and my database. the API has three controllers  with various CRUD action Methods.| Implemented|
 |April 4, 2021| Altered the Create Ticket View Page to match the theme of this project while implementing a drop down menu that populates all users in the Database|implemented|
 |April 6, 2021| Complete overhaul of the Address Book View page and the logic being the "corkboard" view page. The Dashboard is not pulling data from a SQL Db and not Local Db mock Data. This is done via my Webapp controller sending requests to my API that is connected to the DB.|implemented|
 |April 9, 2021| Created a view All Tickets page. This page has the ability to sort  the tickets with a filter and counter coming in the near future. |implemented|
 |April 10, 2021| Created a completely new layout. This layout is 100% mobile friendly and easier to insert partial views and components into. Still undecided on if I will implement this new design. Awaiting constructive criticism  from friends. See V2 layout below| Partial implementation|
 |April 12, 2021| After receiving opinions from friends, I have decided to do a partial change. The intent is to remain original such as version 2 but be less cluttered and distracting in version 3. Please see Version 2 and version 3 changes below.| Implemented|
 
  
***

  <p align="center">Still a work in progress. Intended updates coming soon: Analytic Charts, working SCRUM board on dashboard page and its own page, better</p>
  
  
###  <p align="center"> Old Version 2 page views </p>
![](/img/Version%202)

###  <p align="center"> Pending V2 Dashboard: color are for development only. Views are as ordered: Desktop greater that 850px, desktop/tablet less than 800px, cellphone/tablet less than 500px   </p>

![](/prototype/img/Dashboardv2.JPG)
![](/prototype/img/800pxDashboardv2.JPG)
![](/prototype/img/550pxDashboardv2.JPG)

***

 ##  <p align="center"> Prototype Ticket Submission View
  <p>  The ticket page has user input validation in all required fields ensuring  an error comes up prior to the HTTP post action method being called. This will ensure no data the user entered is lost due to page refresh. Currently the 'textarea' tag is causing complications do to the lack of reactivity with the CSS grid layout. This will be corrected by media queries in the next "push". The Ticket submission view will retain the footer editable notes functionality. Java script will be used to store the note details to users cache files to ensure they remain the same upon view transfers.  </p>
<p align="center">
  
  
![](/img/NewTicketViewPage.png)
***
##  <p align="center"> Prototype View Tickets viewpage
  <p> This view  populates a every ticket in the DB including "closed" tickets. This is to allow for data collection. This view page now has the ability to sort the table with the ability to filter tickets out coming in the near future. The Headers have a position"sticky" to allow them to stay on top of the page. The table colors are simply place holders.</p>

![](/img/ViewAllTickets.JPG)
***
##  <p align="center"> Prototype AddressBook view
  <p> This view  populates a contact card for each user in the repository with an individual profile picture, mailto: Email link, role, and phone number that will appear upon hovering over the phone icon. This will be done with Css. In the case of having more than six users, the address book overflows into a scroll on the container allowing for additional cards without disfiguring the layout. The colors currently used were for testing purposes and will be changed shortly. </p>
***


##   <p align="center"> Ticket Api List </p>
<img src="/img/APIDiagram.JPG"/>
