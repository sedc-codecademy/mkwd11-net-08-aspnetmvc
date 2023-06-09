
# Lab Exercise - Bike App

### 1. Create mvc application in .net 6 called BikeApp
### 2. Define the models of the application

### Bike model: (class)

- Id: int
- Manufacturing Name: string (Brand)
- Wheel Diameter: int (26, 27, 29)
- Gears: int (18, 22, 24 speeds)
- Has Hydraulic Breaks: bool
- Bike Type: enum

#### Bike Type: (enum)
- Mountine
- Road
- City

### 3. Create in memory database that contains list of bikes and seed it with atleast 3 different bikes

### 4. Create Bike Controller with 4 actions 

- GetAllBikes
- GetAllBikesWithHydraulicBreaks
- GetBikeById
- DeleteBike (also a get method) ** bonus

### 5. Create appropriate views for the created actions in the previous step:

- GetAllBikes should display all bikes from the database in the unorderd html list
- GetAllBikesWithHydraulicBreaks should display bikes from the database that have hydraulic breaks in the unorderd html list
- GetBikeById should show a details about one specific bike that will be found by it's id
- DeleteBike should find and delete the bike by Id if that bike exists in the database ** bonus

### 6. For displaying the bikes use view models that will be used buy the view, and create apropriate mappers that will convert the data from domain to view model. Map only the necessary data needed for the view.