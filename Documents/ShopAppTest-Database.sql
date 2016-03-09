CREATE DATABASE ShoppingAppTest

CREATE TABLE CustomerMaster(
	CustomerID numeric(18, 0) IDENTITY(1,1) NOT NULL,
	CustomerTitle bit NOT NULL,
	CustomerFName text NOT NULL,
	CustomerLName nchar(10) NOT NULL,
	[Address] text NULL,
	ZipCode text NULL,
	City text NOT NULL,
	EmailAddress text NOT NULL,
 CONSTRAINT PK_CustomerMaster PRIMARY KEY CLUSTERED 
(
	CustomerID ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



CREATE TABLE ProductMaster(
	ProductID numeric(18, 0) IDENTITY(1,1) NOT NULL,
	ProductTitle varchar(80) NOT NULL,
	ProductDescription varchar(200) NOT NULL,
	ProductDescription2 text NULL,
	Price numeric(18, 0) NOT NULL,
	Discount numeric(18, 0) NULL,
	Images text NULL,
	Quantity numeric(18, 0) NOT NULL,
 CONSTRAINT [PK_ProductMaster] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
