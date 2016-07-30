# _hairsalon_

#### _Interactive hair salon application that allows entry of new stylist, and clients for each stylist. Each stylist can be clicked to allow the user to view each stylist client list. _

#### By _**Rick Thornbrugh.**_

## Description

_User starts at the index page.  There are two options; view stylist, and view clients. If stylist is selected, page redirects to stylist page. A clickable list of stylist will appear on the screen.  If no stylist are listed, a message stating that will appear. The stylist are clickable. The stylist may be edited, and/or deleted.  Upon clicking the stylist, page redirects to a page that list all the stylist clients. Each page will have redirects for going to input pages for stylist, and clients.  Each input page will have a name field and submit button.  The client entry page will have a selector for which stylist to be placed under._

## Setup/Installation Requirements

_File can be cloned from Github @ [https://github.com/Rick1970/hairsalon].
Created in C# with atom text editor.  Used Nancy framework, and razor view engine.  To run the file after download; first run dnu restore from the command line in order to link to the project.lock.json file. Set up the server by:
In SQLCMD -S "(localdb)\mssqllocaldb"

CREATE DATABASE hair_salon;
GO
USE hair_salon;
GO
CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
CREATE TABLE clients (id INT IDENTITY(1,1), description VARCHAR(255), stylist_id INT);
GO
Open SMSS. Backup the hair_salon file.  Then restore the hair_salon file.  Rename as hair_salon_test during restore.  A mirror test copy will be created. _

## Known Bugs
_None known._

## Support and contact details

_Contact the author at [rthornbrug@gmail.com]._

## Technologies Used

_Atom text editor, in C#, with Nancy framework and razor view engine, xunit testing, Sql server, running on Kestrel server._

### License

*MIT License

*Copyright (c) [2016]
