# Async-Inn
This is a web app built using ASP.NET Core and MS SQL server. It features a hotel management system to perfom CRUD operations on data using the Entitiy Framework Core.

## Visual
![](screencap.JPG)

## How to use
1. Clone Repo
2. Open Solution file in Visual Studio
3. Run using IIS
4. Interact with the website using the webpage that has loaded
5. Enjoy

## Database Schema
![](SchemaAsyncInn.png)
This schema represents our database structure. Featuring:
1. Hotel - This table holds information about each location only. This doesn't hold any foreign keys as the rooms are associated to each location, as the relationship is many rooms to one location.

2. HOTEL ROOM - This table holds information about the individual rooms. This is an entity join table, using roomnumber and hotelID to create a unique id, with payload properties like rate, perfriendly.

3. ROOM - This table contains information about the types of rooms available, with an enum LAYOUT that holds room types.

4. ROOM AMENITIES - This is a pure join table, simply linking a Rooms to amenities. This is the way we can link a many to many relationship using Entity Framework.

5. AMENITIES- This holds ammenities that can be added and later used in the Room Ammenities Table.
