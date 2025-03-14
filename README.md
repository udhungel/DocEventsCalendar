# DocEventsCalendar

When Running the API after cloning 

Step 1: Update Connection String
Open the project in your code editor.
Locate the appsettings.json file in the root of the project.
Update the DefaultConnection string to point to your SQL Server instance. For example:

"ConnectionStrings": {
  "DefaultSQLConnection": "Server=(localdb)\localdb1; Database =TechnicalTask; Trusted_Connection = True ; MultipleActiveResultSets=true; TrustServerCertificate = true"
}


Note
Please make sure the ServerName matches the Server in the ConnectionStrings inside appsettings.json file 


Step 2: Update the Database
Open Package Manager console in you Visual Studio 
 Update-Database

Once the update-database happens you will see the TechnicalTask in your server together with following tables 

Models
Attendee:
		Id: Primary Key 
		Name: limited to 100 characters
		Email (limited to 256 characters
		EventAttendances: Navigation Property 

Event:
	Id: Primary Key 
	Title: limited to 100 characters
	Description: limited to 500 characters
	StartTime:  Defaulted Contraint to DateTime Now
	EndTime: Defaulted Contraint to DateTime Now
	EventAttendances: Navigation Property


A bridge table that establishes a many-to-many relationship between Attendee and Event.
EventAttendee 
AttendeeId: Foreign key referencing the Attendee.
EventId: Foreign key referencing the Event.
IsAttending: A boolean 
Composite Key: Here we have AttendeeId and EventId serves as a composite primary key


Step 3 : You will be able to run the WeB API and use the endpoints for 
Events : 
	    Create Event:
		Update Event:
		Delete Event:
		Get All Events:
		Get Event by ID:
		Add Attendee to Event:
		Remove Attendee from Event:

TODO:  
       Endpoint to Add Attendee
	   Filtering using Name 
	   Create Client using NSWAG 
	   Notification Service - EmailNotificationService using SMTP 	   
	   Unit Test 
	   OpenApi Intregation 
