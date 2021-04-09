#   <p align="center" > :stop_sign: Caution: This is a prototype as of April 9, 2021. :stop_sign: </p>
  <p align="center" > Anything below is subject to change</p>
  <p align="center" ><a href=https://github.com/Darius-D/Insectic/blob/main/README.md> :pushpin: Return to Main Page :pushpin: </a></p>
  <p align="center" ><a href=https://github.com/Darius-D/Insectic/tree/master> :pushpin: Go to see my code :pushpin: </a></p>
  ##    <p align="center" > Curent working features written in HTML </p>

<p> This is currently my dashboard AKA my CorkBoard. This has links that look like post-it notes that scale and rotate upon hovering. The footer has sticky notes that the user can edit with a simple double click. The notes will later be stored in cookies. 
 The sticky notes have a overflow of auto allowing for a the sticky note to hold unlimited amounts of characters with out modifying the view. Multiple  media queries allow this page to be mobile friendly periodically removing elements as screen size shrinks. With mobile phones, only the nav links will be available to allow the user to make tickets, view tickets and manage team members. </p> 
  <p> The table is currently a work in progress and will be used as a Scrum Board </p>
  
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
 
  
  ***
  
###  <p align="center"> Current Dashboard view </p>
![](/img/NewDashboard.png)

***

 ##  <p align="center"> Prototype Ticket Submission View
  <p> The Ticket submission view has yet to be formatted to work with my default layout; this explains why my top navbar does not yet match my Home page. This will be corrected in the next "push". The ticket page has user input validation in all required fields ensuring  an error comes up prior to the HTTP post action method being called. This will ensure no data the user entered is lost due to page refresh. Currently the 'textarea' tag is causing complications do to the lack of reactivity with the CSS grid layout. This will be corrected by media queries in the next "push". The Ticket submission view will retain the footer editable notes functionality. Java script will be used to store the note details to users cache files to ensure they remain the same upon view transfers.  </p>
<p align="center">
  
  
![](/img/NewTicketViewPage.png)
***
##  <p align="center"> Prototype View Tickets viewpage
  <p> This view  populates a every ticket in the DB including "closed" tickets. This is to allow for data collection. This view page now has the ability to sort the table with the ability to filter tickets out coming in the near future. The Headers have a position"sticky" to allow them to stay on top of the page. The table colors are simply place holders.</p>

![](/img/ViewAllTickets.JPG)
***
##  <p align="center"> Prototype AddressBook view
  <p> This view will populate a contact card for each user in the repository with an individual profile picture, mailto: Email link and role. In the case of having more than six users, the address book will overflow into a scroll on the container allowing for additional cards without disfiguring the layout. The colors currently used were for testing purposes and will be changed shortly. </p>
***
<img src="/img/NewAddressBookViewPage.png">

***

##   <p align="center"> Prototype "CorkBoard" Mobile view page </p>
  <p> The mobile view has a drop down hamburger menu that allows the user to go to their profile page and return to the "corkboard". </p>
  
<p align="center">  
  <img src="/img/mobileview.png" />
</p>

##   <p align="center"> Ticket Api List </p>
<img src="/img/APIDiagram.JPG"/>
