-- Database: DepartmentalStoreDB

-- DROP DATABASE "DepartmentalStoreDB";

CREATE DATABASE "DepartmentalStoreDB"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_India.1252'
    LC_CTYPE = 'English_India.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
	
-- Table: Product

CREATE TABLE Product
(
 product_id SERIAL PRIMARY KEY, 
 product_name varchar(100) NOT NULL,
 product_code varchar(100) NOT NULL UNIQUE,
 brand_name varchar(50), 
 manufacturer varchar(100) NOT NULL,
 available_quantity bigint DEFAULT 0
);
 
-- Table: Category

CREATE TABLE Category
(
 category_id SERIAL PRIMARY KEY, 
 category_name varchar(100) NOT NULL,
 category_code varchar(100) NOT NULL UNIQUE
);

-- Table: Product_Category

CREATE TABLE Product_Category
(
 product_id int REFERENCES Product(product_id) NOT NULL,
 category_id int REFERENCES Category(category_id) NOT NULL,
 PRIMARY KEY(product_id,category_id)
);

-- Table: Product_Price

CREATE TABLE Product_Price
( cost_price NUMERIC(10,3) NOT NULL,
  selling_price NUMERIC(10,3) NOT NULL,
  discount int DEFAULT 0,
  price_date date not NULL,
  product_id int References Product(product_id) NOT NULL
);

-- Table: Inventory

CREATE TABLE Inventory
( product_inventory_id int References Product(product_id) not NULL,
  opening_stock int DEFAULT 0,
  stock_purchase int DEFAULT 0,
  stock_sold int DEFAULT 0,
  PRIMARY KEY(product_inventory_id)
);

-- Table: Inventory_History
CREATE TABLE Inventory_History
( product_inventory_id int References Inventory(product_inventory_id) not NULL,
  transaction_date date,
  quantity int
);

-- Table: Address
CREATE TABLE Address
(
  address_id SERIAL PRIMARY KEY,
  address_line1 Varchar(100) NOT NULL,
  address_line2 varchar(100) NOT NULL,
  city varchar(50),
  address_state varchar(50),
  country varchar(60) NOT NULL,
  pin_code int NOT NULL
);

-- Table: Supplier
CREATE TABLE Supplier
( supplier_id SERIAL PRIMARY KEY,
  supplier_name varchar(100) NOT NULL,
  phone_number char(10) NOT NULL,
  address_id int REFERENCES Address(address_id) NOT NULL,
  email varchar(30) NOT NULL
);

-- Table: Product_Supplier
CREATE TABLE Product_Supplier
(
 product_supplier_id SERIAL PRIMARY KEY,
 product_id int references Product(product_id) NOT NULL,
 supplier_id int references Supplier(supplier_id) NOT NULL,
 CONSTRAINT product_supplier_info UNIQUE (product_id,supplier_id)
);

-- Table: Purchase_Order
Create Table Purchase_Order
(
	purchase_order_id SERIAL PRIMARY KEY,
	quantity bigint not NULL,
	price NUMERIC(10,3) not NULL,
	product_supplier_id int REFERENCES Product_Supplier(product_supplier_id) not NULL,
	purchase_date date not NULL
);


-- Table: Designation

CREATE TABLE Designation
(
	designation_id SERIAL PRIMARY KEY,
	designation_name varchar(20) UNIQUE,
	description varchar(1024)
);

-- Table: Staff
CREATE TABLE Staff
( 
  staff_id SERIAL PRIMARY KEY,
  first_name varchar(30) not NULL,
  last_name varchar(30),
  address_id int REFERENCES Address(address_id),
  designation varchar(20) REFERENCES Designation(designation_name) NOT NULL,
  phone_number char(10) NOT NULL,
  gender char(1) NOT NULL
);

-- INSERT IN: Product
select * from Product;
INSERT INTO Product(product_name,product_code,brand_name,manufacturer,available_quantity) 
values
('Lenovo Ideapad','LI2020LAP','Ideapad','Lenovo',90),
('Lenovo P2','LPSM','P','Lenovo',37),
('Norton Antivirus 2020','NA2020SW','Norton Antivirus','Norton',40),
('Apple Iphone 12','AI12SM','Iphone','Apple',500000),
('Lindt Dark Chocolate','LDCHOCDRYP','Dark Chocolate','Lindt',0),
('Microsoft Windows 10','W10SW','Windows','Microsoft',100000),
('Alemannenkäse Cheese','ACDRYP','Alemannenkäse Bio','Alemannenkäse',0);

