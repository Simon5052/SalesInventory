create table "ProductCategory"
(
	"ProductCategoryId" serial
		constraint productcategory_pk
			primary key,
	"CategoryName" varchar not null,
	"Active" bool default true not null
	
);


create table "Product"
(
    "ProductId"         bigserial                      not null
        constraint product_pk
            primary key,
    "ProductName"       varchar                        not null,
    "CreatedAt"         timestamp  without time zone   default now() not null,
    "ProductCategoryId" integer                        not null,
    "StockAvailable"    integer          default 0     not null,
    "Active"            boolean          default true  not null,
    "Cost"              double precision default 0     not null
);


create table "Sales"
(
	"SalesId" bigserial
		constraint sales_pk
			primary key,
	"ProductId" bigint not null,
	"QuantitySold" int not null,
	"TotalAmount" double precision not null,
	"CreatedAt" timestamp without time zone default now() not null,
    "SoldBy" varchar
);

DROP FUNCTION "GetAllProduct"()
create OR REPLACE function "GetAllProductCategories"()
    returns TABLE("ProductCategoryId" int, "CategoryName" character varying)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT PC."ProductCategoryId",PC."CategoryName"
      FROM "ProductCategory" PC
      WHERE "Active" = TRUE;
   END;
$$;

SELECT * FROM "GetAllProductCategories"()
CREATE PROCEDURE "InsertProductCategory"("CategoryName" varchar,  "Active" bool)
LANGUAGE SQL
AS $$
INSERT INTO "ProductCategory" VALUES ("CategoryName","Active");
$$;
CALL "InsertProductCategory"("Tech",true)

INSERT INTO "ProductCategory"("CategoryName") VALUES ('Drinks'),('Food');

create OR REPLACE function "GetAllProduct"()
    returns TABLE("ProductId" bigint, "ProductName" character varying, "CreatedAt" timestamp,  "ProductCategoryId" integer, "StockAvailable" integer, "Cost" double precision,"CategoryName" character varying )
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT P."ProductId", P."ProductName",P."CreatedAt",P."ProductCategoryId",P."StockAvailable",P."Cost", PC."CategoryName"
      FROM "Product" P
    left join "ProductCategory" PC on P."ProductCategoryId" = PC."ProductCategoryId"
      WHERE P."Active" = TRUE;
   END
$$;

SELECT * FROM "GetAllProduct"()




-- REAL ESTATE RENTALSSS

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "PropertyType"(
	"PropertyTypeId" SERIAL PRIMARY KEY NOT NULL,
    "PropertyTypeUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "PropertyTypeName" CHARACTER VARYING NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );
    
CREATE TABLE "Agent"(
	"AgentId" BIGSERIAL PRIMARY KEY NOT NULL,
	"AgentUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "FirstName" CHARACTER VARYING NOT NULL,
    "LastName" CHARACTER VARYING NOT NULL,
    "CompanyName" CHARACTER VARYING NOT NULL,
    "Email" CHARACTER VARYING NOT NULL,
    "PhoneNumber" INTEGER NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );
    
CREATE TABLE "Region"(
	"RegionId" SERIAL PRIMARY KEY NOT NULL,
    "RegionUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "RegionName" CHARACTER VARYING NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );
    
CREATE TABLE "Rental"(
	"RentalId" BIGSERIAL PRIMARY KEY NOT NULL,
    "RentalUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "AgentId" INTEGER NULLABLE,
    "CustomerId" INTEGER NOT NULL,
    "DateRented" TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW() NOT NULL,
    "DueDate" TIMESTAMP NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );
    
CREATE TABLE "Customer"(
	"CustomerId" BIGSERIAL PRIMARY KEY NOT NULL,
	"CustomerUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
	"FirstName" CHARACTER VARYING NOT NULL,
    "LastName" CHARACTER VARYING NOT NULL,
    "Email" CHARACTER VARYING,
    "PhoneNumber" INTEGER NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );
    
CREATE TABLE "Property"(
	"PropertyId" BIGSERIAL PRIMARY KEY NOT NULL,
	"PropertyUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
	"PropertytName" CHARACTER VARYING NOT NULL,
    "PropertyTypeId" INTEGER NOT NULL,
    "CityId" INTEGER NOT NULL,
    "Space" INTEGER NOT NULL,
    "Rooms" INTEGER NOT NULL,
    "Cost" DOUBLE PRECISION DEFAULT 0 NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );
    
CREATE TABLE "Location"(
	"LocationId" SERIAL PRIMARY KEY NOT NULL,
    "LocationUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "Address" CHARACTER VARYING NOT NULL,
    "RegionId" INTEGER NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );







