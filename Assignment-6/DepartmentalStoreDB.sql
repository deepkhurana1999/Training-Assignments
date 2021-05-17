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
	
-- Table: Products

CREATE TABLE Products
(product_id SERIAL PRIMARY KEY, product_name varchar(100) NOT NULL, brand_name varchar(50), 
 manufacturer varchar(100) NOT NULL);
 
-- Table: Categories

CREATE TABLE Categories
(category_id SERIAL PRIMARY KEY, category_name varchar(100) NOT NULL);

-- Table: Product_Categories

CREATE TABLE Product_Categories
(
 product_id int REFERENCES Products(product_id) NOT NULL,
 category_id int REFERENCES Categories(category_id) NOT NULL,
 PRIMARY KEY(product_id,category_id)
);

-- Table: Product_Price

CREATE TABLE Product_Price
( cost_price NUMERIC(10,3) NOT NULL,
  selling_price NUMERIC(10,3) NOT NULL,
  discount int DEFAULT 0,
  price_date date not NULL,
  product_id int References Products(product_id) NOT NULL
);

-- Table: Inventory

CREATE TABLE Inventory
( product_id int References Products(product_id) not NULL,
  opening_stock int DEFAULT 0,
  stock_purchase int DEFAULT 0,
  stock_sold int DEFAULT 0,
  PRIMARY KEY(product_id)
);

-- Table: Supplier

CREATE TABLE Supplier
( supplier_id SERIAL PRIMARY KEY,
  supplier_name varchar(100) NOT NULL,
  phone_number bigint,
  email varchar(30),
  address Varchar(100) NOT NULL,
  address_state varchar(50),
  country varchar(60) NOT NULL,
  pin_code int NOT NULL
);

-- Table: Products_Supplier

CREATE TABLE Product_Supplier
(
 product_id int references Products(product_id) NOT NULL,
 supplier_id int references Supplier(supplier_id) NOT NULL,
 Primary KEY(product_id,supplier_id)
);

-- Table: Purchase_Order
Create Table Purchase_Order
(
	purchase_order_id SERIAL PRIMARY KEY,
	quantity bigint not NULL,
	price NUMERIC(10,3) not NULL,
	product_id int not NULL,
	supplier_id int not NULL,
	purchase_date date not NULL,
	FOREIGN KEY (product_id, supplier_id) REFERENCES Product_Supplier
      (product_id,supplier_id)
);

-- Table: Staff

CREATE TABLE Staff
( staff_id SERIAL PRIMARY KEY,
  first_name varchar(30) not NULL,
  last_name varchar(30),
  address Varchar(100) NOT NULL,
  address_state varchar(50),
  country varchar(60) NOT NULL,
  pin_code int NOT NULL,
  designation varchar(30) NOT NULL,
  phone_number bigint
);

-- INSERT IN: Products
select * from Products;
INSERT INTO Products(product_name,brand_name,manufacturer) values('Lenovo Ideapad','Ideapad','Lenovo');
INSERT INTO Products(product_name,brand_name,manufacturer) values('Lenovo P2','P','Lenovo');
INSERT INTO Products(product_name,brand_name,manufacturer) values('Norton Antivirus 2020','Norton Antivirus','Norton');
INSERT INTO Products(product_name,brand_name,manufacturer) values('Apple Iphone 12','Iphone','Apple');
INSERT INTO Products(product_name,brand_name,manufacturer) values('Lindt Dark Chocolate','Dark Chocolate','Lindt');
INSERT INTO Products(product_name,brand_name,manufacturer) values('Microsoft Windows 10','Windows','Microsoft');
INSERT INTO Products(product_name,brand_name,manufacturer) values('Alemannenkäse Cheese','Alemannenkäse Bio','Alemannenkäse');

-- INSERT IN: Categories
select * from Categories;
INSERT INTO Categories(category_name) values('Software'),('Hardware'),('Smartphone'),('Dairy Products'),('Laptop');
INSERT INTO Categories(category_name) values('Electronics');

