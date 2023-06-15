# NBA teams :basketball:

Create an aplication for viewing NBA teams. Create a model that contains information about the NBA teams: Id, Abbreviation, Name.
Create a static database that contains couple of teams. (list provided in this folder (ps. use the same IDs))
Create a view where all teams are listed in a table, and add details action next to each team.
When the user clicks on the details (per team) new view/page should be opened where Team details will be presented.

BONUS: When team details are presented, perform an ajax call to the external api for getting more team data that will enhance the existing one.
       Use the GET API https://www.balldontlie.io/api/v1/teams/<ID>, where <ID> is the team ID. Ex. https://www.balldontlie.io/api/v1/teams/2 returns data for Boston.
       Display this data as additional info to the Details view.

More info about the api: https://www.balldontlie.io/home.html