-- INSERT IN: Category
select * from Category;
INSERT INTO Category(category_name,category_code) values
('Software','SW'),
('Hardware','HW'),
('Smartphone','SM'),
('Dairy Products','DRYP'),
('Laptop','LAP'),
('Electronics','ELEC');

-- INSERT IN: Product_Category
select * from Product_Category;
INSERT INTO Product_Category(product_id,category_id) values(1,5),(1,6),(2,3),(2,6),(3,1),(4,3),(4,6),(5,4),(6,1),(7,4);

-- INSERT IN: Product_Price
select * from Product_Price;
INSERT INTO Product_Price(cost_price,selling_price,discount,price_date,product_id)
Values
(80000,100000,0,'2021-01-01',1),
(80000,120000,0,'2021-05-01',1),
(10000,15000,0,'2015-07-01',2),
(5000,10000,0,'2021-04-01',2),
(500,800,0,'2021-04-01',3),
(100000,120000,0,'2020-05-01',4),
(60000,84000,0,'2021-04-01',4),
(100,150,20,'2021-04-01',5),
(7000,9290,20,'2021-02-01',6),
(1000,1500,0,'2021-03-01',7)
;

-- INSERT IN: Inventory
select * from Inventory;
INSERT INTO Inventory (product_inventory_id,opening_stock,stock_purchase,stock_sold)
values
(1,100,0,10),
(2,50,10,23),
(3,60,10,30),
(4,1000000,500000,1000000),
(5,10,0,10),
(6,50000,100000,50000),
(7,0,0,0)
;

-- INSERT IN: Address
select * from Address;
INSERT INTO Address(address_line1,address_line2,city,address_state,country,pin_code)
values
('26/1, 10th Floor','Brigade World Trade Center,Dr. Rajkumar Road',NULL,'Banglore','India',560055),
('Synthite Industries Private Limited','Synthite Valley Kolenchery','Ernakulam','Kerala','India',682311);

-- INSERT IN: Supplier
select * from Supplier;
INSERT INTO Supplier(supplier_name, phone_number,email,address_id)
values
('Njoy-Buying','2345678961','n@gmail.com',1),
('Synthite Industries Private Limited','4562319876','s@gmail.com',2),
('Appario Retail Private Ltd','2346189432','a@gmail.com',1),
('Arham World','7629520971','ar@gmail.com',1)
;

-- INSERT IN: Product_Supplier
select * from Product_Supplier;
INSERT INTO Product_Supplier (product_id,supplier_id)
values
(1,1),
(1,3),
(2,3),
(3,4),
(4,1),
(4,3),
(5,2),
(6,4),
(7,2)
;
-- INSERT IN: Staff - Address
select * from Address;
INSERT INTO Address(address_line1,address_line2,city,address_state,country,pin_code)
values
('Address1','Address1.2','New Delhi','Delhi','India',110008),
('Address2','Address2.2','Banglore','Karnataka','India',550068),
('Address3','Address3.2','Banglore','Karnataka','India',550068);

-- INSERT IN: Designation
select * from Designation;
INSERT INTO Designation (designation_name)
values
('Stock Maintainer'),
('Cashier'),
('Helper');

-- INSERT IN: Staff
select * from Staff;
INSERT INTO Staff (first_name,last_name,address_id,designation,phone_number,gender)
values
('Person1','last1',3,'Stock Maintainer','1568234098','M'),
('Person2','last2',4,'Cashier','5162234098','F'),
('Person3','last3',4,'Helper','1569234098','F'),
('Person4','last4',5,'Helper','1234567890','M');

-- INSERT IN: Purchase_Order
select * from Purchase_Order;
INSERT INTO Purchase_Order(quantity,price,product_supplier_id,purchase_date)
values
(10,50000,3,'2021-02-11'),
(10,5000,4,'2021-02-24'),
(500000,30000,5,'2021-03-14'),
(10000,500000,8,'2021-05-01')
;