-- INSERT IN: Product_Categories
select * from Product_Categories;
INSERT INTO Product_Categories(product_id,category_id) values(1,5),(1,6),(2,3),(2,6),(3,1),(4,3),(4,6),(5,4),(6,1),(7,4);

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
INSERT INTO Inventory (product_id,opening_stock,stock_purchase,stock_sold)
values
(1,100,0,10),
(2,50,10,23),
(3,60,10,30),
(4,1000000,500000,1000000),
(5,10,0,10),
(6,40000,100000,50000),
(7,0,0,0)
;

-- INSERT IN: Supplier
select * from Supplier;
INSERT INTO Supplier(supplier_name, phone_number,email,address, address_state, country,pin_code)
values
('Njoy-Buying',1234567890,'n@gmail.com','26/1, 10th Floor, Brigade World Trade Center,Dr. Rajkumar Road','Banglore','India',560055),
('Synthite Industries Private Limited',4562319876,'s@gmail.com','Synthite Industries Private Limited, Synthite Valley, Kolenchery, Ernakulam','Kerala','India',682311),
('Appario Retail Private Ltd',2346189432,'a@gmail.com','26/1, 11th Floor, Brigade World Trade Center,Dr. Rajkumar Road','Banglore','India',560055),
('Arham World',7629520971,'ar@gmail.com','26/1, 11th Floor, Brigade World Trade Center,Dr. Rajkumar Road','Banglore','India',560055)
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

-- INSERT IN: Staff
select * from Staff;
INSERT INTO Staff (first_name,last_name,address,address_state,country,pin_code,designation,phone_number)
values
('Person1','last1','Address1','Delhi','India',110008,'Stock Maintainer',1568234098),
('Person2','last2','Address2','Banglore','India',550068,'Cashier',5162234098),
('Person3','last3','Address3','Karnataka','India',660068,'Helper',1569234098),
('Person4','last4','Address4','Karnataka','India',660068,'Helper',1234567890);

-- INSERT IN: Purchase_Order
select * from Purchase_Order;
INSERT INTO Purchase_Order(quantity,price,product_id,supplier_id,purchase_date)
values
(10,50000,2,3,'2021-02-11'),
(10,5000,3,4,'2021-02-24'),
(500000,30000,4,1,'2021-03-14'),
(10000,500000,6,4,'2021-05-01')
;


-- Query 1:
select first_name,last_name,designation,phone_number from Staff where first_name='Person1';

select first_name,last_name,designation,phone_number from Staff where phone_number=1234567890;

select first_name,last_name,designation,phone_number from Staff 
where first_name='Person1' or phone_number=1234567890;

-- Query 2:
select first_name,last_name,designation,phone_number from Staff where designation='Helper';

-- Query 3:
-- 3.a 
select * from Products where product_name='Lenovo P2';
-- 3.b
select p.product_name from Products p 
JOIN Product_Categories USING (product_id)
JOIN Categories c USING (category_id)
where c.category_name='Electronics';
-- 3.c
select p.product_name as "Products IN Stock" from Products p
JOIN Inventory i USING (product_id)
where i.opening_stock+i.stock_purchase-i.stock_sold>0;

select p.product_name as "Products Out of Stock" from Products p
JOIN Inventory i USING (product_id)
where i.opening_stock+i.stock_purchase-i.stock_sold<0 or i.opening_stock+i.stock_purchase-i.stock_sold=0;
-- 3.d
select p.product_name, pp.price_date from Products p 
JOIN Product_Price pp USING (product_id)
where pp.price_date = (select Max(pp2.price_date) from Product_Price pp2
					   where pp2.product_id=pp.product_id)
and pp.Selling_price>10000;

select p.product_name, pp.price_date from Products p 
JOIN Product_Price pp USING (product_id)
where pp.price_date = (select Max(pp2.price_date) from Product_Price pp2
					   where pp2.product_id=pp.product_id)
