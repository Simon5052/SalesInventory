alter table "Product"
	add constraint product_productcategory_fk
		foreign key ("ProductCategoryId") references "ProductCategory";


alter table "Sales"
	add constraint sales_productid_fk
		foreign key ("ProductId") references "Product";





-- ALTER FROM MY REAL ESTATE RENTALS




alter table "Property"
	add constraint property_propertytypeid_fk
		foreign key ("PropertyTypeId") references "PropertyType",
   add constraint property_cityid_fk
      foreign key ("LocationId") references "Location";




alter table "Rental"
	add constraint rental_agentid_fk
		foreign key ("AgentId") references "Agent",
   add constraint rental_customerid_fk
      foreign key ("CustomerId") references "Customer";