-- Query 1:
select first_name,last_name,designation,phone_number from Staff where first_name='Person1';

select first_name,last_name,designation,phone_number from Staff where phone_number LIKE '1234567890';

select first_name,last_name,designation,phone_number from Staff 
where first_name='Person1' or phone_number LIKE '1234567890';

-- Query 2:
select first_name,last_name,designation,phone_number from Staff where designation LIKE 'Helper';

-- Query 3:
-- 3.a 
select * from Product where product_name='Lenovo P2';
-- 3.b
select p.product_name from Product p 
JOIN Product_Category USING (product_id)
JOIN Category c USING (category_id)
where c.category_name='Electronics';
-- 3.c
select p.product_name as "Products IN Stock" from Product p
JOIN Inventory i ON p.product_id = i.product_inventory_id
where p.available_quantity>0;

select p.product_name as "Products Out of Stock" from Product p
JOIN Inventory i ON p.product_id = i.product_inventory_id
where p.available_quantity<0 or p.available_quantity=0;
-- 3.d
select p.product_name, pp.price_date from Product p 
JOIN Product_Price pp USING (product_id)
where pp.price_date = (select Max(pp2.price_date) from Product_Price pp2
					   where pp2.product_id=pp.product_id)
and pp.Selling_price>10000;

select p.product_name, pp.price_date from Product p 
JOIN Product_Price pp USING (product_id)
where pp.price_date = (select Max(pp2.price_date) from Product_Price pp2
					   where pp2.product_id=pp.product_id)
and pp.Selling_price<10000;

-- Query 4:
select count(p.product_name) as "No. of products out of stock" from Product p
JOIN Inventory i ON p.product_id = i.product_inventory_id
where i.opening_stock+i.stock_purchase-i.stock_sold<0 or i.opening_stock+i.stock_purchase-i.stock_sold=0;

-- Query 5:
select count(p.product_name) from Product p 
JOIN Product_Category USING (product_id)
JOIN Category c USING (category_id)
where c.category_name='Smartphone';

-- Query 6:
select c.category_name,count(p.product_name) as "total" from Product p 
JOIN Product_Category USING (product_id)
JOIN Category c USING (category_id)
group by(c.category_name)
order by total Desc;

-- Query 7:
-- 7.a
select * from Supplier where supplier_name LIKE 'Njoy-Buying';
-- 7.b
select * from Supplier where phone_number LIKE '7629520971';
-- 7.c
select * from Supplier where email LIKE 'n@gmail.com';
-- 7.d
select s.supplier_name, s.email, s.phone_number from Supplier s
JOIN Address a USING (address_id)
where a.address_state LIKE 'Kerala';

-- Query 8:
select p.product_name, s.supplier_name, po.purchase_date from Product p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_supplier_id)
;

-- 8.a
select p.product_name, s.supplier_name, po.purchase_date from Product p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_supplier_id)
where p.product_name LIKE 'Norton Antivirus 2020';
-- 8.b
select p.product_name, s.supplier_name, po.purchase_date from Product p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_supplier_id)
where s.supplier_name LIKE 'Nj%';
-- 8.c
select p.product_name, s.supplier_name, po.purchase_date from Product p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_supplier_id)
where p.product_code = 'AI12SM';
-- 8.d
select p.product_name, s.supplier_name, po.purchase_date from Product p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_supplier_id)
where po.purchase_date > '2021-02-01';
-- 8.e
select p.product_name, s.supplier_name, po.purchase_date from Product p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_supplier_id)
where po.purchase_date > '2021-02-01';
-- 8.f
select p.product_name, s.supplier_name, po.purchase_date from Product p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_supplier_id)
JOIN Inventory i ON i.product_inventory_id = p.product_id
where i.opening_stock+i.stock_purchase-i.stock_sold>100;

select p.product_name, s.supplier_name, po.purchase_date from Product p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_supplier_id)
JOIN Inventory i ON i.product_inventory_id = p.product_id
where i.opening_stock+i.stock_purchase-i.stock_sold<100;