and pp.Selling_price<10000;

-- Query 4:
select count(p.product_name) as "No. of products out of stock" from Products p
JOIN Inventory i USING (product_id)
where i.opening_stock+i.stock_purchase-i.stock_sold<0 or i.opening_stock+i.stock_purchase-i.stock_sold=0;

-- Query 5:
select count(p.product_name) from Products p 
JOIN Product_Categories USING (product_id)
JOIN Categories c USING (category_id)
where c.category_name='Smartphone';

-- Query 6:
select c.category_name,count(p.product_name) as "total" from Products p 
JOIN Product_Categories USING (product_id)
JOIN Categories c USING (category_id)
group by(c.category_name)
order by total Desc;

-- Query 7:
-- 7.a
select * from Supplier where supplier_name LIKE 'Njoy-Buying';
-- 7.b
select * from Supplier where phone_number =1234567890;
-- 7.c
select * from Supplier where email LIKE 'n@gmail.com';
-- 7.d
select supplier_name, email, phone_number from Supplier where address_state LIKE 'Banglore';

-- Query 8:
select p.product_name, s.supplier_name, po.purchase_date from Products p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_id,supplier_id)
where po.purchase_date = (select Max(po2.purchase_date) from Purchase_Order po2
					      where po2.product_id = p.product_id
						  and po2.supplier_id = s.supplier_id);
-- 8.a
select p.product_name, s.supplier_name, po.purchase_date from Products p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_id,supplier_id)
where po.purchase_date = (select Max(po2.purchase_date) from Purchase_Order po2
					      where po2.product_id = p.product_id
						  and po2.supplier_id = s.supplier_id)
and p.product_name LIKE 'Norton Antivirus 2020';
-- 8.b
select p.product_name, s.supplier_name, po.purchase_date from Products p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_id,supplier_id)
where po.purchase_date = (select Max(po2.purchase_date) from Purchase_Order po2
					      where po2.product_id = p.product_id
						  and po2.supplier_id = s.supplier_id)
and s.supplier_name LIKE 'Nj%';
-- 8.c
select p.product_name, s.supplier_name, po.purchase_date from Products p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_id,supplier_id)
where po.purchase_date = (select Max(po2.purchase_date) from Purchase_Order po2
					      where po2.product_id = p.product_id
						  and po2.supplier_id = s.supplier_id)
and p.product_id = 4;
-- 8.d
select p.product_name, s.supplier_name, po.purchase_date from Products p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_id,supplier_id)
where po.purchase_date = (select Max(po2.purchase_date) from Purchase_Order po2
					      where po2.product_id = p.product_id
						  and po2.supplier_id = s.supplier_id)
and po.purchase_date > '2021-02-01';
-- 8.e
select p.product_name, s.supplier_name, po.purchase_date from Products p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_id,supplier_id)
where po.purchase_date = (select Max(po2.purchase_date) from Purchase_Order po2
					      where po2.product_id = p.product_id
						  and po2.supplier_id = s.supplier_id)
and po.purchase_date > '2021-02-01';
-- 8.f
select p.product_name, s.supplier_name, po.purchase_date from Products p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_id,supplier_id)
JOIN Inventory i USING (product_id)
where po.purchase_date = (select Max(po2.purchase_date) from Purchase_Order po2
					      where po2.product_id = p.product_id
						  and po2.supplier_id = s.supplier_id)
and i.opening_stock+i.stock_purchase-i.stock_sold>100;

select p.product_name, s.supplier_name, po.purchase_date from Products p
JOIN Product_Supplier ps USING (product_id)
JOIN Supplier s USING (supplier_id)
JOIN Purchase_Order po USING (product_id,supplier_id)
JOIN Inventory i USING (product_id)
where po.purchase_date = (select Max(po2.purchase_date) from Purchase_Order po2
					      where po2.product_id = p.product_id
						  and po2.supplier_id = s.supplier_id)
and i.opening_stock+i.stock_purchase-i.stock_sold<100;





