DROP FUNCTION "k"(bigint)
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
CALL "InsertProductCategory"("Tech",true);

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

SELECT * FROM "GetAllProduct"();




drop function if exists "GetAllSalesByProductId"(bigint);
create OR REPLACE function "GetAllSalesByProductId"("_productId" bigint)
    returns TABLE("SalessId" bigint,"QuantitySold" integer, "SoldBy" character varying,
                                "ProductName" character varying, "StockAvailable" integer)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT S."SalesId", S."QuantitySold", S."SoldBy",P."ProductName",P."StockAvailable"
      FROM "Sales" S
   left join "Product" P ON S."ProductId" = P."ProductId"


      WHERE S."ProductId" = "_productId" ;
   END
$$;

SELECT * FROM  "GetAllSalesByProductId"(3);

DROP FUNCTION IF EXISTS "InsertProductCategory"(_categoryName varchar);
CREATE FUNCTION "InsertProductCategory"("_categoryName" varchar)
RETURNS int
LANGUAGE plpgsql
AS $$
    DECLARE _id int;
    BEGIN
        INSERT INTO "ProductCategory"("CategoryName") VALUES ("_categoryName")
        RETURNING  "ProductCategoryId" INTO _id;
        RETURN _id;
    END
    $$;


SELECT * FROM "InsertProductCategory"('Vehicle');

CREATE FUNCTION "InsertProduct"("_productName" varchar,"_productCategoryId" integer,
                                    "_stockAvailable" integer,"_cost" double precision)
returns bigint
LANGUAGE plpgsql
AS $$
    DECLARE "_productId" bigint;
    BEGIN
        INSERT INTO "Product"("ProductName","ProductCategoryId","StockAvailable","Cost") VALUES ("_productName","_productCategoryId",
                                                                                         "_stockAvailable","_cost")
        RETURNING "ProductId" INTO "_productId";
        RETURN  "_productId";


    end;
    $$;

Select  * FROM "InsertProduct"('Mustang',7,30,100000);







create OR REPLACE function "GetAllSales"()
    returns TABLE("ProductId" bigint, "QuantitySold" integer, "TotalAmount" double precision, "SoldBy" character varying )
    language plpgsql
as
$$
BEGIN
    if "TotalAmount"> 0 Then

   RETURN QUERY
   SELECT S."ProductId", S."QuantitySold",S."TotalAmount",S."SoldBy"
      FROM "Sales" S

   END
$$;

create function "InsertSale"("_productId" bigint,"_quantitySold" int, "_totalAmount" double precision,
"_soldBy" character varying )
RETURNS character varying
LANGUAGE plpgsql
AS $$
    DECLARE
        "_newStockValue" integer;

         DECLARE "_oldStockValue" integer;

    BEGIN
        SELECT P."StockAvailable" into "_oldStockValue" FROM "Product" P
        WHERE P."ProductId" = "_productId";

        IF "_quantitySold" > "_oldStockValue" THEN
            return 'Not Possible cannot buy more than the stock available';
        else
            "_newStockValue" = "_oldStockValue" - "_quantitySold";
            UPDATE "Product"
            SET  "StockAvailable" = "_newStockValue"
            where "ProductId" = "_productId";

            INSERT INTO "Sales"("ProductId","QuantitySold","TotalAmount","SoldBy") values ("_productId","_quantitySold",
                                                                                           "_totalAmount","_soldBy");
            return 'success';
        end if;



    end



    $$;



SELECT * FROM "InsertSale"(9,20,400,'Selorm');
CREATE FUNCTION "DeleteProduct"("_productId" bigint)
returns CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        update "Product"
        SET "Active" = FALSE
        WHERE "ProductId" = "_productId";

        RETURN  'Product has been deleted';


    end
    $$;







