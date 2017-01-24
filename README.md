# ShoeHouse

ShoeHouse is a website to view and update inventory in a small shoe store.

The project is composed of three libraries:

1. Data:
  Contains the entities from de database mapped to an EntityFramework model. The database is stored in Azure.

2. Core:
  Contains the business logic to access and export the data.

3. Web:
  This is a website with several functionalities
  
  ###/services/
  RESTful service that exposes products according to the requirements. Requires basic authentication. The api can be read in XML format or Json format.
  
  ###/home/
  Public section for common users, allows visitors to see the products by store. Consumes the services via ajax.
  
  ###/admin/
  Section for administrators, allows create, edit and delete products and stores. These controllers where created with .Net scaffolding.

## How to use
Download repository and run the web project. If the azure server does not respond comment the Azure connection string and uncomment the local connection.

See live demo in http://shoehouse17.azurewebsites.net

## Credits
Front page theme taken from freehtml5.co
https://freehtml5.co/story-free-html5-bootstrap-template-for-personal-blog-websites/

Stock images from Pixbay
https://pixabay.com/
