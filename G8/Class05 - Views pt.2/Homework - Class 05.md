Homework Class 05 :
Edit Action:

Create an action method named EditOrder in the controller that takes an id parameter.
Retrieve the order with the specified ID from the data source.
If the order doesn't exist, return a "Not Found" result.
Create a view named EditOrder.cshtml and pass the order data to it.
In the view, display the order details in form elements for editing.
Edit POST Action:

Create an action method named EditOrderPost in the controller and decorate it with [HttpPost].
Accept an OrderViewModel parameter named order.
Validate the submitted order data.
Retrieve the existing order from the data source based on its ID.
If the order doesn't exist, return a "Not Found" result.
Update the order properties with the edited values.
Save the changes to the data source.
Redirect the user to an appropriate action, such as the index page.
Delete Action:

Create an action method named DeleteOrder in the controller that takes an id parameter.
Retrieve the order with the specified ID from the data source.
If the order doesn't exist, return a "Not Found" result.
Create a view named DeleteOrder.cshtml and pass the order data to it.
In the view, display a confirmation message and buttons to proceed with the deletion or cancel.
Delete POST Action:

Create an action method named DeleteOrderPost in the controller and decorate it with [HttpPost].
Accept an id parameter of type int.
Retrieve the existing order from the data source based on its ID.
If the order doesn't exist, return a "Not Found" result.
Delete the order from the data source.
Redirect the user to an appropriate action, such as the index page.